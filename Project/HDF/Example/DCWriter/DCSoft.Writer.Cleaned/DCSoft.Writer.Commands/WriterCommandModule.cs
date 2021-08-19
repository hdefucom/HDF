using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       功能模块对象
	///       </summary>
	[DCPublishAPI]
	[DocumentComment]
	[ComVisible(false)]
	public class WriterCommandModule : IDisposable
	{
		private string string_0 = null;

		private bool bool_0 = true;

		private WriterCommandList writerCommandList_0 = null;

		/// <summary>
		///       模块名称
		///       </summary>
		[DCPublishAPI]
		public virtual string Name
		{
			get
			{
				if (string_0 == null)
				{
					WriterCommandDescriptionAttribute writerCommandDescriptionAttribute = (WriterCommandDescriptionAttribute)Attribute.GetCustomAttribute(GetType(), typeof(WriterCommandDescriptionAttribute), inherit: true);
					if (writerCommandDescriptionAttribute != null)
					{
						string_0 = writerCommandDescriptionAttribute.Name;
					}
				}
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       模块是否可用
		///       </summary>
		[DCPublishAPI]
		public bool Enabled
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       本模块包含的动作对象列表
		///       </summary>
		[DCPublishAPI]
		public virtual WriterCommandList Commands
		{
			get
			{
				if (writerCommandList_0 == null)
				{
					writerCommandList_0 = method_0();
				}
				return writerCommandList_0;
			}
		}

		/// <summary>
		///       启动模块
		///       </summary>
		/// <param name="args">事件参数</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public virtual bool Start(WriterCommandEventArgs args)
		{
			return true;
		}

		/// <summary>
		///       关闭模块
		///       </summary>
		/// <param name="args">
		/// </param>
		[DCPublishAPI]
		public virtual void Close(WriterCommandEventArgs args)
		{
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		[DCPublishAPI]
		public virtual void Dispose()
		{
		}

		protected WriterCommandList method_0()
		{
			GClass104 gClass = GClass104.smethod_2(GetType(), bool_0: false);
			WriterCommandList writerCommandList = new WriterCommandList();
			foreach (GClass133 item in gClass.method_8())
			{
				WriterCommandDelegate writerCommandDelegate = new WriterCommandDelegate();
				writerCommandDelegate.FunctionID = item.method_0();
				writerCommandDelegate.Name = item.method_4();
				writerCommandDelegate.ShortcutKey = item.method_10();
				writerCommandDelegate.ToolbarImage = item.method_16();
				writerCommandDelegate.Description = item.method_14();
				writerCommandDelegate.Descriptor = item;
				writerCommandDelegate.Priority = item.method_12();
				writerCommandDelegate.Handler = (WriterCommandEventHandler)Delegate.CreateDelegate(typeof(WriterCommandEventHandler), this, item.method_24());
				writerCommandDelegate.Module = this;
				writerCommandList.AddCommand(writerCommandDelegate);
			}
			return writerCommandList;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return "Module:" + Name;
		}

		/// <summary>
		///       对文档元素的修改应用到编辑器中
		///       </summary>
		/// <param name="eargs">文档元素属性修改事件参数</param>
		/// <param name="cmdArgs">编辑器命令事件参数</param>
		public static void ApplyElementPropertiesResult(ElementPropertiesEditEventArgs eargs, WriterCommandEventArgs cmdArgs)
		{
			int num = 0;
			if (eargs == null)
			{
				throw new ArgumentNullException("ears");
			}
			if (eargs.ContentEffect == ContentEffects.None)
			{
				return;
			}
			if (eargs.Element == null)
			{
				throw new ArgumentNullException("eargs.Element");
			}
			if (cmdArgs == null)
			{
				throw new ArgumentNullException("cmdArgs");
			}
			XTextContainerElement xTextContainerElement = null;
			Dictionary<XTextContentElement, int> dictionary = new Dictionary<XTextContentElement, int>();
			if (eargs.Document.ScriptEngine != null)
			{
				eargs.Document.ScriptEngine.UpdateScriptText();
			}
			foreach (XTextElement element in eargs.Elements)
			{
				if (eargs.Method == ElementPropertiesEditMethod.Edit)
				{
					switch (eargs.ContentEffect)
					{
					case ContentEffects.Content:
						element.UpdateContentVersion();
						break;
					case ContentEffects.Display:
						element.UpdateContentVersion();
						element.InvalidateView();
						break;
					case ContentEffects.Layout:
						xTextContainerElement = ((xTextContainerElement != null) ? WriterUtils.smethod_56(xTextContainerElement, element) : ((element is XTextTableRowElement) ? element.Parent : ((!(element is XTextContainerElement)) ? element.Parent : ((XTextContainerElement)element))));
						element.UpdateContentVersion();
						element.InvalidateView();
						if (element is XTextImageElement)
						{
							XTextImageElement xTextImageElement = (XTextImageElement)element;
							CheckImageSizeWhenInsertImage(cmdArgs.Document, xTextImageElement, xTextImageElement.RuntimeKeepWidthHeightRate, xTextImageElement.Parent);
						}
						if (element is XTextTableCellElement)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)element;
							dictionary[xTextTableCellElement] = 0;
							foreach (XTextLine privateLine in xTextTableCellElement.PrivateLines)
							{
								privateLine.InvalidateState = true;
							}
							xTextTableCellElement.method_55();
							xTextTableCellElement.EditorRefreshView();
						}
						else if (element is XTextTableRowElement)
						{
							XTextTableElement xTextTableElement = (XTextTableElement)element.Parent;
							XTextContentElement contentElement = xTextTableElement.ContentElement;
							contentElement.method_29(xTextTableElement.OwnerLine, xTextTableElement.OwnerLine);
							dictionary[contentElement] = xTextTableElement.FirstContentElement.ViewIndex;
						}
						else
						{
							XTextContentElement contentElement = element.ContentElement;
							contentElement.method_29(element.OwnerLine, element.OwnerLine);
							dictionary[contentElement] = element.ViewIndex;
						}
						break;
					}
				}
			}
			if (xTextContainerElement is XTextContentElement)
			{
				XTextContentElement xTextContentElement = (XTextContentElement)xTextContainerElement;
				if (dictionary.ContainsKey(xTextContentElement))
				{
					xTextContentElement.vmethod_36(bool_22: true);
					dictionary.Remove(xTextContentElement);
				}
			}
			foreach (XTextContentElement key in dictionary.Keys)
			{
				key.vmethod_36(bool_22: true);
				key.method_31(dictionary[key]);
			}
			if (eargs.ContentEffect == ContentEffects.Layout)
			{
				xTextContainerElement.method_25();
			}
			if (eargs.Method == ElementPropertiesEditMethod.Edit)
			{
				foreach (XTextElement element2 in eargs.Elements)
				{
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = element2.OwnerDocument;
					contentChangedEventArgs.Element = element2;
					contentChangedEventArgs.LoadingDocument = false;
					if (element2 is XTextContainerElement)
					{
						((XTextContainerElement)element2).method_23(contentChangedEventArgs);
					}
					else
					{
						element2.Parent.method_23(contentChangedEventArgs);
					}
				}
			}
			if (eargs.UpdateExpressionResult && cmdArgs.Document.ExpressionExecuter != null)
			{
				cmdArgs.Document.ExpressionExecuter.imethod_7(eargs.Element);
			}
			cmdArgs.Document.Modified = true;
			cmdArgs.Document.OnDocumentContentChanged();
		}

		/// <summary>
		///       根据插入点所在的容器来修正表格的总宽度
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="table">表格元素</param>
		public static void CheckTableWidthWhenInsertTable(XTextDocument document, XTextTableElement table)
		{
			if (document.Options.EditOptions.FixWidthWhenInsertTable)
			{
				XTextContainerElement container = null;
				int elementIndex = 0;
				document.Content.GetCurrentPositionInfo(out container, out elementIndex);
				container = container.ContentElement;
				float num = Math.Min(container.ClientWidth, table.TableWidth);
				foreach (XTextTableColumnElement column in table.Columns)
				{
					if (column.ZeroWidth)
					{
						num = container.ClientWidth;
						break;
					}
				}
				if (num != table.TableWidth)
				{
					table.method_43(num);
				}
			}
			else
			{
				foreach (XTextTableColumnElement column2 in table.Columns)
				{
					if (column2.ZeroWidth)
					{
						column2.Width = document.Options.ViewOptions.MinTableColumnWidth;
					}
				}
			}
		}

		/// <summary>
		///       根据插入点所在的容器来修正图片元素的大小
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="element">图片元素</param>
		/// <param name="keepWidthHeightRate">保持长宽比</param>
		/// <param name="container">容器元素对象</param>
		public static void CheckImageSizeWhenInsertImage(XTextDocument document, XTextElement element, bool keepWidthHeightRate, XTextContainerElement container)
		{
			if (document.Options.EditOptions.FixSizeWhenInsertImage)
			{
				if (container == null)
				{
					int elementIndex = 0;
					document.Content.GetCurrentPositionInfo(out container, out elementIndex);
				}
				container = container.ContentElement;
				SizeF sizeF_ = new SizeF(element.Width, element.Height);
				float height = 100000f;
				if (container.DocumentContentElement.ContentPartyStyle == PageContentPartyStyle.Body && document.CurrentPage != null)
				{
					height = document.CurrentPage.StandartPapeBodyHeight - 10f;
				}
				sizeF_ = MathCommon.smethod_4(new SizeF(container.ClientWidth - document.PixelToDocumentUnit(2f), height), sizeF_, keepWidthHeightRate);
				element.Width = sizeF_.Width;
				element.Height = sizeF_.Height;
			}
		}
	}
}
