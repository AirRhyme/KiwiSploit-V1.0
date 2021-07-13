using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiwiSploit
{
    public partial class KiwiSploit12 : Form
    {
        EasyExploits.Module module = new EasyExploits.Module();
        WeAreDevs_API.ExploitAPI wrd = new WeAreDevs_API.ExploitAPI();
        public KiwiSploit12()
        {
            InitializeComponent();
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            module.ExecuteScript(webBrowser1.Text);
            wrd.SendLuaCScript(webBrowser1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                webBrowser1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
        }

        private async void KwiwSploit12_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                bool flag2 = registryKey.GetValue(friendlyName) == null;
                if (flag2)
                {
                    registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                }
                registryKey = null;
                friendlyName = null;
            }
            catch (Exception)
            {
            }
            webBrowser1.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(500);
            webBrowser1.Document.InvokeScript("SetTheme", new string[]
            {
                   "Dark" 
                   /*
                    There are 2 Themes Dark and Light
                   */
            });
            addBase();
            addMath();
            addGlobalNS();
            webBrowser1.Document.InvokeScript("SetText", new object[]
            {
                 "-- Execute Scripts Here--"
            });
            listBox1.Items.Clear();
            Functions.addToScriptList(listBox1, "./Scripts", "*.txt");
            Functions.addToScriptList(listBox1, "./Scripts", "*.lua");
        }

        private void addGlobalNS()
        {
            throw new NotImplementedException();
        }

        private void addMath()
        {
            throw new NotImplementedException();
        }

        private void addBase()
        {
            throw new NotImplementedException();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            module.LaunchExploit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            wrd.LaunchExploit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(webBrowser1.Text);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button8_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Sorry, you are stuck here");
         
        }

    }
}
