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
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Collections;
using System.Collections.Specialized;

namespace XtractPro.Text
{
    /// <summary>
    /// Syntax Highlighter for C# programming language
    /// </summary>
    public class CSharpSyntaxHighlighter : SyntaxHighlighter
    {
        // All keywords used by C# language syntax
        private static ArrayList _keywords = new ArrayList();
        static CSharpSyntaxHighlighter()
        {
            string KEYWORDS = "partial abstract as base bool break byte "
                + "case catch char checked class const continue "
                + "decimal default delegate do double else enum event explicit extern "
                + "false finally fixed float for foreach "
                + "goto if implicit in int interface internal is "
                + "lock long namespace new null object operator out override "
                + "params private protected public readonly ref return "
                + "sbyte sealed short sizeof stackalloc static string struct switch "
                + "this throw true try typeof uint ulong unchecked unsafe ushort using "
                + "virtual void while #region #endregion";
            _keywords.AddRange(KEYWORDS.Split(' '));
        }

        /// <summary>
        /// Returns highlighted HTML from unformatted C# text code
        /// </summary>
        /// <param name="code">C# source code text</param>
        /// <returns>highlighted HTML</returns>
        protected override string ProcessThis(string code)
        {
            _buffer = code.Trim(' ', '\t', '\r', '\n');
            _result = new StringBuilder(_buffer.Length * 2);
            _start = _chars = 0;
            // sequential traversal of input string buffer
            while (_start < _buffer.Length)
            {
                // collected an identifier? (keyword, directive, type, other)
                if (_chars > 0
                    && (Char.IsWhiteSpace(Current())
                    || Char.IsPunctuation(Current()) && Current() != '#'))
                    AddIdentifier();

                // character value? ('...')
                if (Current() == '\'')
                    AddCharValue();

                // string value? ("..." or verbatim @"...")
                else if (Current() == '"'
                    || Current() == '@' && Current(1) == '"')
                    AddStringValue();

                // comment? (single-line, multi-line, documentation)
                else if (Current() == '/'
                    && (Current(1) == '*' || Current(1) == '/'))
                {
                    if (Current(1) == '*')
                        AddMultiLineComment();
                    else if (Current(2) == '/')
                        AddDocumentationComment();
                    else
                        AddSingleLineComment();
                }

                // advance/collect next whitespace/punctuation/identifier char
                else
                {
                    if (Char.IsWhiteSpace(Current())
                        || Char.IsPunctuation(Current()) && Current() != '#')
                        _result.Append(Encode(Current().ToString()));
                    else
                        _chars++;
                    _start++;
                }
            }

            // collect last identifier
            if (_chars > 0)
                AddIdentifier();

            // add line numbers, Show/Hide outer collapsible block and embed result
            AddLineNumbers();
            base.InsertCssSourceCode();
            return "<div class=\"sh_result\"><pre>"
                + AddCollapsibleBlock("") + _result.ToString() + EndCollapsibleBlock()
                + "</pre></div>";
        }

        #region Parsing private methods

        /// <summary>
        /// Collect an identifier.
        /// Pre-condition: _chars>0
        /// </summary>
        /// <returns>Formatted HTML for identifier</returns>
        private string AddIdentifier()
        {
            Debug.Assert(_chars > 0);
            string token = Substring(-_chars);
            _chars = 0;
            Debug.Assert(token.Length > 0);

            // keyword?
            if (_keywords.Contains(token))
            {
                // directive? (#region or #endregion)
                if (token[0] == '#')
                {
                    bool region = (token == "#region");
                    _end = FindNext(NewLine(), _start, 0);
                    token = AddSpan(token, "net_directive")
                        + AddHyperlinks(Substring());
                    token = (region ? AddCollapsibleBlock(token)
                        : token + EndCollapsibleBlock());
                    _start = _end;
                }
                else
                    token = AddSpan(token, "net_key");
            }

            // type name?
            else if (_types.Contains(token))
                token = AddSpan(token, "net_type");

            // any other identifier is HTML-encoded
            else
                token = Encode(token);

            _result.Append(token);
            return token;
        }

        /// <summary>
        /// Collect a character value '...'
        /// Pre-condition: current char is '
        /// </summary>
        /// <returns>Formatted HTML for char value</returns>
        private string AddCharValue()
        {
            Debug.Assert(Current() == '\'');
            _start++;

            for (_end = _start;
                CharAt(_end) != '\0' && (CharAt(_end) != '\''
                || CharAt(_end - 1) == '\\' && CharAt(_end - 2) != '\\');
                _end++) ;

            string token = Substring();
            _result.Append(AddSpan("'" + Encode(token) + "'", "net_string"));
            _start = _end + 1;
            return token;
        }

        /// <summary>
        /// Collect a string value "..." or verbatim (multi-line) @"..."
        /// Pre-condition: starts by " or @"
        /// </summary>
        /// <returns>Formatted HTML for string value</returns>
        private string AddStringValue()
        {
            Debug.Assert(Current() == '"'
                || Current() == '@' && Current(1) == '"');
            bool verbatim = (Current() == '@');
            _start++;

            // @"..." verbatim string value continues till "
            // or odd number of consecutive " found
            if (verbatim)
            {
                _start++;
                bool evenQuotes = true;
                for (_end = _start;
                    CharAt(_end) != '\0' && (CharAt(_end) != '\"'
                    || (evenQuotes = !evenQuotes) || CharAt(_end + 1) == '\"');
                    _end++) ;
            }
            // "..." string value continue till "
            // not preceeded by single \ (\\" is actually \ followed by ")
            else
                for (_end = _start;
                    CharAt(_end) != '\0' && (CharAt(_end) != '\"'
                    || CharAt(_end - 1) == '\\' && CharAt(_end - 2) != '\\');
                    _end++) ;

            string token = Substring();
            _result.Append(AddSpan((verbatim ? "@" : "") + "\""
                + AddHyperlinks(token) + "\"", "net_string"));
            _start = _end + 1;
            return token;
        }

        /// <summary>
        /// Collect single-line comment // ...
        /// </summary>
        /// <returns>Formatted HTML for comment</returns>
        private string AddSingleLineComment()
        {
            _start += 2;

            // collects all text from // till end-of-line
            _end = FindNext(NewLine(), _start, 0);
            string token = Substring();

            if (!_showComments)
            {
                // if skip comments, just replace everything with an empty line
                _result.Append(NewLine());
                _end++;
            }
            else
                _result.Append(AddSpan("//" + AddHyperlinks(token), "net_comment"));
            _start = _end + 1;
            return token;
        }

        /// <summary>
        /// Collect multi-line comment /* ... */
        /// </summary>
        /// <returns>Formatted HTML for comment</returns>
        private string AddMultiLineComment()
        {
            _start += 2;

            // collects all text from /* till next */
            _end = FindNext("*/", _start, 2);
            string token = Substring();

            if (_showComments)
                _result.Append(AddSpan("/*" + AddHyperlinks(token), "net_comment"));

            _start = _end + 1;
            return token;
        }

        /// <summary>
        /// Collect documentation (single-line) comment /// ...
        /// Detect and format <...> documentation tags inside
        /// </summary>
        /// <returns>Formatted HTML for comment</returns>
        private string AddDocumentationComment()
        {
            _start += 3;

            // collects all text from /// till end-of-line
            _end = FindNext(NewLine(), _start, 0);
            string token = Substring();

            if (!_showComments)
            {
                // if skip comments, just replace everything with an empty line
                _result.Append(NewLine());
                _end++;
            }
            else
            {
                // /// and <...> XML doc tags inside are shown in light gray
                _result.Append(AddSpan("///", "net_xml"));
                for (int end = _end; _start < end; _start++)
                {
                    if (Current() == '<')
                    {
                        // show regular comment text
                        _result.Append(AddSpan(
                            AddHyperlinks(Substring(-_chars)), "net_comment"));
                        _chars = 0;

                        // show <...> XML tag content
                        _end = FindNext(">", _start, 1);
                        _result.Append(AddSpan(
                            AddHyperlinks(Substring()), "net_xml"));
                        _start = _end - 1;
                    }
                    else
                        _chars++;
                    _end = end;
                }

                // show last regular comment text left
                if (_chars > 0)
                {
                    _result.Append(AddSpan(
                        AddHyperlinks(Substring(-_chars)), "net_comment"));
                    _chars = 0;
                }
            }

            _start = _end + 1;
            return token;
        }
        #endregion
    }
}
