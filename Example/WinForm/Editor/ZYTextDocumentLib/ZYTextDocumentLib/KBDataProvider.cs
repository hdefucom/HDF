using System.Data;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public abstract class KBDataProvider
	{
		public class DataItem
		{
			public string Name;

			public string DisplayName;

			public string Value;
		}

		private NameValueList myValues = new NameValueList();

		private NameValueList myParams = new NameValueList();

		private IDbConnection myConnection = null;

		private string strProviderName;

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

		public string ProviderName
		{
			get
			{
				return strProviderName;
			}
			set
			{
				strProviderName = value;
			}
		}

		public string GetParam(string strName)
		{
			return myParams.GetValue(strName);
		}

		public void SetParam(string strName, string strValue)
		{
			myParams.SetValue(strName, strValue);
		}

		public string GetValue(string strName)
		{
			return myValues.GetValue(strName);
		}

		public bool SaveValue(string strName, string strValue)
		{
			myValues.SetValue(strName, strValue);
			return false;
		}

		public bool Init()
		{
			string text = null;
			text = "\r\nSelect \r\n   MAINMR.BIRTHDAY ,\r\n   MAINMR.BLOODTYPE ,\r\n   MAINMR.BORNPLACE ,\r\n   MAINMR.BUILDDATE ,\r\n   MAINMR.BUILDER ,\r\n   MAINMR.CORPS ,\r\n   MAINMR.COUNTRY ,\r\n   MAINMR.CULTURELEVEL ,\r\n   MAINMR.FEETYPE ,\r\n   MAINMR.HEIGHT ,\r\n   MAINMR.HOMEADDRESS ,\r\n   MAINMR.HOMEPHONE ,\r\n   MAINMR.ISARMYMAN ,\r\n   MAINMR.JOB ,\r\n   MAINMR.LASTDATE ,\r\n   MAINMR.MARRIED ,\r\n   MAINMR.MCNUM ,\r\n   MAINMR.MCTYPE ,\r\n   MAINMR.MODIFIER ,\r\n   MAINMR.MRID ,\r\n   MAINMR.NAMESPELL ,\r\n   MAINMR.NATION ,\r\n   MAINMR.NATIVEPLACE ,\r\n   MAINMR.PAPERNUM ,\r\n   MAINMR.PAPERTYPE ,\r\n   MAINMR.PATIENTNAME ,\r\n   MAINMR.POSITION ,\r\n   MAINMR.POSTZIP ,\r\n   MAINMR.RACE ,\r\n   MAINMR.RELATIONADDR ,\r\n   MAINMR.RELATIONNAME ,\r\n   MAINMR.RELATIONPHONE ,\r\n   MAINMR.RELATIONSHIP ,\r\n   MAINMR.RELATIONZIPCODE ,\r\n   MAINMR.SEX ,\r\n   MAINMR.SICKID ,\r\n   MAINMR.STATUS ,\r\n   MAINMR.WEIGHT ,\r\n   MAINMR.WITHINFOCODE ,\r\n   MAINMR.WORKADDRESS ,\r\n   MAINMR.WORKFOR ,\r\n   MAINMR.WORKPHONE1 ,\r\n   MAINMR.WORKPHONE2 ,\r\n   MAINMR.WORKZIPCODE\r\nFrom \r\n\tMAINMR\r\nWhere MRID = '[MRID]'";
			text = myParams.FixVariableString(text);
			return true;
		}
	}
}
