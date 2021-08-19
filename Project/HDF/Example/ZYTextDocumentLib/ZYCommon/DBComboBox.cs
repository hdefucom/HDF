using System;
using System.Data;
using System.Windows.Forms;

namespace ZYCommon
{
	public class DBComboBox : ComboBox
	{
		private class ComboBoxItem
		{
			internal string Text;

			internal string Value;

			public override string ToString()
			{
				return (Text == null) ? "<NULL>" : Text;
			}
		}

		private string strSQL = null;

		private IDbConnection myConnection = null;

		private bool bolLoaded = false;

		private bool bolAutoLoad = true;

		public bool AutoLoad
		{
			get
			{
				return bolAutoLoad;
			}
			set
			{
				bolAutoLoad = value;
			}
		}

		public IDbConnection Connection
		{
			get
			{
				return myConnection;
			}
			set
			{
				myConnection = value;
			}
		}

		public string SQL
		{
			get
			{
				return strSQL;
			}
			set
			{
				strSQL = value;
			}
		}

		public new string SelectedValue
		{
			get
			{
				return (base.SelectedItem as ComboBoxItem)?.Value;
			}
			set
			{
				if (!bolLoaded)
				{
					LoadItems();
				}
				foreach (ComboBoxItem item in base.Items)
				{
					if (item.Value == value)
					{
						base.SelectedItem = item;
						break;
					}
				}
			}
		}

		public void AddItem(string strValue, string strText)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Value = strValue;
			comboBoxItem.Text = strText;
			base.Items.Add(comboBoxItem);
		}

		public bool LoadItems(string[] strItems)
		{
			if (strItems != null && strItems.Length % 2 == 0)
			{
				for (int i = 0; i < strItems.Length; i += 2)
				{
					ComboBoxItem comboBoxItem = new ComboBoxItem();
					comboBoxItem.Value = strItems[i];
					comboBoxItem.Text = strItems[i + 1];
					base.Items.Add(comboBoxItem);
				}
				bolLoaded = true;
				return true;
			}
			return false;
		}

		public void LoadItems()
		{
			base.Items.Clear();
			if (!StringCommon.isBlankString(strSQL) && myConnection != null && myConnection.State == ConnectionState.Open)
			{
				using (IDbCommand dbCommand = myConnection.CreateCommand())
				{
					dbCommand.CommandText = strSQL;
					IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
					while (dataReader.Read())
					{
						ComboBoxItem comboBoxItem = new ComboBoxItem();
						comboBoxItem.Text = (dataReader.IsDBNull(0) ? null : dataReader[0].ToString());
						if (dataReader.FieldCount > 1)
						{
							comboBoxItem.Value = (dataReader.IsDBNull(1) ? null : dataReader[1].ToString());
						}
						else
						{
							comboBoxItem.Value = comboBoxItem.Text;
						}
						base.Items.Add(comboBoxItem);
					}
					dataReader.Close();
					bolLoaded = true;
				}
			}
		}

		protected override void OnDropDown(EventArgs e)
		{
			if (!bolLoaded && bolAutoLoad)
			{
				LoadItems();
			}
			base.OnDropDown(e);
		}
	}
}
