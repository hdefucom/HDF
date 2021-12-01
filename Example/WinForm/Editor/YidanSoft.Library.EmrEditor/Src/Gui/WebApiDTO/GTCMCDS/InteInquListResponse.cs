using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Gui.WebApiDTO.GTCMCDS
{
    /// <summary>
    /// 智能问诊
    /// </summary>
    public class InteInquListResponse
    {

        public string strText { get; set; }
        public string code { get; set; }

        public string msg { get; set; }



        public IEnumerable<string> _results;
        public IEnumerable<string> Results
        {
            get
            {
                _results = strText.Split(',');
                return _results;
            }
            set
            {
                _results = value;
            }
        }

    }
}
