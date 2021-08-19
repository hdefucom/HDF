using System;
using System.Collections;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYKBObjectList : ObjectByteList
	{
		public KB_List RootKBList = null;

		public bool ClearSEQ = true;

		public override bool ObjectToBytes(object objData, ref int ClassID)
		{
			if (objData is KB_List)
			{
				ClassID = 0;
				KB_List kB_List = (KB_List)objData;
				AppendObjectData(kB_List.SEQ);
				AppendObjectData(kB_List.ParentSEQ);
				AppendObjectData(kB_List.Name);
				AppendObjectData(kB_List.Desc);
				AppendObjectData(kB_List.ListIndex);
				AppendObjectData(kB_List.ListSQL);
				AppendObjectData(kB_List.KBStyle);
				AppendObjectData(kB_List.KBGroup);
				return true;
			}
			if (objData is KB_Item)
			{
				ClassID = 1;
				KB_Item kB_Item = (KB_Item)objData;
				AppendObjectData(kB_Item.ItemSEQ);
				AppendObjectData(kB_Item.KBSEQ);
				AppendObjectData(kB_Item.ItemText);
				AppendObjectData(kB_Item.ItemValue);
				AppendObjectData(kB_Item.ItemDesc);
				AppendObjectData(kB_Item.ListIndex);
				AppendObjectData(kB_Item.ItemStyle);
				return true;
			}
			if (objData is ET_Document)
			{
				ClassID = 2;
				ET_Document eT_Document = (ET_Document)objData;
				AppendObjectData(eT_Document.ObjectID);
				AppendObjectData(eT_Document.ObjectName);
				AppendObjectData(eT_Document.ObjectType);
				AppendObjectData(eT_Document.ObjectData);
				return true;
			}
			if (objData is KBSection)
			{
				ClassID = 3;
				KBSection kBSection = (KBSection)objData;
				AppendObjectData(kBSection.KBSEQ);
				AppendObjectData(kBSection.OwnerSection);
				return true;
			}
			return false;
		}

		public override object BytesToObject(int ClassID)
		{
			switch (ClassID)
			{
			case 0:
			{
				KB_List kB_List = new KB_List();
				kB_List.SEQ = ReadString();
				kB_List.ParentSEQ = ReadString();
				kB_List.Name = ReadString();
				kB_List.Desc = ReadString();
				kB_List.ListIndex = ReadInt32();
				kB_List.ListSQL = ReadString();
				kB_List.KBStyle = ReadInt32();
				kB_List.KBGroup = ReadString();
				return kB_List;
			}
			case 1:
			{
				KB_Item kB_Item = new KB_Item();
				kB_Item.ItemSEQ = ReadInt32();
				kB_Item.KBSEQ = ReadString();
				kB_Item.ItemText = ReadString();
				kB_Item.ItemValue = ReadString();
				kB_Item.ItemDesc = ReadString();
				kB_Item.ListIndex = ReadInt32();
				kB_Item.ItemStyle = ReadInt32();
				return kB_Item;
			}
			case 2:
			{
				ET_Document eT_Document = new ET_Document();
				eT_Document.ObjectID = ReadString();
				eT_Document.ObjectName = ReadString();
				eT_Document.ObjectType = ReadInt32();
				eT_Document.ObjectData = ReadString();
				return eT_Document;
			}
			case 3:
			{
				KBSection kBSection = new KBSection();
				kBSection.KBSEQ = ReadString();
				kBSection.OwnerSection = ReadString();
				return kBSection;
			}
			default:
				return null;
			}
		}

		private KB_List GetKBList(string strSEQ)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (current is KB_List && (current as KB_List).SEQ == strSEQ)
					{
						return current as KB_List;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}
	}
}
