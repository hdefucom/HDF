using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            post();
        }


        string postdata = @"

<ui_results_xml fun_id='1006'>
  <hosp_code>0</hosp_code>
  <hosp_flag>1</hosp_flag>
  <result_data>
    <result lvl_code = 'RL003' lvl='其他信息' title_code='RLT026' title='给药途径' ExistGSContent='False' NeedBlock='False' type='GYTJWT'>
      <title>氨茶碱氯化钠注射液未提及可膀胱灌注</title>
      <detail>药品说明书未指出本品可膀胱灌注</detail>
      <reference />
      <prescA_code>CF20191225142041</prescA_code>
      <mediA_hiscode>54</mediA_hiscode>
      <mediA_code>54</mediA_code>
      <mediA_name>氨茶碱氯化钠注射液</mediA_name>
      <prescB_code />
      <mediB_hiscode />
      <mediB_code />
      <mediB_name />
    </result>
    <result lvl_code = 'RL003' lvl='其他信息' title_code='RLT026' title='给药途径' ExistGSContent='False' NeedBlock='False' type='GYTJWT'>
      <title>氨茶碱注射液未提及可膀胱灌注</title>
      <detail>药品说明书未指出本品可膀胱灌注</detail>
      <reference />
      <prescA_code>CF20191225142041</prescA_code>
      <mediA_hiscode>55</mediA_hiscode>
      <mediA_code>55</mediA_code>
      <mediA_name>氨茶碱注射液</mediA_name>
      <prescB_code />
      <mediB_hiscode />
      <mediB_code />
      <mediB_name />
    </result>
    <result lvl_code = 'RL003' lvl='其他信息' title_code='RLT025' title='重复用药' ExistGSContent='False' NeedBlock='False' type='CFYYTS'>
      <title>【同种药】</title>
      <detail>氨茶碱氯化钠注射液 与 氨茶碱注射液属于同种药。 </detail>
      <reference />
      <prescA_code>CF20191225142041</prescA_code>
      <mediA_hiscode>54</mediA_hiscode>
      <mediA_code>54</mediA_code>
      <mediA_name>氨茶碱氯化钠注射液</mediA_name>
      <prescB_code>CF20191225142041</prescB_code>
      <mediB_hiscode>55</mediB_hiscode>
      <mediB_code>55</mediB_code>
      <mediB_name>氨茶碱注射液</mediB_name>
    </result>
  </result_data>
  <medicine_data>
    <medicine>
      <name>氨茶碱氯化钠注射液</name>
      <dt_code>54</dt_code>
    </medicine>
    <medicine>
      <name>氨茶碱注射液</name>
      <dt_code>55</dt_code>
    </medicine>
  </medicine_data>
  <brief>在患者李雪的用药医嘱中分析出潜在的用药风险3个</brief>
  <patient>
    <base_info>李雪（22岁，女）</base_info>
    <allergic />
    <diagnose />
    <prescription>氨茶碱氯化钠注射液氨茶碱注射液</prescription>
  </patient>
</ui_results_xml>


";


        public void post() {


        

            //wb_HLYY.Navigate("http://192.168.0.131", "", Encoding.UTF8.GetBytes(postdata), "");
            wb_HLYY.Navigate("http://localhost:51492/", "", Encoding.UTF8.GetBytes(postdata), "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            post();
        }
    }
}
