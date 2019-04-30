using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinSvcDockerized
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ThreadPool.QueueUserWorkItem((x) => RunLoop(), null);
        }

        private bool stopRequested = false;

        public void RunLoop()
        {
            LogText($"We are running in {Environment.CurrentDirectory}");
            int i = 0;
            while (!stopRequested)
            {
                Thread.Sleep(1000);
                i++;
                LogText($"{i}\n");
                if (File.Exists("C:\\extstop.txt"))
                {
                    this.Stop();
                }
            }
        }

        private static void LogText(string text)
        {
            File.AppendAllText("C:\\out.log", text);
        }

        protected override void OnStop()
        {
            stopRequested = true;
        }
    }
}
