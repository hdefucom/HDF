using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Native
{
	/// <summary>
	///       操作系统内置的图标，本类型是API函数SHGetStockIconInfo的一个封装.本类型内部缓存图标对象。
	///       </summary>
	[ComVisible(false)]
	public static class SHStockIcons
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct Struct110
		{
			public uint uint_0;

			public IntPtr intptr_0;

			public int int_0;

			public int int_1;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string string_0;
		}

		[Flags]
		private enum Enum33 : uint
		{
			flag_0 = 0x0,
			flag_1 = 0x100,
			flag_2 = 0x4000,
			flag_3 = 0x8000,
			flag_4 = 0x10000,
			flag_5 = 0x0,
			flag_6 = 0x1,
			flag_7 = 0x4
		}

		[ComVisible(false)]
		private enum Enum34 : uint
		{
			const_0 = 0u,
			const_1 = 1u,
			const_2 = 2u,
			const_3 = 3u,
			const_4 = 4u,
			const_5 = 5u,
			const_6 = 6u,
			const_7 = 7u,
			const_8 = 8u,
			const_9 = 9u,
			const_10 = 10u,
			const_11 = 11u,
			const_12 = 12u,
			const_13 = 13u,
			const_14 = 0xF,
			const_15 = 0x10,
			const_16 = 17u,
			const_17 = 22u,
			const_18 = 23u,
			const_19 = 28u,
			const_20 = 29u,
			const_21 = 30u,
			const_22 = 0x1F,
			const_23 = 0x20,
			const_24 = 40u,
			const_25 = 47u,
			const_26 = 49u,
			const_27 = 50u,
			const_28 = 51u,
			const_29 = 52u,
			const_30 = 53u,
			const_31 = 54u,
			const_32 = 55u,
			const_33 = 56u,
			const_34 = 57u,
			const_35 = 58u,
			const_36 = 59u,
			const_37 = 60u,
			const_38 = 61u,
			const_39 = 62u,
			const_40 = 0x3F,
			const_41 = 0x40,
			const_42 = 65u,
			const_43 = 66u,
			const_44 = 67u,
			const_45 = 68u,
			const_46 = 69u,
			const_47 = 70u,
			const_48 = 71u,
			const_49 = 72u,
			const_50 = 73u,
			const_51 = 74u,
			const_52 = 75u,
			const_53 = 76u,
			const_54 = 77u,
			const_55 = 78u,
			const_56 = 79u,
			const_57 = 80u,
			const_58 = 81u,
			const_59 = 82u,
			const_60 = 83u,
			const_61 = 84u,
			const_62 = 85u,
			const_63 = 86u,
			const_64 = 87u,
			const_65 = 88u,
			const_66 = 89u,
			const_67 = 90u,
			const_68 = 91u,
			const_69 = 92u,
			const_70 = 93u,
			const_71 = 94u,
			const_72 = 95u,
			const_73 = 96u,
			const_74 = 97u,
			const_75 = 98u,
			const_76 = 99u,
			const_77 = 100u,
			const_78 = 101u,
			const_79 = 102u,
			const_80 = 103u,
			const_81 = 104u,
			const_82 = 105u,
			const_83 = 106u,
			const_84 = 132u,
			const_85 = 133u,
			const_86 = 134u,
			const_87 = 135u,
			const_88 = 136u,
			const_89 = 137u,
			const_90 = 138u,
			const_91 = 139u,
			const_92 = 140u,
			const_93 = 175u
		}

		private static Dictionary<Enum34, Icon> dictionary_0 = new Dictionary<Enum34, Icon>();

		public static Icon SIID_DOCNOASSOC => smethod_2(Enum34.const_0);

		public static Icon SIID_DOCASSOC => smethod_2(Enum34.const_1);

		public static Icon SIID_APPLICATION => smethod_2(Enum34.const_2);

		public static Icon SIID_FOLDER => smethod_2(Enum34.const_3);

		public static Icon SIID_FOLDEROPEN => smethod_2(Enum34.const_4);

		public static Icon SIID_DRIVE525 => smethod_2(Enum34.const_5);

		public static Icon SIID_DRIVE35 => smethod_2(Enum34.const_6);

		public static Icon SIID_DRIVEREMOVE => smethod_2(Enum34.const_7);

		public static Icon SIID_DRIVEFIXED => smethod_2(Enum34.const_8);

		public static Icon SIID_DRIVENET => smethod_2(Enum34.const_9);

		public static Icon SIID_DRIVENETDISABLED => smethod_2(Enum34.const_10);

		public static Icon SIID_DRIVECD => smethod_2(Enum34.const_11);

		public static Icon SIID_DRIVERAM => smethod_2(Enum34.const_12);

		public static Icon SIID_WORLD => smethod_2(Enum34.const_13);

		public static Icon SIID_SERVER => smethod_2(Enum34.const_14);

		public static Icon SIID_PRINTER => smethod_2(Enum34.const_15);

		public static Icon SIID_MYNETWORK => smethod_2(Enum34.const_16);

		public static Icon SIID_FIND => smethod_2(Enum34.const_17);

		public static Icon SIID_HELP => smethod_2(Enum34.const_18);

		public static Icon SIID_SHARE => smethod_2(Enum34.const_19);

		public static Icon SIID_LINK => smethod_2(Enum34.const_20);

		public static Icon SIID_SLOWFILE => smethod_2(Enum34.const_21);

		public static Icon SIID_RECYCLER => smethod_2(Enum34.const_22);

		public static Icon SIID_RECYCLERFULL => smethod_2(Enum34.const_23);

		public static Icon SIID_MEDIACDAUDIO => smethod_2(Enum34.const_24);

		public static Icon SIID_LOCK => smethod_2(Enum34.const_25);

		public static Icon SIID_AUTOLIST => smethod_2(Enum34.const_26);

		public static Icon SIID_PRINTERNET => smethod_2(Enum34.const_27);

		public static Icon SIID_SERVERSHARE => smethod_2(Enum34.const_28);

		public static Icon SIID_PRINTERFAX => smethod_2(Enum34.const_29);

		public static Icon SIID_PRINTERFAXNET => smethod_2(Enum34.const_30);

		public static Icon SIID_PRINTERFILE => smethod_2(Enum34.const_31);

		public static Icon SIID_STACK => smethod_2(Enum34.const_32);

		public static Icon SIID_MEDIASVCD => smethod_2(Enum34.const_33);

		public static Icon SIID_STUFFEDFOLDER => smethod_2(Enum34.const_34);

		public static Icon SIID_DRIVEUNKNOWN => smethod_2(Enum34.const_35);

		public static Icon SIID_DRIVEDVD => smethod_2(Enum34.const_36);

		public static Icon SIID_MEDIADVD => smethod_2(Enum34.const_37);

		public static Icon SIID_MEDIADVDRAM => smethod_2(Enum34.const_38);

		public static Icon SIID_MEDIADVDRW => smethod_2(Enum34.const_39);

		public static Icon SIID_MEDIADVDR => smethod_2(Enum34.const_40);

		public static Icon SIID_MEDIADVDROM => smethod_2(Enum34.const_41);

		public static Icon SIID_MEDIACDAUDIOPLUS => smethod_2(Enum34.const_42);

		public static Icon SIID_MEDIACDRW => smethod_2(Enum34.const_43);

		public static Icon SIID_MEDIACDR => smethod_2(Enum34.const_44);

		public static Icon SIID_MEDIACDBURN => smethod_2(Enum34.const_45);

		public static Icon SIID_MEDIABLANKCD => smethod_2(Enum34.const_46);

		public static Icon SIID_MEDIACDROM => smethod_2(Enum34.const_47);

		public static Icon SIID_AUDIOFILES => smethod_2(Enum34.const_48);

		public static Icon SIID_IMAGEFILES => smethod_2(Enum34.const_49);

		public static Icon SIID_VIDEOFILES => smethod_2(Enum34.const_50);

		public static Icon SIID_MIXEDFILES => smethod_2(Enum34.const_51);

		public static Icon SIID_FOLDERBACK => smethod_2(Enum34.const_52);

		public static Icon SIID_FOLDERFRONT => smethod_2(Enum34.const_53);

		public static Icon SIID_SHIELD => smethod_2(Enum34.const_54);

		public static Icon SIID_WARNING => smethod_2(Enum34.const_55);

		public static Icon SIID_INFO => smethod_2(Enum34.const_56);

		public static Icon SIID_ERROR => smethod_2(Enum34.const_57);

		public static Icon SIID_KEY => smethod_2(Enum34.const_58);

		public static Icon SIID_SOFTWARE => smethod_2(Enum34.const_59);

		public static Icon SIID_RENAME => smethod_2(Enum34.const_60);

		public static Icon SIID_DELETE => smethod_2(Enum34.const_61);

		public static Icon SIID_MEDIAAUDIODVD => smethod_2(Enum34.const_62);

		public static Icon SIID_MEDIAMOVIEDVD => smethod_2(Enum34.const_63);

		public static Icon SIID_MEDIAENHANCEDCD => smethod_2(Enum34.const_64);

		public static Icon SIID_MEDIAENHANCEDDVD => smethod_2(Enum34.const_65);

		public static Icon SIID_MEDIAHDDVD => smethod_2(Enum34.const_66);

		public static Icon SIID_MEDIABLURAY => smethod_2(Enum34.const_67);

		public static Icon SIID_MEDIAVCD => smethod_2(Enum34.const_68);

		public static Icon SIID_MEDIADVDPLUSR => smethod_2(Enum34.const_69);

		public static Icon SIID_MEDIADVDPLUSRW => smethod_2(Enum34.const_70);

		public static Icon SIID_DESKTOPPC => smethod_2(Enum34.const_71);

		public static Icon SIID_MOBILEPC => smethod_2(Enum34.const_72);

		public static Icon SIID_USERS => smethod_2(Enum34.const_73);

		public static Icon SIID_MEDIASMARTMEDIA => smethod_2(Enum34.const_74);

		public static Icon SIID_MEDIACOMPACTFLASH => smethod_2(Enum34.const_75);

		public static Icon SIID_DEVICECELLPHONE => smethod_2(Enum34.const_76);

		public static Icon SIID_DEVICECAMERA => smethod_2(Enum34.const_77);

		public static Icon SIID_DEVICEVIDEOCAMERA => smethod_2(Enum34.const_78);

		public static Icon SIID_DEVICEAUDIOPLAYER => smethod_2(Enum34.const_79);

		public static Icon SIID_NETWORKCONNECT => smethod_2(Enum34.const_80);

		public static Icon SIID_INTERNET => smethod_2(Enum34.const_81);

		public static Icon SIID_ZIPFILE => smethod_2(Enum34.const_82);

		public static Icon SIID_SETTINGS => smethod_2(Enum34.const_83);

		public static Icon SIID_DRIVEHDDVD => smethod_2(Enum34.const_84);

		public static Icon SIID_DRIVEBD => smethod_2(Enum34.const_85);

		public static Icon SIID_MEDIAHDDVDROM => smethod_2(Enum34.const_86);

		public static Icon SIID_MEDIAHDDVDR => smethod_2(Enum34.const_87);

		public static Icon SIID_MEDIAHDDVDRAM => smethod_2(Enum34.const_88);

		public static Icon SIID_MEDIABDROM => smethod_2(Enum34.const_89);

		public static Icon SIID_MEDIABDR => smethod_2(Enum34.const_90);

		public static Icon SIID_MEDIABDRE => smethod_2(Enum34.const_91);

		public static Icon SIID_CLUSTEREDDRIVE => smethod_2(Enum34.const_92);

		public static Icon SIID_MAX_ICONS => smethod_2(Enum34.const_93);

		public static void smethod_0()
		{
			foreach (Enum34 key in dictionary_0.Keys)
			{
				if (dictionary_0[key] != null)
				{
					dictionary_0[key].Dispose();
				}
			}
			dictionary_0.Clear();
		}

		
		public static void smethod_1(string string_0)
		{
			int num = 2;
			if (!Directory.Exists(string_0))
			{
				throw new DirectoryNotFoundException(string_0);
			}
			foreach (object value in Enum.GetValues(typeof(Enum34)))
			{
				Icon icon = smethod_2((Enum34)value);
				if (icon != null)
				{
					string path = Path.Combine(string_0, value.ToString() + ".ico");
					using (FileStream outputStream = new FileStream(path, FileMode.Create, FileAccess.Write))
					{
						icon.Save(outputStream);
					}
					icon.Dispose();
				}
			}
		}

		private static Icon smethod_2(Enum34 enum34_0)
		{
			if (Environment.OSVersion.Version.Major < 6)
			{
				return null;
			}
			if (dictionary_0.ContainsKey(enum34_0))
			{
				return dictionary_0[enum34_0];
			}
			Struct110 struct110_ = default(Struct110);
			struct110_.uint_0 = (uint)Marshal.SizeOf(typeof(Struct110));
			int num = SHGetStockIconInfo(enum34_0, Enum33.flag_1 | Enum33.flag_6, ref struct110_);
			if (num != 0)
			{
				Marshal.ThrowExceptionForHR(num);
			}
			if (struct110_.intptr_0 != IntPtr.Zero)
			{
				Icon icon = (Icon)Icon.FromHandle(struct110_.intptr_0).Clone();
				DestroyIcon(struct110_.intptr_0);
				dictionary_0[enum34_0] = icon;
				return icon;
			}
			dictionary_0[enum34_0] = null;
			return null;
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern int DestroyIcon(IntPtr intptr_0);

		[DllImport("shell32.dll")]
		private static extern int SHGetStockIconInfo(Enum34 enum34_0, Enum33 enum33_0, ref Struct110 struct110_0);
	}
}
