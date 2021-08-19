using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using System.Collections.Generic;
using System.Xml;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       安全相关的命令对象模块
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("Security")]
	internal class WriterCommandModuleSecurity : WriterCommandModule
	{
		/// <summary>
		///       启用自动登录及用户信息
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SetUserInfo")]
		protected void SetUserInfo(object sender, WriterCommandEventArgs e)
		{
			SetAutoLogin(sender, e);
		}

		/// <summary>
		///       启用自动登录
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SetAutoLogin")]
		protected void SetAutoLogin(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				CurrentUserInfo currentUserInfo = null;
				if (e.Parameter is UserLoginInfo)
				{
					UserLoginInfo userLoginInfo = (UserLoginInfo)e.Parameter;
					currentUserInfo = new CurrentUserInfo();
					currentUserInfo.ClientName = userLoginInfo.ClientName;
					currentUserInfo.Name = userLoginInfo.Name;
					currentUserInfo.ID = userLoginInfo.ID;
					currentUserInfo.PermissionLevel = userLoginInfo.PermissionLevel;
				}
				if (e.Parameter is CurrentUserInfo)
				{
					currentUserInfo = (CurrentUserInfo)e.Parameter;
				}
				e.Host.Services.AddService(typeof(CurrentUserInfo), currentUserInfo);
				if (e.EditorControl != null)
				{
					e.EditorControl.AutoUserLogin = true;
					e.EditorControl.DocumentOptions.SecurityOptions.EnablePermission = true;
					e.EditorControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
				}
			}
		}

		/// <summary>
		///       清除用户留下的痕迹
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ClearUserTrace", FunctionID = GEnum6.const_130)]
		protected void ClearUserTrace(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.IsAdministrator && !e.EditorControl.RuntimeReadonly && e.Document != null && e.Document.Selection.Length != 0);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent() && e.Document.Selection.Length != 0)
				{
					Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
					foreach (XTextElement item in e.Document.Selection)
					{
						DocumentContentStyle parent = item.RuntimeStyle.Parent;
						if (parent.CreatorIndex >= 0 || parent.DeleterIndex >= 0)
						{
							parent = (DocumentContentStyle)parent.Clone();
							parent.DisableDefaultValue = false;
							parent.CreatorIndex = -1;
							parent.DeleterIndex = -1;
							dictionary[item] = e.Document.ContentStyles.GetStyleIndex(parent);
						}
					}
					if (e.Document.Selection.Cells != null)
					{
						foreach (XTextTableCellElement cell in e.Document.Selection.Cells)
						{
							DocumentContentStyle parent = cell.RuntimeStyle.Parent;
							if (parent.CreatorIndex >= 0 || parent.DeleterIndex >= 0)
							{
								parent = (DocumentContentStyle)parent.Clone();
								parent.DisableDefaultValue = false;
								parent.CreatorIndex = -1;
								parent.DeleterIndex = -1;
								dictionary[cell] = e.Document.ContentStyles.GetStyleIndex(parent);
							}
						}
					}
					if (dictionary.Count > 0)
					{
						e.Result = true;
						e.Document.EditorSetElementStyle(dictionary, logUndo: true, causeUpdateLayout: true, e.Name);
					}
				}
			}
		}

		/// <summary>
		///       撤销所有用户修订
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("RejectUserTrace", ReturnValueType = typeof(bool))]
		protected void RejectUserTrace(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.IsAdministrator && !e.EditorControl.RuntimeReadonly);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					if (e.EditorControl.RejectUserTrace())
					{
						e.RefreshLevel = UIStateRefreshLevel.All;
						e.Result = true;
					}
					else
					{
						e.Result = false;
					}
				}
			}
		}

		/// <summary>
		///       提交所有的用户痕迹信息，删除所有被逻辑删除的元素，清空痕迹信息。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("CommitUserTrace", ReturnValueType = typeof(bool))]
		protected void CommitUserTrace(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.IsAdministrator && !e.EditorControl.RuntimeReadonly);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					if (e.Document.CommitUserTrace())
					{
						e.Document.Modified = true;
						e.EditorControl.RefreshDocument();
						e.RefreshLevel = UIStateRefreshLevel.All;
						e.Document.OnDocumentContentChanged();
						e.Result = true;
					}
					else
					{
						e.Result = false;
					}
				}
			}
		}

		/// <summary>
		///       获取文档的用户痕迹列表的XML串行化字符串
		///       </summary>
		/// <remarks>
		///       提供此命令的原因是因为在GOOGLE CHROME浏览器下访问writerControl.UserTrackInfos属性出了问题。
		///       </remarks>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("GetUserTrackInfosXMLString", ReturnValueType = typeof(string))]
		protected void GetUserTrackInfosXML(object sender, WriterCommandEventArgs e)
		{
			int num = 2;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.UserTrackInfos != null && e.EditorControl.UserTrackInfos.Count > 0);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.EditorControl.UserTrackInfos.Refresh();
				UserTrackInfoList userTrackInfos = e.EditorControl.UserTrackInfos;
				XmlDocument xmlDocument = new XmlDocument();
				XmlElement xmlElement = xmlDocument.CreateElement("UserTrackInfoList");
				foreach (UserTrackInfo item in userTrackInfos)
				{
					XmlElement xmlElement2 = xmlDocument.CreateElement("UserTrackInfo");
					xmlElement2.SetAttribute("CommentText", item.CommentText);
					xmlElement2.SetAttribute("ViewIndexForNavigating", item.Elements.FirstElement.ViewIndex.ToString());
					xmlElement2.SetAttribute("InfoType", item.InfoType.ToString());
					xmlElement2.SetAttribute("PermissionLevel", item.PermissionLevel.ToString());
					xmlElement2.SetAttribute("SaveTime", item.SaveTime.ToString());
					xmlElement2.SetAttribute("StdTitle", item.StdTitle);
					xmlElement2.SetAttribute("Text", item.Text);
					xmlElement2.SetAttribute("UserID", item.UserID);
					xmlElement2.SetAttribute("UserName", item.UserName);
					xmlElement.AppendChild(xmlElement2);
				}
				xmlDocument.AppendChild(xmlElement);
				e.Result = xmlDocument.OuterXml;
			}
		}

		/// <summary>
		///       为文档正文内容附加当前用户痕迹信息。
		///       </summary>
		/// <remarks>
		///       本命令能将正文中所有的没有标记用户痕迹的文档元素标记为当前用户创建的。
		///       本记录会清空历史操作记录。命令返回一个布尔值，表示是否修改了文档内容,可能会设置文档的Modified属性值。
		///       </remarks>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AttachCurrentUserTrackToBodyContent", ReturnValueType = typeof(bool))]
		protected void AttachCurrentUserTrackToBodyContent(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				int currentIndex = e.Document.UserHistories.CurrentIndex;
				bool flag = false;
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(e.Document.Body);
				domTreeNodeEnumerable.ExcludeCharElement = false;
				domTreeNodeEnumerable.ExcludeParagraphFlag = false;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (item.RuntimeStyle.CreatorIndex == -1 && item.RuntimeStyle.DeleterIndex == -1)
					{
						item.Style.CreatorIndex = currentIndex;
						flag = true;
					}
				}
				if (flag)
				{
					if (e.Document.UndoList != null)
					{
						e.Document.UndoList.Clear();
					}
					e.Document.Modified = true;
					e.Document.OnDocumentContentChanged();
					e.EditorControl.RefreshDocument();
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
				e.Result = flag;
			}
		}

		/// <summary>
		///       清除所有的用户痕迹
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ClearAllUserTrace", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_130)]
		protected void ClearAllUserTrace(object sender, WriterCommandEventArgs e)
		{
			int num = 18;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.IsAdministrator && !e.EditorControl.RuntimeReadonly);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (!e.UIStartEditContent())
				{
					return;
				}
				bool flag = false;
				foreach (DocumentContentStyle style in e.Document.ContentStyles.Styles)
				{
					if (style.CreatorIndex >= 0 || style.DeleterIndex >= 0)
					{
						style.method_29("CreatorIndex");
						style.method_29("DeleterIndex");
						flag = true;
					}
				}
				if (e.Document.UserHistories.Count > 0)
				{
					e.Document.UserHistories.Clear();
					e.Document.method_111();
				}
				if (flag)
				{
					if (e.Document.UndoList != null)
					{
						e.Document.UndoList.Clear();
					}
					e.EditorControl.RefreshDocument();
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
				e.Result = flag;
			}
		}

		/// <summary>
		///       设置后台运行模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BackgroundMode", FunctionID = GEnum6.const_123)]
		protected void BackgroundMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = e.EditorControl.BackgroundMode;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				bool bool_ = !e.EditorControl.BackgroundMode;
				bool_ = WriterUtils.smethod_41(e.Parameter, bool_);
				e.EditorControl.BackgroundMode = bool_;
				e.EditorControl.DocumentOptions.BehaviorOptions.EnableLogUndo = !bool_;
				e.EditorControl.CommandControler.InvalidateCommandState();
				e.Result = e.EditorControl.BackgroundMode;
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       管理员模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AdministratorViewMode", FunctionID = GEnum6.const_122)]
		protected void AdministratorViewMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = e.EditorControl.IsAdministrator;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				bool bool_ = !e.EditorControl.IsAdministrator;
				bool_ = WriterUtils.smethod_41(e.Parameter, bool_);
				e.EditorControl.IsAdministrator = bool_;
				e.EditorControl.InnerViewControl.Invalidate();
				e.Result = e.EditorControl.IsAdministrator;
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}
	}
}
