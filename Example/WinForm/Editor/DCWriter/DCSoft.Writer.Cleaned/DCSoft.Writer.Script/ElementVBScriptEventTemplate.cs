using DCSoft.Writer.Dom;
using System.ComponentModel;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       文档元素的脚本事件模板
	///       </summary>
	[ToolboxItem(false)]
	internal class ElementVBScriptEventTemplate : ElementEventTemplate
	{
		private XTextDocument xtextDocument_0 = null;

		private XTextElement xtextElement_0 = null;

		private VBScriptItemList vbscriptItemList_0 = null;

		public override bool HasAfterPaint => method_0("AfterPaint");

		public override bool HasBeforePaint => method_0("BeforePaint");

		public override bool HasContentChanged => method_0("ContentChanged");

		public override bool HasContentChanging => method_0("ContentChanging");

		public override bool HasExpression => method_0("Expression");

		public override bool HasGotFocus => method_0("GotFocus");

		public override bool HasKeyDown => method_0("KeyDown");

		public override bool HasKeyPress => method_0("KeyPress");

		public override bool HasKeyUp => method_0("KeyUp");

		public override bool HasLoad => method_0("Load");

		public override bool HasLostFocus => method_0("LostFocus");

		public override bool HasMouseClick => method_0("MouseClick");

		public override bool HasMouseDblClick => method_0("MouseDblClick");

		public override bool HasMouseDown => method_0("MouseDown");

		public override bool HasMouseEnter => method_0("MouseEnter");

		public override bool HasMouseLeave => method_0("MouseLeave");

		public override bool HasMouseMove => method_0("MouseMove");

		public override bool HasMouseUp => method_0("MouseUp");

		public override bool HasValidated => method_0("Validated");

		public override bool HasValidating => method_0("Validating");

		public override bool HasQueryState => method_0("EventName_QueryState");

		public static ElementVBScriptEventTemplate smethod_0(XTextElement xtextElement_1)
		{
			if (xtextElement_1 == null)
			{
				return null;
			}
			VBScriptItemList vBScriptItemList = null;
			if (xtextElement_1 is XTextContainerElement)
			{
				vBScriptItemList = ((XTextContainerElement)xtextElement_1).ScriptItems;
			}
			else if (xtextElement_1 is XTextObjectElement)
			{
				vBScriptItemList = ((XTextObjectElement)xtextElement_1).ScriptItems;
			}
			if (!(vBScriptItemList?.IsEmpty ?? true))
			{
				ElementVBScriptEventTemplate elementVBScriptEventTemplate = new ElementVBScriptEventTemplate();
				elementVBScriptEventTemplate.xtextDocument_0 = xtextElement_1.OwnerDocument;
				elementVBScriptEventTemplate.xtextElement_0 = xtextElement_1;
				elementVBScriptEventTemplate.vbscriptItemList_0 = vBScriptItemList;
				return elementVBScriptEventTemplate;
			}
			return null;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		private ElementVBScriptEventTemplate()
		{
		}

		public override void OnAfterPaint(object sender, ElementPaintEventArgs e)
		{
			method_1("AfterPaint", e);
		}

		public override void OnBeforePaint(object sender, ElementPaintEventArgs e)
		{
			method_1("BeforePaint", e);
		}

		public override void OnContentChanged(object sender, ContentChangedEventArgs e)
		{
			method_1("ContentChanged", e);
		}

		public override void OnContentChanging(object sender, ContentChangingEventArgs e)
		{
			method_1("ContentChanging", e);
		}

		public override void OnExpression(object sender, ElementExpressionEventArgs e)
		{
			method_1("Expression", e);
		}

		public override void OnGotFocus(object sender, ElementEventArgs e)
		{
			method_1("GotFocus", e);
		}

		public override void OnKeyDown(object sender, ElementKeyEventArgs e)
		{
			method_1("KeyDown", e);
		}

		public override void OnKeyPress(object sender, ElementKeyEventArgs e)
		{
			method_1("KeyPress", e);
		}

		public override void OnKeyUp(object sender, ElementKeyEventArgs e)
		{
			method_1("KeyUp", e);
		}

		public override void OnLoad(object sender, ElementLoadEventArgs e)
		{
			method_1("Load", e);
		}

		public override void OnLostFocus(object sender, ElementEventArgs e)
		{
			method_1("LostFocus", e);
		}

		public override void OnMouseClick(object sender, ElementMouseEventArgs e)
		{
			method_1("MouseClick", e);
		}

		public override void OnMouseDblClick(object sender, ElementMouseEventArgs e)
		{
			method_1("MouseDblClick", e);
		}

		public override void OnMouseDown(object sender, ElementMouseEventArgs e)
		{
			method_1("MouseDown", e);
		}

		public override void OnMouseEnter(object sender, ElementEventArgs e)
		{
			method_1("MouseEnter", e);
		}

		public override void OnMouseLeave(object sender, ElementEventArgs e)
		{
			method_1("MouseLeave", e);
		}

		public override void OnMouseMove(object sender, ElementMouseEventArgs e)
		{
			method_1("MouseMove", e);
		}

		public override void OnMouseUp(object sender, ElementMouseEventArgs e)
		{
			method_1("MouseUp", e);
		}

		public override void OnValidated(object sender, ElementEventArgs e)
		{
			method_1("Validated", e);
		}

		public override void OnValidating(object sender, ElementValidatingEventArgs e)
		{
			method_1("Validating", e);
		}

		public override void OnQueryState(object sender, ElementQueryStateEventArgs e)
		{
			method_1("EventName_QueryState", e);
		}

		private bool method_0(string string_0)
		{
			return vbscriptItemList_0 != null && vbscriptItemList_0.ContainsScript(string_0);
		}

		private void method_1(string string_0, object object_0)
		{
			int num = 12;
			if (xtextDocument_0.ScriptEngine == null)
			{
				return;
			}
			VBScriptItem vBScriptItem = vbscriptItemList_0[string_0];
			if (vBScriptItem != null)
			{
				string scriptMethodName = vBScriptItem.ScriptMethodName;
				if (xtextDocument_0.AppHost.Debuger != null && xtextDocument_0.Options.BehaviorOptions.DebugMode)
				{
					string text = string.Format(WriterStringsCore.ExecuteEventScript_Element_Event_Method, xtextElement_0.GetType().Name + ":" + xtextElement_0.ID, string_0, scriptMethodName);
					xtextDocument_0.AppHost.Debuger.WriteLine(text);
				}
				xtextDocument_0.ScriptEngine.CurrentElement = xtextElement_0;
				xtextDocument_0.ScriptEngine.EventArgs = object_0;
				xtextDocument_0.ScriptEngine.ExecuteSub(xtextElement_0, scriptMethodName);
				xtextDocument_0.ScriptEngine.CurrentElement = null;
				xtextDocument_0.ScriptEngine.EventArgs = null;
			}
		}
	}
}
