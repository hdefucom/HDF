using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WXTool.WebService.Function
{
    public partial class FormInject : Form
    {
        public FormInject()
        {
            InitializeComponent();
        }

        private void FormInject_Load(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshInfo();
        }



        private void button_Restart_Click(object sender, EventArgs e)
        {
            ReStartWX();
        }

        private void button_Inject_Click(object sender, EventArgs e)
        {
            if (cb_DllList.SelectedItem == null)
            {
                MessageBox.Show("请先选择一个dll");
                return;
            }
            Inject(cb_DllList.SelectedItem.ToString());
            this.Close();
        }




        /// <summary>
        /// 刷新信息
        /// </summary>
        private void RefreshInfo()
        {
            var process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "WeChat");
            if (process == null)
            {
                if (MessageBox.Show("微信未启动，是否启动微信？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ReStartWX();
                    process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "WeChat");
                }
                else
                    return;
            }


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("刷新时间：\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
            stringBuilder.Append("DLL位置：\t" + Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + Environment.NewLine);
            stringBuilder.Append("进程PID：\t" + process.Id + Environment.NewLine);
            stringBuilder.Append("窗口标题：\t" + process.MainWindowTitle + Environment.NewLine);
            stringBuilder.Append("启动时间：\t" + process.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
            stringBuilder.Append("微信目录：\t" + Path.GetDirectoryName(process.MainModule.FileName) + Environment.NewLine);
            //x64下.Net4.0使用process.Modules无法获取所有微信加载的模块（因为微信是32位），只能通过文件获取版本信息
            var module = process.Modules.Cast<ProcessModule>().FirstOrDefault(m => m.ModuleName.ToLower() == "WeChatWin.dll".ToLower());
            if (module != null)
            {
                stringBuilder.Append("微信版本：\t" + module.FileVersionInfo.FileVersion + Environment.NewLine);
                stringBuilder.Append("微信基址：\t0x" + module.BaseAddress.ToString("X8") + Environment.NewLine);
            }
            else if (File.Exists(Path.GetDirectoryName(process.MainModule.FileName) + "\\WeChatWin.dll"))
            {
                var info = FileVersionInfo.GetVersionInfo(Path.GetDirectoryName(process.MainModule.FileName) + "\\WeChatWin.dll");
                stringBuilder.Append("微信版本：\t" + info.FileVersion + Environment.NewLine);
            }


            txt_Info.Text = stringBuilder.ToString();
            cb_DllList.Items.Clear();
            cb_DllList.Items.AddRange(Directory.GetFiles(Application.StartupPath + "\\Lib", "*.dll")
                .Select(f => Path.GetFileName(f)).ToArray());
            cb_DllList.SelectedIndex = 0;
        }

        /// <summary>
        /// 重启微信
        /// </summary>
        private void ReStartWX()
        {
            var path = string.Empty;

            var process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "WeChat");
            if (process != null)
            {
                path = process.MainModule.FileName;
                process.Kill();

                Process.Start(path);
                Thread.Sleep(500);
                RefreshInfo();
            }
            else
            {
                try
                {
                    RegistryKey currentUser = Registry.CurrentUser;
                    RegistryKey registryKey = currentUser.OpenSubKey("Software\\Tencent\\WeChat");
                    object value = registryKey.GetValue("InstallPath");
                    path = value.ToString() + "\\WeChat.exe";
                    currentUser.Close();
                }
                catch
                {
                }
            }
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("微信程序路径获取失败，请手动启动微信。");
                return;
            }

            Process.Start(path);
            Thread.Sleep(500);
        }



        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="path"></param>
        private void Inject(string file)
        {
            var process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "WeChat");
            if (process == null)
            {
                MessageBox.Show("注入前请先启动微信！", "错误");
                return;
            }

            if (process.Modules.Cast<ProcessModule>().Any(p => p.ModuleName == file))
            {
                MessageBox.Show($"DLL文件“{file}”之前已注入!\n\n若要重新注入，请先重启微信!", "警告");
                return;
            }

            string fullPath = $"{Application.StartupPath}\\Lib\\{file}";
            if (!File.Exists(fullPath))
            {
                MessageBox.Show("被注入的DLL文件(" + fullPath + ")不存在！", "错误");
                return;
            }
            int num = fullPath.Length * 2 + 1;
            int flAllocationType = 4096;
            int flProtect = 4;

            int num2 = VirtualAllocEx((int)process.Handle, 0, num, flAllocationType, flProtect);
            if (num2 == 0)
            {
                MessageBox.Show("内存分配失败！");
                return;
            }
            txt_Info.AppendText("内存地址:\t0x" + num2.ToString("X8") + Environment.NewLine);
            if (!WriteProcessMemory((int)process.Handle, num2, fullPath, num, 0))
            {
                MessageBox.Show("内存写入失败！");
                return;
            }
            var moduleHandleA = GetModuleHandleA("Kernel32.dll");
            int procAddress = GetProcAddress(moduleHandleA, "LoadLibraryA");
            if (procAddress == 0)
            {
                MessageBox.Show("查找LoadLibraryA地址失败！");
            }
            else if (CreateRemoteThread((int)process.Handle, 0, 0, procAddress, num2, 0, 0) == 0)
            {
                MessageBox.Show("执行远程线程失败！");
            }
            else
            {
                txt_Info.AppendText("成功注入:\t" + file + Environment.NewLine);
            }
        }




        [DllImport("Kernel32.dll")]
        private static extern int VirtualAllocEx(int hProcess, int lpAddress, int dwSize, int flAllocationType, int flProtect);

        [DllImport("Kernel32.dll")]
        private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, string lpBuffer, int nSize, int lpNumberOfBytesWritten);

        [DllImport("Kernel32.dll")]
        private static extern int GetModuleHandleA(string lpModuleName);

        [DllImport("Kernel32.dll")]
        private static extern int GetProcAddress(int hModule, string lpProcName);

        [DllImport("Kernel32.dll")]
        private static extern int CreateRemoteThread(int hProcess, int lpThreadAttributes, int dwStackSize, int lpStartAddress, int lpParameter, int dwCreationFlags, int lpThreadId);

        [DllImport("Kernel32.dll")]
        private static extern bool VirtualFreeEx(int hProcess, int lpAddress, int dwSize, int dwFreeType);



    }
}
