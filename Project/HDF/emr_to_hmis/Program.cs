using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace emr_to_hmis
{
    class Program
    {   [STAThread]
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start("chrome.exe", "http://localhost:8081/dashboard#/shangbao/report?userName=0&orgCode=1&PATIENT=00014648");
        }
    }
}
