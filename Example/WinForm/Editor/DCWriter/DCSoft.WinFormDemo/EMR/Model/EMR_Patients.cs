using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DCSoft.ORM;

namespace DCSoft.Writer.WinFormDemo.EMR.Model
{
    [ORMType("EMR_Patients" , Buffered=ORMBooleanValue.False)]
    public class EMR_Patients
    {
        public EMR_Patients()
		{}
		#region Model
		private string _pa_id;
		private string _pa_beinhospital_gree;
		private string _pa_outpatient_code;
		private string _pa_cardcode;
		private string _pa_beinhospital_code;
		private string _pa_pih_patient_sapce;
		private string _pa_case_histor_code;
		private string _pa_name;
		private string _pa_sex;
		private DateTime _pa_prithtime;
		private string _pa_homeplace;
		private string _pa_nation;
		private string _pa_nationality;
		private string _pa_identitycard;
		private string _pa_work_unit;
		private string _pa_workadress;
		private string _pa_w_postalcode;
		private string _pa_w_phone;
		private string _pa_rpe_address;
		private string _pa_rpe_postalcode;
		private string _pa_rpe_phone;
		private string _pa_linkman_name;
		private string _pa_lm_rapport;
		private string _pa_lm_address;
		private string _pa_lm_phone;
		private string _pa_insurance_ce_code;
		private string _pa_insurance_ce_name;
		private string _pa_insurance_code;
		private string _pa_personnel_type;
		private string _pa_patient_source;
		private string _pa_doctor;
		private string _pa_diagnose;
		private string _pa_diagnose_nurse;
		private string _pa_nurcs;
		private string _pa_fashion;
		private DateTime _pa_ry_time;
		private string _pa_forestalldiagnose;
		private string _pa_rykb;
		private string _pa_payment_nurcs;
		private string _pa_bingan_code;
		private string _pa_amrriage_status;
		private string _pa_occupation;
		private string _pa_displace_kb;
		private string _pa_displace_beinhospital;
		private string _pa_leavehospital_be;
		private string _pa_leavehospital_patient;
		private string _pa_leavehospital_nurcs;
		private string _pa_pih_numberofdays;
		private string _pa_cure_type;
		private DateTime _pa_diagnose_date;
		private string _pa_diagnose_dr;
		private string _pa_state;
		private string _pa_beinhospital_booker;
		private DateTime _pa_beinhospital_bookintime;
		private string _pa_leavehospital_booker;
		private DateTime _pa_leavehospital_bookintime;
		private string _pa_pym;
		private string _pa_his_beinhospital_code;

		/// <summary>
		/// 住院号
		/// </summary>
        [Description("住院号")]
        public string PA_HIS_BEINHOSPITAL_CODE
		{
			get { return _pa_his_beinhospital_code; }
			set { _pa_his_beinhospital_code = value; }
		}
		/// <summary>
		/// 
		/// </summary>
        [Description("病人ID")]
        [ReadOnly(true )]
        [ORMKeyField()]
        public string PA_ID
		{
			set{ _pa_id=value;}
			get{return _pa_id;}
		}
		/// <summary>
		/// 住院次数
		/// </summary>
        [Description("住院次数")]
		public string PA_BEINHOSPITAL_GREE
		{
			set{ _pa_beinhospital_gree=value;}
			get{return _pa_beinhospital_gree;}
		}
		/// <summary>
		/// 门诊号
		/// </summary>
        [Description("门诊号")]
		public string PA_OUTPATIENT_CODE
		{
			set{ _pa_outpatient_code=value;}
			get{return _pa_outpatient_code;}
		}
		/// <summary>
		/// 一卡通号
		/// </summary>
        [Description("一卡通号")]
        public string PA_CARDCODE
		{
			set{ _pa_cardcode=value;}
			get{return _pa_cardcode;}
		}
		/// <summary>
		/// 住院号
		/// </summary>
        [Description("住院号")]
        public string PA_BEINHOSPITAL_CODE
		{
			set{ _pa_beinhospital_code=value;}
			get{return _pa_beinhospital_code;}
		}
		/// <summary>
		/// 住院病区号（病室）
		/// </summary>
        [Description("住院病区")]
        public string PA_PIH_PATIENT_SAPCE
		{
			set{ _pa_pih_patient_sapce=value;}
			get{return _pa_pih_patient_sapce;}
		}
		/// <summary>
		/// 病历号
		/// </summary>
        [Description("病历号")]
        public string PA_CASE_HISTOR_CODE
		{
			set{ _pa_case_histor_code=value;}
			get{return _pa_case_histor_code;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
        [Description("姓名")]
        [ORMSort(ORMSortStyle.Ascent )]
        public string PA_NAME
		{
			set{ _pa_name=value;}
			get{return _pa_name;}
		}
		/// <summary>
		/// 性别
		/// </summary>
        [EMRPropertyDescription(
            ListStyle="性别" ,
            ListOnly=true ,
            ListDisplayMember = "SysDesc", 
            ListValueMember ="SysCode" )]
        [Description("性别")]
        public string PA_SEX
		{
			set
            {
                _pa_sex=value;
            }
			get
            {
                return _pa_sex;
            }
		}
		/// <summary>
		/// 出生日期
		/// </summary>
        [EMRPropertyDescription(DisplayFormat="yyyy年MM月dd日")]
        [Description("出生日期")]
        public DateTime PA_PRITHTIME
		{
			set{ _pa_prithtime=value;}
			get{return _pa_prithtime;}
		}
		/// <summary>
		/// 出生地
		/// </summary>
        [Description("出生地")]
        public string PA_HOMEPLACE
		{
			set{ _pa_homeplace=value;}
			get{return _pa_homeplace;}
		}
		/// <summary>
		/// 民族
		/// </summary>
        [EMRPropertyDescription(
            ListStyle = "民族",
            ListOnly = true,
            ListDisplayMember = "SysDesc",
            ListValueMember = "SysCode")]
        [Description("民族")]
        public string PA_NATION
		{
			set{ _pa_nation=value;}
			get{return _pa_nation;}
		}
		/// <summary>
		/// 国籍
		/// </summary>
        [Description("国籍")]
        [EMRPropertyDescription(
            ListStyle = "国籍",
            ListOnly = true ,
            ListDisplayMember = "SysDesc",
            ListValueMember = "SysCode")]
		public string PA_NATIONALITY
		{
			set{ _pa_nationality=value;}
			get{return _pa_nationality;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
        [Description("身份证号")]
        public string PA_IDENTITYCARD
		{
			set{ _pa_identitycard=value;}
			get{return _pa_identitycard;}
		}
		/// <summary>
		/// 工作单位
		/// </summary>
        [Description("工作单位")]
        public string PA_WORK_UNIT
		{
			set{ _pa_work_unit=value;}
			get{return _pa_work_unit;}
		}
		/// <summary>
		/// 工作单位地址
		/// </summary>
        [Description("工作单位地址")]
        public string PA_WORKADRESS
		{
			set{ _pa_workadress=value;}
			get{return _pa_workadress;}
		}
		/// <summary>
		/// 工作单位邮政编码
		/// </summary>
        [Description("工作单位邮政编码")]
        public string PA_W_POSTALCODE
		{
			set{ _pa_w_postalcode=value;}
			get{return _pa_w_postalcode;}
		}
		/// <summary>
		/// 工作单位的电话
		/// </summary>
        [Description("工作单位的电话")]
        public string PA_W_PHONE
		{
			set{ _pa_w_phone=value;}
			get{return _pa_w_phone;}
		}
		/// <summary>
		/// 户口所在地
		/// </summary>
        [Description("户口所在地")]
		public string PA_RPE_ADDRESS
		{
			set{ _pa_rpe_address=value;}
			get{return _pa_rpe_address;}
		}
		/// <summary>
		/// 户口所在地的邮编
		/// </summary>
        [Description("户口所在地的邮编")]
        public string PA_RPE_POSTALCODE
		{
			set{ _pa_rpe_postalcode=value;}
			get{return _pa_rpe_postalcode;}
		}
		/// <summary>
		/// 户口所在地的电话
		/// </summary>
        [Description("户口所在地的电话")]
        public string PA_RPE_PHONE
		{
			set{ _pa_rpe_phone=value;}
			get{return _pa_rpe_phone;}
		}
		/// <summary>
		/// 联系人姓名
		/// </summary>
        [Description("联系人姓名")]
        public string PA_LINKMAN_NAME
		{
			set{ _pa_linkman_name=value;}
			get{return _pa_linkman_name;}
		}
		/// <summary>
		/// 联系人关系
		/// </summary>
        [EMRPropertyDescription(
            ListStyle="联系人关系",
            ListDisplayMember = "SysDesc", 
            ListValueMember ="SysCode" ) ]
        [Description("联系人关系")]
        public string PA_LM_RAPPORT
		{
			set{ _pa_lm_rapport=value;}
			get{return _pa_lm_rapport;}
		}
		/// <summary>
		/// 联系人地址
		/// </summary>
        [Description("联系人地址")]
        public string PA_LM_ADDRESS
		{
			set{ _pa_lm_address=value;}
			get{return _pa_lm_address;}
		}
		/// <summary>
		/// 联系人电话 
		/// </summary>
        [Description("联系人电话")]
        public string PA_LM_PHONE
		{
			set{ _pa_lm_phone=value;}
			get{return _pa_lm_phone;}
		}
		/// <summary>
		/// 保险中心号码
		/// </summary>
        [Description("保险中心号码")]
        public string PA_INSURANCE_CE_CODE
		{
			set{ _pa_insurance_ce_code=value;}
			get{return _pa_insurance_ce_code;}
		}
		/// <summary>
		/// 保险中心名称
		/// </summary>
        [Description("保险中心名称")]
        public string PA_INSURANCE_CE_NAME
		{
			set{ _pa_insurance_ce_name=value;}
			get{return _pa_insurance_ce_name;}
		}
		/// <summary>
		/// 保险号
		/// </summary>
        [Description("保险号")]
        public string PA_INSURANCE_CODE
		{
			set{ _pa_insurance_code=value;}
			get{return _pa_insurance_code;}
		}
		/// <summary>
		/// 人员类型
		/// </summary>
        [Description("人员类型")]
        public string PA_PERSONNEL_TYPE
		{
			set{ _pa_personnel_type=value;}
			get{return _pa_personnel_type;}
		}
		/// <summary>
		/// 病人来源
		/// </summary>
        [Description("病人来源")]
        [EMRPropertyDescription(
            ListStyle = "病人来源", 
            ListOnly = true ,
            ListDisplayMember = "SysDesc",
            ListValueMember = "SysCode")]
        public string PA_PATIENT_SOURCE
		{
			set{ _pa_patient_source=value;}
			get{return _pa_patient_source;}
		}
		/// <summary>
		/// 门诊医生
		/// </summary>
        [Description("门诊医生")]
        [EMRPropertyDescription(
            ListStyle = "本科门诊医生",
            ListOnly = true,
            ListDisplayMember = "em_Name",
            ListValueMember = "id")]
        public string PA_DOCTOR
		{
			set{ _pa_doctor=value;}
			get{return _pa_doctor;}
		}

		/// <summary>
		/// 诊断
		/// </summary>
        [Description("诊断")]
        public string PA_DIAGNOSE
		{
			set{ _pa_diagnose=value;}
			get{return _pa_diagnose;}
		}
		/// <summary>
		/// 主管护士
		/// </summary>
        [Description("主管护士")]
        public string PA_DIAGNOSE_NURSE
		{
			set{ _pa_diagnose_nurse=value;}
			get{return _pa_diagnose_nurse;}
		}
		/// <summary>
		/// 入院情况
		/// </summary>
        [Description("入院情况")]
        [EMRPropertyDescription(ListStyle = "入院情况")]
		public string PA_NURCS
		{
			set{ _pa_nurcs=value;}
			get{return _pa_nurcs;}
		}
		/// <summary>
		/// 入院方式
		/// </summary>
        [EMRPropertyDescription(ListStyle = "入院方式")]
        [Description("入院方式")]
        public string PA_FASHION
		{
			set{ _pa_fashion=value;}
			get{return _pa_fashion;}
		}
		/// <summary>
		/// 入院时间
		/// </summary>
        [Description("入院时间")]
        public DateTime PA_RY_TIME
		{
			set{ _pa_ry_time=value;}
			get{return _pa_ry_time;}
		}
		/// <summary>
		/// 入院前诊断
		/// </summary>
        [Description("入院前诊断")]
        public string PA_FORESTALLDIAGNOSE
		{
			set{ _pa_forestalldiagnose=value;}
			get{return _pa_forestalldiagnose;}
		}
		/// <summary>
		/// 转科科别
		/// </summary>
        [Description("转科科别")]
        public string PA_RYKB
		{
			set{ _pa_rykb=value;}
			get{return _pa_rykb;}
		}
		/// <summary>
		/// 付款方式 
		/// </summary>
        [EMRPropertyDescription(ListStyle = "付款方式")]
        [Description("付款方式")]
        public string PA_PAYMENT_NURCS
		{
			set{ _pa_payment_nurcs=value;}
			get{return _pa_payment_nurcs;}
		}
		/// <summary>
		/// 病案号
		/// </summary>
        [Description("病案号")]
        public string PA_BINGAN_CODE
		{
			set{ _pa_bingan_code=value;}
			get{return _pa_bingan_code;}
		}
		/// <summary>
		/// 婚姻情况
		/// </summary>
        [EMRPropertyDescription(ListStyle = "婚姻状态")]
        [Description("婚姻情况")]
        public string PA_AMRRIAGE_STATUS
		{
			set{ _pa_amrriage_status=value;}
			get{return _pa_amrriage_status;}
		}
		/// <summary>
		/// 职业
		/// </summary>
        [EMRPropertyDescription(ListStyle = "职业")]
        [Description("职业")]
        public string PA_OCCUPATION
		{
			set{ _pa_occupation=value;}
			get{return _pa_occupation;}
		}
		/// <summary>
		/// 入科科别
		/// </summary>
        [Description("入科科别")]
        public string PA_DISPLACE_KB
		{
			set{ _pa_displace_kb=value;}
			get{return _pa_displace_kb;}
		}
		/// <summary>
		/// 转科病室
		/// </summary>
        [Description("转科病室")]
        public string PA_DISPLACE_BEINHOSPITAL
		{
			set{ _pa_displace_beinhospital=value;}
			get{return _pa_displace_beinhospital;}
		}
		/// <summary>
		/// 出院科别
		/// </summary>
        [Description("出院科别")]
        public string PA_LEAVEHOSPITAL_BE
		{
			set{ _pa_leavehospital_be=value;}
			get{return _pa_leavehospital_be;}
		}
		/// <summary>
		/// 出院病区
		/// </summary>
        [Description("出院病区")]
        public string PA_LEAVEHOSPITAL_PATIENT
		{
			set{ _pa_leavehospital_patient=value;}
			get{return _pa_leavehospital_patient;}
		}
		/// <summary>
		/// 出院方式
		/// </summary>
        [Description("出院方式")]
        public string PA_LEAVEHOSPITAL_NURCS
		{
			set{ _pa_leavehospital_nurcs=value;}
			get{return _pa_leavehospital_nurcs;}
		}
		/// <summary>
		/// 住院天数
		/// </summary>
        [Description("住院天数")]
        public string PA_PIH_NUMBEROFDAYS
		{
			set{ _pa_pih_numberofdays=value;}
			get{return _pa_pih_numberofdays;}
		}
		/// <summary>
		/// 治疗类别
		/// </summary>
        [Description("治疗类别")]
        public string PA_CURE_TYPE
		{
			set{ _pa_cure_type=value;}
			get{return _pa_cure_type;}
		}
		/// <summary>
		/// 确诊日期
		/// </summary>
        [Description("确诊日期")]
        public DateTime PA_DIAGNOSE_DATE
		{
			set{ _pa_diagnose_date=value;}
			get{return _pa_diagnose_date;}
		}
		/// <summary>
		/// 住院医生
		/// </summary>
        [Description("住院医生")]
        [EMRPropertyDescription(ListStyle = "本科住院医生")]
		public string PA_DIAGNOSE_DR
		{
			set{ _pa_diagnose_dr=value;}
			get{return _pa_diagnose_dr;}
		}
		/// <summary>
		/// 病人状态
		/// </summary>
        [Description("病人状态")]
        public string PA_STATE
		{
			set{ _pa_state=value;}
			get{return _pa_state;}
		}
		/// <summary>
		/// 住院登记人
		/// </summary>
        [Description("住院登记人")]
        public string PA_BEINHOSPITAL_BOOKER
		{
			set{ _pa_beinhospital_booker=value;}
			get{return _pa_beinhospital_booker;}
		}
		/// <summary>
		/// 住院登记时间
		/// </summary>
        [Description("住院登记时间")]
        public DateTime PA_BEINHOSPITAL_BOOKINTIME
		{
			set{ _pa_beinhospital_bookintime=value;}
			get{return _pa_beinhospital_bookintime;}
		}
		/// <summary>
		/// 出院登记人
		/// </summary>
        [Description("出院登记人")]
        public string PA_LEAVEHOSPITAL_BOOKER
		{
			set{ _pa_leavehospital_booker=value;}
			get{return _pa_leavehospital_booker;}
		}
		/// <summary>
		/// 出院登记时间
		/// </summary>
        [Description("出院登记时间")]
        public DateTime PA_LEAVEHOSPITAL_BOOKINTIME
		{
			set{ _pa_leavehospital_bookintime=value;}
			get{return _pa_leavehospital_bookintime;}
		}
		/// <summary>
		/// 姓名拼音码
		/// </summary>
        [Description("姓名拼音码")]
        public string PA_PYM
		{
			set{ _pa_pym=value;}
			get{return _pa_pym;}
		}

        //private bool _PA_Enabled = true;

        //[Description ("记录是否有效")]
        //[DefaultValue( true )]
        //public bool PA_Enabled
        //{
        //    get { return _PA_Enabled; }
        //    set { _PA_Enabled = value; }
        //}

		#endregion Model
    }


    /// <summary>
    /// 病人基本信息实体类型
    /// </summary>
    public class Patients
    {
        private string _PA_NAME = null;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PA_NAME
        {
            get { return _PA_NAME; }
            set { _PA_NAME = value; }
        }

        private string _ID = null;
        /// <summary>
        /// 编号
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        // 定义其他属性
    }
}
