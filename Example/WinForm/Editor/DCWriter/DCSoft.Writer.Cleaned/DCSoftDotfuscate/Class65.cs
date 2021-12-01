#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	internal class Class65
	{
		public const string string_0 = "dcwriterchecksession";

		public const string string_1 = "dcwritersessiontimeoutflag";

		public const string string_2 = "dcwritergetstringresources";

		public const string string_3 = "dcwritertestsessiontimeout";

		public const string string_4 = "dcwritergetnoneimage";

		public static readonly string string_5 = "WebBufferImageIds";

		internal static readonly int int_0 = Environment.TickCount;

		public static readonly string string_6 = "4325435425432";

		public static readonly string string_7 = "getpageimage";

		public static readonly string string_8 = "getresource";

		public static readonly string string_9 = "getcabcontent";

		public static readonly string string_10 = "getassembly";

		public static readonly string string_11 = "name";

		public static readonly string string_12 = "version";

		public static readonly string string_13 = "serviceflag";

		public static readonly string string_14 = "method";

		public static readonly string string_15 = "pageindex";

		public static readonly string string_16 = "sessionname";

		public static readonly string string_17 = "showmarginline";

		public static readonly string string_18 = "documentindex";

		internal static readonly string string_19 = "getdcwriterresource";

		public static readonly string string_20 = "contenttype";

		public static readonly string string_21 = "dcwriteruploadfile";

		public static readonly string string_22 = "querydcwriteruploadfileprogress";

		public static readonly string string_23 = "getdcwriterbufferedimage";

		public static readonly string string_24 = "dcquerylistitems";

		public static readonly string string_25 = "dcgetmedicalexpressionimage";

		internal static readonly string string_26 = "getdcflagimage";

		public static readonly string string_27 = "dcwritersavefilecontent";

		public static readonly string string_28 = "dcwritergetdocumenthtml";

		public static readonly string string_29 = "dcwritersaveselectioncontent";

		public static readonly string string_30 = "dcwritergetfulldocumenthtml";

		public static readonly string string_31 = "dcwritergetxmlcontent";

		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		private static Dictionary<Color, byte[]> dictionary_1 = new Dictionary<Color, byte[]>();

		public static bool smethod_0(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 16;
			if (httpRequest_0 == null)
			{
				throw new ArgumentNullException("InnerHandleService.request");
			}
			if (httpResponse_0 == null)
			{
				throw new ArgumentNullException("InnerHandleService.response");
			}
			if (httpSessionState_0 == null)
			{
				throw new ArgumentNullException("InnerHandleService.session");
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString["dcwritergetnoneimage"]))
			{
				return smethod_1(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString["dcwritertest"]))
			{
				httpResponse_0.Output.Write("dcwriter_test_ok");
				httpResponse_0.End();
				return true;
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString["dcwritergetwhiteimage"]))
			{
				using (Bitmap bitmap = new Bitmap(10, 10))
				{
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.Clear(Color.White);
					}
					MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Jpeg);
					httpResponse_0.ContentType = "image/jpeg";
					memoryStream.WriteTo(httpResponse_0.OutputStream);
				}
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString["dcwritertestsessiontimeout"]))
			{
				return smethod_2(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString["dcwritergetstringresources"]))
			{
				return smethod_3(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_30]))
			{
				return smethod_4(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_28]))
			{
				return smethod_5(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_29]))
			{
				return smethod_7(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_27]))
			{
				return smethod_8(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_26]))
			{
				return smethod_9(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_25]))
			{
				return smethod_10(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_24]))
			{
				return smethod_19(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_23]))
			{
				return smethod_18(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString["dcwriterqueryuploadprogress"]))
			{
				return smethod_17(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_21]))
			{
				return smethod_16(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_19]))
			{
				return smethod_15(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (!string.IsNullOrEmpty(httpRequest_0.QueryString[string_31]))
			{
				return smethod_6(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			string a = httpRequest_0.QueryString[string_14];
			if (httpRequest_0.QueryString[string_13] != string_6)
			{
				return false;
			}
			if (a == string_10)
			{
				return smethod_14(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (a == string_7)
			{
				return smethod_13(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (a == string_8)
			{
				return smethod_11(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			if (a == string_9)
			{
				return smethod_12(httpRequest_0, httpResponse_0, httpSessionState_0);
			}
			httpResponse_0.OutputStream.Close();
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_1(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 0;
			string text = httpRequest_0.QueryString["dcwritergetnoneimage"];
			int num2 = 100;
			int num3 = 100;
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(',');
				if (array.Length >= 2)
				{
					try
					{
						num2 = Convert.ToInt32(array[0]);
						num3 = Convert.ToInt32(array[1]);
					}
					catch
					{
					}
				}
			}
			using (Bitmap bitmap = new Bitmap(num2, num3))
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.Clear(Color.White);
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Center;
						stringFormat.LineAlignment = StringAlignment.Center;
						string noImage = WriterStrings.NoImage;
						graphics.DrawString(noImage, Control.DefaultFont, Brushes.Red, new RectangleF(0f, 0f, num2, num3), stringFormat);
					}
				}
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				memoryStream.Close();
				byte[] array2 = memoryStream.ToArray();
				httpResponse_0.ContentType = "image/png";
				httpResponse_0.OutputStream.Write(array2, 0, array2.Length);
			}
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_2(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 11;
			string s = httpRequest_0.QueryString["dcwritertestsessiontimeout"];
			int result = 0;
			if (int.TryParse(s, out result) && WebWriterControl.smethod_7(result) != null)
			{
				httpResponse_0.Output.Write("sessionok");
			}
			httpResponse_0.Output.Write("dcwritersessiontimeoutflag");
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_3(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 13;
			Hashtable hashtable = new Hashtable();
			Type typeFromHandle = typeof(WriterStrings);
			PropertyInfo[] properties = typeFromHandle.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.PropertyType.Equals(typeof(string)) && propertyInfo.Name.StartsWith("JS_"))
				{
					hashtable[propertyInfo.Name] = propertyInfo.GetValue(null, null);
				}
			}
			string value = GClass112.smethod_0(hashtable, bool_0: true);
			httpResponse_0.Output.Write(value);
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_4(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 11;
			httpResponse_0.ContentType = "text/html";
			string text = httpRequest_0.QueryString[string_30];
			if (text == null)
			{
				text = "";
			}
			string fileFormat = httpRequest_0.QueryString["fileformat"];
			string s = httpRequest_0.QueryString["controlinstanceid"];
			string value = httpRequest_0.QueryString["contentrendermode"];
			WebWriterControlRenderMode webWriterControlRenderMode = (WebWriterControlRenderMode)Enum.Parse(typeof(WebWriterControlRenderMode), value);
			int result = 0;
			string s2 = "<script language='javascript'>if( window.frameElement.parentNode != null ){window.frameElement.parentNode.HiddenAppProcessing();};alert('加载文件 " + text.Replace("\\", "\\\\") + " 失败。');</script>";
			if (int.TryParse(s, out result))
			{
				Class52 @class = WebWriterControl.smethod_7(result);
				if (@class != null)
				{
					@class.method_17(bool_7: true);
					WriterReadFileContentEventHandler writerReadFileContentEventHandler = (WriterReadFileContentEventHandler)GClass38.smethod_0(@class.method_22(), @class.method_24(), "EventReadFileContent");
					if (writerReadFileContentEventHandler != null)
					{
						WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(null, null, null, text, null);
						writerReadFileContentEventArgs.FileFormat = fileFormat;
						writerReadFileContentEventHandler(null, writerReadFileContentEventArgs);
						byte[] resultBinary = writerReadFileContentEventArgs.GetResultBinary();
						if (resultBinary != null && resultBinary.Length > 0)
						{
							XTextDocument xTextDocument = new XTextDocument();
							xTextDocument.Options = @class.method_53();
							MemoryStream memoryStream = new MemoryStream(resultBinary);
							xTextDocument.Load(memoryStream, null);
							memoryStream.Close();
							xTextDocument.FileName = writerReadFileContentEventArgs.FileName;
							xTextDocument.FileFormat = writerReadFileContentEventArgs.FileFormat;
							xTextDocument.CheckPageRefreshed();
							if (@class.method_53() != null)
							{
								xTextDocument.Options = @class.method_53();
							}
							switch (webWriterControlRenderMode)
							{
							case WebWriterControlRenderMode.NormalHtmlEditable:
								s2 = @class.method_49(new XTextDocumentList(xTextDocument));
								@class.method_51();
								break;
							case WebWriterControlRenderMode.PagePreviewHtml:
								s2 = @class.method_50(new XTextDocumentList(xTextDocument), bool_7: false);
								@class.method_51();
								break;
							}
							xTextDocument.Dispose();
						}
					}
				}
				else
				{
					s2 = "<!-- dcwritersessiontimeoutflag --><script language='javascript'>alert('" + WriterStrings.WebControlStateInvalidate + "');</script>";
				}
			}
			httpResponse_0.Write(s2);
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_5(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 2;
			httpResponse_0.ContentType = "text/html";
			string text = httpRequest_0.QueryString[string_28];
			string fileFormat = httpRequest_0.QueryString["fileformat"];
			string s = httpRequest_0.QueryString["controlinstanceid"];
			int result = 0;
			string s2 = "<script language='javascript'>alert('加载文件 " + text + " 失败。');</script>";
			if (int.TryParse(s, out result))
			{
				Class52 @class = WebWriterControl.smethod_7(result);
				if (@class != null)
				{
					@class.method_17(bool_7: false);
					WriterReadFileContentEventHandler writerReadFileContentEventHandler = (WriterReadFileContentEventHandler)GClass38.smethod_0(@class.method_22(), @class.method_24(), "EventReadFileContent");
					if (writerReadFileContentEventHandler != null)
					{
						WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(null, null, null, text, null);
						writerReadFileContentEventArgs.FileFormat = fileFormat;
						writerReadFileContentEventHandler(null, writerReadFileContentEventArgs);
						byte[] resultBinary = writerReadFileContentEventArgs.GetResultBinary();
						if (resultBinary != null && resultBinary.Length > 0)
						{
							XTextDocument xTextDocument = new XTextDocument();
							MemoryStream memoryStream = new MemoryStream(resultBinary);
							xTextDocument.Load(memoryStream, null);
							memoryStream.Close();
							if (@class.method_53() != null)
							{
								xTextDocument.Options = @class.method_53();
							}
							s2 = @class.method_36(xTextDocument);
							@class.method_51();
							xTextDocument.Dispose();
						}
					}
				}
				else
				{
					s2 = "<!-- dcwritersessiontimeoutflag --><script language='javascript'>alert('控件状态不对,可能是服务器回话超时,加载文件失败。');</script>";
				}
			}
			httpResponse_0.Write(s2);
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_6(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			XTextDocumentList xTextDocumentList = WebWriterControl.smethod_4(httpRequest_0);
			XTextDocument xTextDocument = null;
			if (xTextDocumentList != null && xTextDocumentList.Count > 0)
			{
				xTextDocument = xTextDocumentList[0];
			}
			httpResponse_0.Write(xTextDocument.XMLText);
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_7(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 11;
			bool flag = false;
			XTextDocumentList xTextDocumentList = WebWriterControl.smethod_4(httpRequest_0);
			if (xTextDocumentList != null && xTextDocumentList.Count > 0)
			{
				foreach (XTextDocument item in xTextDocumentList)
				{
					string text = httpRequest_0.QueryString["pagename"];
					string text2 = httpRequest_0.QueryString["controlname"];
					WriterSaveFileContentEventHandler writerSaveFileContentEventHandler = (WriterSaveFileContentEventHandler)GClass38.smethod_0(text, text2, "EventSaveSelectionContent");
					if (writerSaveFileContentEventHandler != null)
					{
						MemoryStream memoryStream = new MemoryStream();
						item.Save(memoryStream, null);
						memoryStream.Close();
						WriterSaveFileContentEventArgs writerSaveFileContentEventArgs = new WriterSaveFileContentEventArgs(null, item, item, item.FileName, null, memoryStream.ToArray());
						writerSaveFileContentEventArgs.UserParameter = httpRequest_0.QueryString["userparameter"];
						writerSaveFileContentEventHandler(null, writerSaveFileContentEventArgs);
						flag = writerSaveFileContentEventArgs.Result;
					}
				}
			}
			httpResponse_0.Output.Write(flag.ToString().ToLower());
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_8(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 10;
			bool flag = false;
			XTextDocumentList xTextDocumentList = WebWriterControl.smethod_4(httpRequest_0);
			if (xTextDocumentList != null && xTextDocumentList.Count > 0)
			{
				foreach (XTextDocument item in xTextDocumentList)
				{
					string text = httpRequest_0.QueryString["pagename"];
					string text2 = httpRequest_0.QueryString["controlname"];
					WriterSaveFileContentEventHandler writerSaveFileContentEventHandler = (WriterSaveFileContentEventHandler)GClass38.smethod_0(text, text2, "EventSaveFileContent");
					if (writerSaveFileContentEventHandler != null)
					{
						MemoryStream memoryStream = new MemoryStream();
						bool modified = item.Modified;
						item.Save(memoryStream, null);
						item.Modified = modified;
						memoryStream.Close();
						WriterSaveFileContentEventArgs writerSaveFileContentEventArgs = new WriterSaveFileContentEventArgs(null, item, item, item.FileName, null, memoryStream.ToArray());
						writerSaveFileContentEventArgs.UserParameter = httpRequest_0.QueryString["userparameter"];
						writerSaveFileContentEventHandler(null, writerSaveFileContentEventArgs);
						flag = writerSaveFileContentEventArgs.Result;
					}
				}
			}
			httpResponse_0.Output.Write(flag.ToString().ToLower());
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_9(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 6;
			httpResponse_0.AddHeader("Last-Modified", new DateTime(1980, 1, 1, 1, 1, 1).ToString("U", DateTimeFormatInfo.InvariantInfo));
			httpResponse_0.ContentType = "image/png";
			string text = httpRequest_0.QueryString[string_26];
			if (string.IsNullOrEmpty(text))
			{
				return true;
			}
			text = text.Replace("@", "#");
			Color color = ColorTranslator.FromHtml(text);
			byte[] array = null;
			if (dictionary_1.ContainsKey(color))
			{
				array = dictionary_1[color];
			}
			else
			{
				using (Bitmap bitmap = new Bitmap(3, 3))
				{
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.Clear(color);
					}
					MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Png);
					memoryStream.Close();
					array = memoryStream.ToArray();
					dictionary_1[color] = array;
				}
			}
			httpResponse_0.OutputStream.Write(array, 0, array.Length);
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_10(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 13;
			httpResponse_0.ContentType = "png/image";
			int result = 0;
			if (!int.TryParse(httpRequest_0.QueryString["width"], out result))
			{
				result = 100;
			}
			result = Math.Max(30, result);
			int result2 = 0;
			if (!int.TryParse(httpRequest_0.QueryString["height"], out result2))
			{
				result2 = 50;
			}
			result2 = Math.Max(30, result2);
			MedicalExpressionStyle medicalExpressionStyle_ = (MedicalExpressionStyle)Enum.Parse(typeof(MedicalExpressionStyle), httpRequest_0.QueryString[string_25]);
			string text = httpRequest_0.QueryString["text"];
			if (text == null)
			{
				text = "";
			}
			using (Bitmap bitmap = new Bitmap(result, result2))
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.Clear(Color.White);
					GClass24 gClass = new GClass24();
					XFontValue xFontValue = new XFontValue();
					string text2 = httpRequest_0.QueryString["fontsize"];
					if (!string.IsNullOrEmpty(text2))
					{
						float result3 = xFontValue.Size;
						if (float.TryParse(text2, out result3))
						{
							xFontValue.Size = result3;
						}
					}
					gClass.method_3(xFontValue);
					gClass.method_72(medicalExpressionStyle_);
					string[] string_ = text.Split(',');
					gClass.method_6(string_);
					gClass.method_74(new DCGraphics(graphics), new RectangleF(0f, 0f, result, result2));
				}
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Png);
				memoryStream.Close();
				byte[] array = memoryStream.ToArray();
				httpResponse_0.OutputStream.Write(array, 0, array.Length);
			}
			return true;
		}

		private static bool smethod_11(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			string text = httpRequest_0.QueryString[string_11];
			if (!string.IsNullOrEmpty(text))
			{
				Stream manifestResourceStream = typeof(WebWriterControl).Assembly.GetManifestResourceStream(text);
				if (manifestResourceStream != null)
				{
					byte[] array = FileHelper.LoadBinaryStream(manifestResourceStream);
					manifestResourceStream.Close();
					httpResponse_0.OutputStream.Write(array, 0, array.Length);
					httpResponse_0.OutputStream.Close();
					httpResponse_0.End();
				}
			}
			return true;
		}

		private static bool smethod_12(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 15;
			byte[] array = WebWriterControl.smethod_0();
			if (array != null)
			{
				httpResponse_0.ContentType = "application/x-msdownload";
				httpResponse_0.AddHeader("Content-Disposition", "attachment;filename=DCWriterWeb." + WebWriterControl.DefaultVersion + ".cab");
				httpResponse_0.OutputStream.Write(array, 0, array.Length);
				httpResponse_0.OutputStream.Close();
				httpResponse_0.End();
			}
			return true;
		}

		private static bool smethod_13(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 1;
			string text = httpRequest_0.QueryString[string_16];
			string s = httpRequest_0.QueryString[string_15];
			string s2 = httpRequest_0.QueryString[string_18];
			int result = 0;
			int result2 = 0;
			if (!string.IsNullOrEmpty(text) && int.TryParse(s, out result) && int.TryParse(s2, out result2))
			{
				XTextDocumentList xTextDocumentList = httpSessionState_0[text] as XTextDocumentList;
				if (xTextDocumentList != null && result2 >= 0 && result2 < xTextDocumentList.Count)
				{
					XTextDocument xTextDocument = xTextDocumentList[result2];
					xTextDocument.CheckPageRefreshed();
					if (result >= 0 && result < xTextDocument.Pages.Count)
					{
						MemoryStream memoryStream = new MemoryStream();
						using (Bitmap bitmap = xTextDocument.CreatePageBmp(result, httpRequest_0.QueryString[string_17] == "true"))
						{
							bitmap.Save(memoryStream, ImageFormat.Png);
						}
						httpResponse_0.ContentType = "png/image";
						memoryStream.WriteTo(httpResponse_0.OutputStream);
					}
				}
			}
			httpResponse_0.OutputStream.Close();
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_14(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			string location = typeof(WebWriterControl).Assembly.Location;
			httpResponse_0.ContentType = "application/x-msdownload";
			httpResponse_0.WriteFile(location);
			httpResponse_0.OutputStream.Close();
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_15(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 10;
			string text = httpRequest_0.QueryString[string_19];
			byte[] array = FileHelper.LoadResourceBinary(typeof(WebWriterControl), text);
			if (array == null)
			{
				if (text.EndsWith(".js", StringComparison.CurrentCultureIgnoreCase))
				{
					httpResponse_0.Write(" alert('未找到资源{" + text + "}');");
					httpResponse_0.OutputStream.Close();
					httpResponse_0.End();
					return false;
				}
				if (text.EndsWith(".htm", StringComparison.CurrentCultureIgnoreCase) || text.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase))
				{
					httpResponse_0.Write("<script language='javascript'> alert('未找到资源{" + text + "}');</script>");
					httpResponse_0.OutputStream.Close();
					httpResponse_0.End();
					return false;
				}
				Debug.WriteLine("未找到资源 " + text);
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = 0;
			for (int num3 = text.Length - 1; num3 >= 0; num3--)
			{
				if (text[num3] == '.')
				{
					num2++;
				}
				if (num2 == 2)
				{
					break;
				}
				stringBuilder.Insert(0, text[num3]);
			}
			if (text.EndsWith(".js", StringComparison.CurrentCultureIgnoreCase))
			{
				httpResponse_0.Buffer = true;
				httpResponse_0.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
				httpResponse_0.Expires = 0;
				httpResponse_0.CacheControl = "no-cache";
				httpResponse_0.AppendHeader("Pragma", "No-Cache");
				httpResponse_0.AddHeader("Content-Disposition", "attachment;filename=" + stringBuilder.ToString());
			}
			string text2 = httpRequest_0.QueryString[string_20];
			if (string.IsNullOrEmpty(text2))
			{
				if (text.EndsWith(".js", StringComparison.CurrentCultureIgnoreCase))
				{
					text2 = "text/javascript";
				}
				else if (text.EndsWith(".htm", StringComparison.CurrentCultureIgnoreCase) || text.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase))
				{
					text2 = "text/html";
				}
				else if (text.EndsWith(".css", StringComparison.CurrentCultureIgnoreCase))
				{
					text2 = "text/css";
				}
				else if (text.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
				{
					text2 = "image/png";
				}
				else if (text.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase))
				{
					text2 = "image/jpg";
				}
			}
			if (!string.IsNullOrEmpty(text2))
			{
				httpResponse_0.ContentType = text2;
			}
			httpResponse_0.BinaryWrite(array);
			httpResponse_0.OutputStream.Close();
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_16(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 6;
			string text = httpRequest_0.Form["fileid"];
			string a = httpRequest_0.QueryString[string_21];
			if (string.IsNullOrEmpty(text))
			{
				text = Environment.TickCount.ToString();
			}
			if (httpRequest_0.HttpMethod == "POST")
			{
				if (!string.IsNullOrEmpty(text) && dictionary_0.ContainsKey(text))
				{
					dictionary_0.Remove(text);
				}
				foreach (string file in httpRequest_0.Files)
				{
					HttpPostedFile httpPostedFile = httpRequest_0.Files[file];
					if (httpPostedFile.ContentLength != 0)
					{
						byte[] array = new byte[1024];
						MemoryStream memoryStream = new MemoryStream();
						string fileName = Path.GetFileName(httpPostedFile.FileName);
						using (Stream stream = httpPostedFile.InputStream)
						{
							while (true)
							{
								int num2 = stream.Read(array, 0, array.Length);
								if (num2 <= 0)
								{
									break;
								}
								memoryStream.Write(array, 0, num2);
								string value = "up:" + string.Format(WriterStrings.Uploading_Name_Size_Total, fileName, FileHelper.FormatByteSize(memoryStream.Length), FileHelper.FormatByteSize(httpPostedFile.ContentLength));
								if (!string.IsNullOrEmpty(text))
								{
									dictionary_0[text] = value;
								}
							}
						}
						array = memoryStream.ToArray();
						if (!string.IsNullOrEmpty(text))
						{
							httpSessionState_0[text] = array;
						}
						string value2 = "ok";
						if (GClass339.smethod_14(array) || GClass339.smethod_13(array) || GClass339.smethod_15(array) || GClass339.smethod_12(array))
						{
							try
							{
								memoryStream.Position = 0L;
								Image image = Image.FromStream(memoryStream);
								value2 = "ok:" + image.Width + ":" + image.Height;
							}
							catch (Exception ex)
							{
								Debug.WriteLine(ex.Message);
							}
						}
						dictionary_0[text] = value2;
					}
				}
				httpResponse_0.AddHeader("Location", "about:blank");
				httpResponse_0.Write("<html><head><script language='javascript'>window.location='about:blank';</script></head><body>上传成功</body></html>");
			}
			else
			{
				httpResponse_0.ContentType = "text/html";
				if (a == "1")
				{
					string s = FileHelper.LoadResourceString(typeof(WebWriterControl), "DCSoft.Writer.Controls.Resources.DCUploadFile.htm", Encoding.UTF8);
					httpResponse_0.Write(s);
				}
				else
				{
					string s = FileHelper.LoadResourceString(typeof(WebWriterControl), "DCSoft.Writer.Controls.Resources.DCUploadFileSimple.htm", Encoding.UTF8);
					httpResponse_0.Write(s);
				}
			}
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_17(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 13;
			string key = httpRequest_0.QueryString["dcwriterqueryuploadprogress"];
			string text = "";
			text = ((!dictionary_0.ContainsKey(key)) ? "none" : dictionary_0[key]);
			httpResponse_0.ContentType = "text/html";
			httpResponse_0.Output.Write(text);
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_18(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 3;
			string name = httpRequest_0.QueryString[string_23];
			byte[] array = httpSessionState_0[name] as byte[];
			if (array != null && array.Length > 0)
			{
				httpResponse_0.ContentType = "image/png";
				httpResponse_0.OutputStream.Write(array, 0, array.Length);
				httpResponse_0.OutputStream.Close();
			}
			httpResponse_0.End();
			return true;
		}

		private static bool smethod_19(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			httpResponse_0.ContentType = "text/plain";
			StringBuilder sb = new StringBuilder();
			new StringWriter(sb);
			string s = "[]";
			string pageName = httpRequest_0.QueryString["pagename"];
			string controlName = httpRequest_0.QueryString["controlname"];
			QueryListItemsEventHandler queryListItemsEventHandler = (QueryListItemsEventHandler)GClass38.smethod_0(pageName, controlName, "EventQueryListItems");
			if (queryListItemsEventHandler != null)
			{
				string listSourceName = httpRequest_0.QueryString[string_24];
				QueryListItemsEventArgs queryListItemsEventArgs = new QueryListItemsEventArgs(null, null, null);
				queryListItemsEventArgs.PageName = pageName;
				queryListItemsEventArgs.ControlName = controlName;
				queryListItemsEventArgs.ListSourceName = listSourceName;
				queryListItemsEventHandler(null, queryListItemsEventArgs);
				if (queryListItemsEventArgs.Result != null && queryListItemsEventArgs.Result.Count > 0)
				{
					s = GClass112.smethod_1(queryListItemsEventArgs.Result, bool_0: true);
				}
			}
			httpResponse_0.Write(s);
			httpResponse_0.End();
			return true;
		}
	}
}
