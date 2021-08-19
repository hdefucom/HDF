// Copyright (C) 2007 XtractPro (Data Extraction Magazine)
// http://www.xtractpro.com, support@xtractpro.com
//
// This code is provided AS IS, with NO WARRANTY expressed or implied.
// Any use of this free open source code is at your own risk.
//
// You are hereby granted the right to use it and change it,
// provided that you acknowledge XtractPro somewhere in your
// source files, documentation, web site and application.

using System;
using System.Text;
using System.Web;
using System.Collections;
using System.Collections.Specialized;

namespace XtractPro.Text
{
    /// <summary>
    /// Base abstract class for sequential parsing-based syntax highlighters
    /// </summary>
    public abstract class SyntaxHighlighter
    {
        #region Process (Entry Point)

        /// <summary>
        /// Converts plain source code as text to HTML
        /// </summary>
        public string Process(string code)
        {
            // simple generic wrapper for all error handling
            try { return ProcessThis(code); }
            catch (Exception ex)
            {
                return "<pre><div class=\"sh_result\"><span class=\"sh_error\">"
                    + "Sorry, processing error:\r\n" + ex.Message
                    + "</span></div></pre>";
            }
        }

        /// <summary>
        /// To be implemented in each derived class,
        /// for a specific programming language
        /// </summary>
        protected virtual string ProcessThis(string code)
        {
            return code;
        }
        #endregion

        #region Types

        // All identifiers recognized and shown as type names
        // Always initially empty, can be manually filled in
        protected ArrayList _types = new ArrayList();
        public string[] Types
        {
            get
            {
                return (string[])_types.ToArray(typeof(string));
            }
            set
            {
                _types.Clear();
                foreach (string type in value)
                    if (!_types.Contains(type))
                        _types.Add(type);
            }
        }
        #endregion

        #region Line Numbers

        // Append line headers with line numbers
        protected bool _showLineNumbers = true;
        public bool ShowLineNumbers
        {
            get { return _showLineNumbers; }
            set { _showLineNumbers = value; }
        }

        // Padding for the line number
        protected int _lineNumberSpaces = 5;
        public int LineNumberSpaces
        {
            get { return _lineNumberSpaces; }
            set { _lineNumberSpaces = value; }
        }

        private bool _AddCssSourceCode = false;

        public bool AddCssSourceCode
        {
            get { return _AddCssSourceCode; }
            set { _AddCssSourceCode = value; }
        }

        protected void InsertCssSourceCode()
        {
            if (_AddCssSourceCode)
            {
                _result.Insert(0, @"<style>
/* All Syntax Highlighters */
div.sh_result { font-size: 9pt; font-family: Courier New, Verdana, Helvetica, Arial, sans-serif;background-color:#fdf5e6; }
span.sh_error { color: #ff0000; }
span.sh_line { color: #008284; margin-right: 10px; border-right: 1px solid #008284; }
span.sh_collapsed { color: #848284;border:1px solid #848284; }
span.sh_collapsed:hover { cursor:pointer; }
span.sh_expanded { color: #848284;text-decoration:underline; }
span.sh_expanded:hover { cursor:pointer; }

/* C#/VB.NET Syntax Highlighters */
span.net_key { color: #0000ff; }
span.net_type { color: #008284; }
span.net_directive { color: #6699cc; }
span.net_string, span.net_string a { color: #a31515; }
span.net_comment, span.net_comment a { color: #008200; }
span.net_xml, span.net_xml a { color: #848284; }

/* XML/HTML Syntax Highlighters */
span.xml_elem { color: #a31515; }
span.xml_delim { color: #0000ff; }
span.xml_att { color: #ff0000; }
span.xml_val { color: #0000ff; }
span.xml_text { color: #6699cc; }
span.xml_comment { color: #008200; }
</style>");
            }
        }

        /// <summary>
        /// Generic method, to be called at the end of ProcessThis,
        /// after regular parsing and before returning the results
        /// </summary>
        protected void AddLineNumbers()
        {
            if (_showLineNumbers)
            {
                // Simple Split&Merge algorithm:
                // Split _result string in lines and append a header
                // with the line number for each line
                // The new _result contains all merged lines, with headers
                string[] lines = _result.ToString().Split('\n');
                _result = new StringBuilder();
                for (int i = 0; i < lines.Length; i++)
                {
                    _result.Append("<span class=\"sh_line\">");
                    _result.Append((i + 1).ToString().PadLeft(_lineNumberSpaces));
                    _result.Append("</span>");
                    _result.Append(lines[i]);
                    _result.Append('\n');
                }
            }
        }
        #endregion

        #region Collapsible Blocks

        // Show collapsible blocks, such as .NET #regions
        // When true, adds an additional Show/Hide switch on top,
        // to collapse and expand whole result content
        protected bool _showCollapsibleBlocks = true;
        public bool ShowCollapsibleBlocks
        {
            get { return _showCollapsibleBlocks; }
            set { _showCollapsibleBlocks = value; }
        }

        // HTML collapsible block identifiers start with "blk",
        // followed by a rotating value between 1 and MAX_BLOCK_ID
        protected const int MAX_BLOCK_ID = 1000000;
        protected int _lastBlockId = 0;

        // To add collapsible blocks, call AddCollapsibleBlock for #region
        // and EndCollapsibleBlock() after #endregion
        // For empty text, adds Show/Hide top content block
        protected string AddCollapsibleBlock(string text)
        {
            if (!_showCollapsibleBlocks)
                return text;
            if (text.Length == 0)
                text = "Show/Hide\r\n";
            if (_lastBlockId == MAX_BLOCK_ID)
                _lastBlockId = 0;

            // collapsible blocks are dynamically processed
            // by JavaScript's shToggle function, from SyntaxHighlighters.js
            return "<span class=\"sh_expanded\" onclick=\"shToggle(this,"
                + (++_lastBlockId) + ")\">" + text
                + "</span><span id=\"blk" + _lastBlockId + "\">";
        }
        protected string EndCollapsibleBlock()
        {
            return (_showCollapsibleBlocks ? "</span>" : "");
        }
        #endregion

        #region Hyperlinks

        // Detects and shows as HTML A links text starting by a TCP/IP service name
        protected bool _showHyperlinks = true;
        public bool ShowHyperlinks
        {
            get { return _showHyperlinks; }
            set { _showHyperlinks = value; }
        }

        // Characters recognized as part of a possible hyperlink
        protected virtual bool IsHyperlinkChar(char c)
        {
            return (!Char.IsWhiteSpace(c)
                && (!Char.IsPunctuation(c) || c == '.' || c == '/' || c == ':' || c == '?'));
        }

        /// <summary>
        /// Parse and convert possible hyperlinks in a plain text
        /// Hyperlink must start with one of http://, https://, ftp://, telnet:/, gopher://
        /// If no _showHyperlinks, just return whole text HTML-encoded
        /// </summary>
        /// <param name="text">Plain text to be checked for hyperlinks</param>
        /// <returns>HTML-encoded text, with eventual hyperlinks</returns>
        protected string AddHyperlinks(string text)
        {
            int endEncoded = 0; // text HTML-encoded until this last position
            if (_showHyperlinks)
                for (int position = 0; position < text.Length; )
                {
                    // skip characters between identifiers
                    while (position < text.Length && !IsHyperlinkChar(text[position]))
                        position++;
                    if (position >= text.Length)
                        break;

                    // collects next identifier
                    int start = position;
                    while (position < text.Length && IsHyperlinkChar(text[position]))
                        position++;
                    if (position > start)
                    {
                        string token = text.Substring(start, position - start);
                        if (token.StartsWith("http://",
                                StringComparison.InvariantCultureIgnoreCase)
                            || token.StartsWith("https://",
                                StringComparison.InvariantCultureIgnoreCase)
                            || token.StartsWith("ftp://",
                                StringComparison.InvariantCultureIgnoreCase)
                            || token.StartsWith("telnet:/",
                                StringComparison.InvariantCultureIgnoreCase)
                            || token.StartsWith("gopher://",
                                StringComparison.InvariantCultureIgnoreCase))
                        {
                            // yep, that's a possible hyperlink
                            token = Encode(token);
                            token = "<a rel=\"nofollow\" target=\"_blank\" href=\""
                                + token + "\">" + token + "</a>";
                            token = text.Substring(0, endEncoded)
                                + Encode(text.Substring(endEncoded, start - endEncoded))
                                + token;
                            text = token + text.Substring(position);
                            endEncoded = position = token.Length;
                        }
                    }
                }

            // return starting encoded portion with HTML-encoded now trailing portion
            return text.Substring(0, endEncoded) + Encode(text.Substring(endEncoded));
        }
        #endregion

        #region Other Properties

        // Switch between HTML and RTF output result.
        // Supports HTML output only. (RTF not implemented at this time)
        protected bool _showRtf = false;
        public bool ShowRtf
        {
            get { return _showRtf; }
            set { _showRtf = value; }
        }

        // Show or skip text recognized as comment
        protected bool _showComments = true;
        public bool ShowComments
        {
            get { return _showComments; }
            set { _showComments = value; }
        }
        #endregion

        #region Buffer Fields and Functions

        // input string is collected in _buffer and output sent back from _result
        protected string _buffer = "";
        protected StringBuilder _result;
        // _start till _end returns a substring within _buffer
        protected int _start = 0;
        protected int _end = 0;
        // counter of chars for last identifier
        protected int _chars = 0;

        protected string NewLine() { return System.Environment.NewLine; }
        protected string Encode(string s) { return HttpUtility.HtmlEncode(s); }

        // Character functions returns '\0' if char not found
        protected char CharAt(int position)
        {
            return (position < 0 || position >= _buffer.Length ? '\0' : _buffer[position]);
        }

        // Returns a _buffer[_start +/- offset] character 
        protected char Current() { return CharAt(_start); }
        protected char Current(int i) { return CharAt(_start + i); }

        // Find next position of substring s in _buffer, from position
        // and returns end of _buffer (if not found) or found position + offset
        protected int FindNext(string s, int position, int offset)
        {
            int i = _buffer.IndexOf(s, position);
            return (i < 0 ? _buffer.Length : i + offset);
        }

        // Substring(start, end) returns substring between positions start and end
        // Substring() returns substring between positions _start and _end
        // Substring(chars) returns substring with chars characters before or after _start
        protected string Substring() { return Substring(_start, _end); }
        protected string Substring(int chars)
        {
            if (chars > 0)
                return Substring(_start, _start + chars);
            return Substring(_start + chars, _start);
        }
        protected string Substring(int start, int end)
        {
            if (_end >= _buffer.Length)
                _end = _buffer.Length - 1;
            if (_end < 0)
                return _buffer.Substring(start);
            return _buffer.Substring(start, end - start);
        }

        // True is s empty or contains only white spaces
        protected bool IsEmpty(string s)
        {
            if (s.Length > 0)
                for (int i = 0; i < s.Length; i++)
                    if (s[i] != ' ' && s[i] != '\t' && s[i] != '\r' && s[i] != '\n')
                        return false;
            return true;
        }

        // Returns string s with HTML SPAN, only if not empty
        protected string AddSpan(string s, string className)
        {
            if (IsEmpty(s))
                return s;
            return "<span class=\"" + className + "\">" + s + "</span>";
        }

        #endregion
    }
}
