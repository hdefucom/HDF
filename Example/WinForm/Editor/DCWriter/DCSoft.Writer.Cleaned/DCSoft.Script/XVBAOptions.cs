using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       VB.NET script engine's options
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[Editor("DCSoft.Script.ScriptOptionsEditor", typeof(UITypeEditor))]
	public class XVBAOptions : ICloneable
	{
		private MyStringList myImportNamespaces = new MyStringList();

		private DotNetAssemblyInfoList myReferenceAssemblies = new DotNetAssemblyInfoList();

		[NonSerialized]
		private MyStringList myInnerReferenceAssemblies = new MyStringList();

		/// <summary>
		///       namespace imported in source code
		///       </summary>
		[XmlArrayItem("Namespace", typeof(string))]
		public MyStringList ImportNamespaces
		{
			get
			{
				return myImportNamespaces;
			}
			set
			{
				myImportNamespaces = value;
			}
		}

		/// <summary>
		///       reference assemblies
		///       </summary>
		[XmlArrayItem("DotNetAssemblyInfo", typeof(DotNetAssemblyInfo))]
		public DotNetAssemblyInfoList ReferenceAssemblies
		{
			get
			{
				return myReferenceAssemblies;
			}
			set
			{
				myReferenceAssemblies = value;
			}
		}

		/// <summary>
		///       custom reference assemblies
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public MyStringList InnerReferenceAssemblies
		{
			get
			{
				if (myInnerReferenceAssemblies == null)
				{
					myInnerReferenceAssemblies = new MyStringList();
				}
				return myInnerReferenceAssemblies;
			}
			set
			{
				myInnerReferenceAssemblies = value;
			}
		}

		public XVBAOptions()
		{
			myImportNamespaces.Add("System");
			myImportNamespaces.Add("Microsoft.VisualBasic");
			myReferenceAssemblies.AddStandard("mscorlib");
			myReferenceAssemblies.AddStandard("System");
			myReferenceAssemblies.AddStandard("System.Data");
			myReferenceAssemblies.AddStandard("System.Xml");
			myReferenceAssemblies.AddStandard("System.Drawing");
			myReferenceAssemblies.AddStandard("System.Windows.Forms");
			myReferenceAssemblies.AddStandard("Microsoft.VisualBasic");
		}

		object ICloneable.Clone()
		{
			XVBAOptions xVBAOptions = new XVBAOptions();
			if (myImportNamespaces != null)
			{
				xVBAOptions.myImportNamespaces = myImportNamespaces.Clone();
			}
			if (myReferenceAssemblies != null)
			{
				xVBAOptions.myReferenceAssemblies = myReferenceAssemblies.Clone();
			}
			if (myInnerReferenceAssemblies != null)
			{
				xVBAOptions.myInnerReferenceAssemblies = myInnerReferenceAssemblies.Clone();
			}
			return xVBAOptions;
		}

		public XVBAOptions Clone()
		{
			return (XVBAOptions)((ICloneable)this).Clone();
		}

		public override string ToString()
		{
			return string.Format(ScriptStrings.VBAOptionString_RefCount_NSCount, myReferenceAssemblies.Count, myImportNamespaces.Count);
		}

		/// <summary>
		///       get assembly's file name
		///       </summary>
		/// <param name="SourceType">object type</param>
		public static string GetReferenceAssemblyByType(Type SourceType)
		{
			int num = 4;
			if (SourceType == null)
			{
				throw new ArgumentNullException("SourceType");
			}
			Uri uri = new Uri(SourceType.Assembly.CodeBase);
			string text = null;
			if (uri.Scheme == Uri.UriSchemeFile)
			{
				return uri.LocalPath;
			}
			return SourceType.Assembly.Location;
		}
	}
}
