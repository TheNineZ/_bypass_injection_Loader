﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using ManualMapInjection.Injection;
using System.IO;


namespace Loader
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
            foreach (Process Proc in Process.GetProcesses())
                if (Proc.ProcessName.Equals("Taskmgr"))  
                    Proc.Kill();
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selecedcheat = comboBox1.GetItemText(comboBox1.SelectedItem);
            WebClient client = new WebClient();
            var name = "csgo";
            var target = Process.GetProcessesByName(name).FirstOrDefault();
            if (target == null)
            {
                ;
                return;
            }

            if (selecedcheat == "Test.CSGO")
            {

                var injector = new ManualMapInjector(target) { AsyncInjection = true };
                string boom = $"hmodule = 0x{injector.Inject(Loader.Properties.Resource.DLL).ToInt64():x8}"; // insert your cheat in Resources.resx
                Application.ExitThread();
                Application.Exit();
            }
            if (selecedcheat == "")
            {
                var injector = new ManualMapInjector(target) { AsyncInjection = true };
                string boom = $"hmodule = 0x{injector.Inject(Loader.Properties.Resource.DLL).ToInt64():x8}"; // insert your cheat in Resources.resx
                Application.ExitThread();
                Application.Exit();
            }
        }


    }
}
