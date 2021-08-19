using DCSoftDotfuscate;

namespace DCSoft.Writer.Dom.Undo
{
	/// <summary>
	///       重做、撤销表格结构信息
	///       </summary>
	internal class XTextUndoTableInfo : XTextUndoBase
	{
		private Class116 class116_0 = null;

		private Class116 class116_1 = null;

		internal Class116 OldTableInfo
		{
			get
			{
				return class116_0;
			}
			set
			{
				class116_0 = value;
			}
		}

		internal Class116 NewTableInfo
		{
			get
			{
				return class116_1;
			}
			set
			{
				class116_1 = value;
			}
		}

		internal void method_0()
		{
			if (class116_0 != null && class116_1 != null)
			{
				foreach (Class117 item in class116_0.method_12())
				{
					foreach (Class119 item2 in item.method_8())
					{
						foreach (Class117 item3 in class116_1.method_12())
						{
							foreach (Class119 item4 in item3.method_8())
							{
								if (item2.method_0() != item4.method_0())
								{
									continue;
								}
								XTextElement[] array = item2.method_16();
								XTextElement[] array2 = item4.method_16();
								if (array != null && array2 != null && array.Length == array2.Length)
								{
									bool flag = true;
									for (int i = 0; i < array.Length; i++)
									{
										if (array[i] != array2[i])
										{
											flag = false;
											break;
										}
									}
									if (flag)
									{
										item2.method_17(null);
										item4.method_17(null);
									}
								}
								goto IL_014f;
							}
						}
						IL_014f:;
					}
				}
			}
		}

		public override void Undo(GEventArgs3 args)
		{
			XTextTableElement xTextTableElement = OldTableInfo.method_2();
			xTextTableElement.method_49(OldTableInfo);
		}

		public override void Redo(GEventArgs3 args)
		{
			class116_1.method_2().method_49(NewTableInfo);
		}
	}
}
