using System;

namespace XDesignerCommon
{
	/// <summary>
	/// ����ת��ģ��,�����󲻿�ʵ����
	/// </summary>
	public sealed class MeasureConvert
	{
		/// <summary>
		/// ��Ӣ��ת��Ϊ����
		/// </summary>
		/// <param name="vValue">Ӣ��ֵ</param>
		/// <returns>����ֵ</returns>
		public static double InchToMillimeter( double vValue )
		{
			return vValue * 25.4 ;
		}
		/// <summary>
		/// ������ת��ΪӢ��
		/// </summary>
		/// <param name="vValue">����ֵ</param>
		/// <returns>Ӣ��ֵ</returns>
		public static double MillimeterToInch( double vValue )
		{
			return vValue / 25.4 ;
		}
		/// <summary>
		/// ���ĵ���λת��Ϊ������
		/// </summary>
		/// <param name="vValue">�ĵ���λֵ</param>
		/// <returns>����ֵ</returns>
		public static double DocumentToMillimeter( double vValue )
		{
			return vValue * 0.254 / 3 ;
		}
		/// <summary>
		/// ������ֵת��Ϊ�ĵ�ֵ
		/// </summary>
		/// <param name="vValue">����ֵ</param>
		/// <returns>�ĵ�ֵ</returns>
		public static double MillimeterToDocument( double vValue )
		{
			return vValue * 3 / 0.254 ;
		}
		/// <summary>
		/// ���ٷ�֮һӢ��ת��Ϊ����ֵ
		/// </summary>
		/// <param name="vValue">�ٷ�֮һӢ��ֵ</param>
		/// <returns>����ֵ</returns>
		public static double HundredthsInchToMillimeter( double vValue )
		{
			return vValue * 0.254 ;
		}
		/// <summary>
		/// ������ֵת��Ϊ�ٷ�֮һӢ��ֵ
		/// </summary>
		/// <param name="vValue">����ֵ</param>
		/// <returns>�ٷ�֮һӢ��ֵ</returns>
		public static double MillimeterToHundredthsInch( double vValue )
		{
			return vValue / 0.254 ;
		}
		/// <summary>
		/// ��Ӣ��ת��Ϊ����
		/// </summary>
		/// <param name="vValue">Ӣ��ֵ</param>
		/// <returns>����ֵ</returns>
		public static double InchToCentimeter( double vValue )
		{
			return vValue * 2.54 ;
		}
		/// <summary>
		/// ��Ӣ��ת��ΪӢ��
		/// </summary>
		/// <param name="vValue">Ӣ��ֵ</param>
		/// <returns>Ӣ��ֵ</returns>
		public static double FootToInch( double vValue )
		{
			return vValue * 12 ;
		}
		/// <summary>
		/// ��Ӣ��ת��Ϊ��
		/// </summary>
		/// <param name="vValue">Ӣ��ֵ</param>
		/// <returns>��ֵ</returns>
		public static double FootToRice( double vValue )
		{
			return vValue * 0.3048 ;
		}


		/// <summary>
		/// �����󲻿�ʵ����
		/// </summary>
		private MeasureConvert()
		{
		}
	}//public sealed class MeasureConvert
}
