using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyExploits;
using System.IO;
using System.Net;
using Microsoft.Win32;

namespace KiwiSploit
{
    public partial class KiwiSploit : Form
    {
        EasyExploits.Module module = new EasyExploits.Module();
        WeAreDevs_API.ExploitAPI wrd = new WeAreDevs_API.ExploitAPI();
        KrnlAPI.MainAPI GetAPI = new KrnlAPI.MainAPI();
        KiwiModule.Kiwi kiwi = new KiwiModule.Kiwi();
        AnemoAPI.Anemo Anemo = new AnemoAPI.Anemo();
        OxygenUI_API.API api = new OxygenUI_API.API();
        WebClient wc = new WebClient();
        private string defPath = Application.StartupPath + "//Monaco//";
        public int tabs = 1;

        public KiwiSploit()
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
            if(e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            module.ExecuteScript(webBrowser1.DocumentText);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            module.LaunchExploit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                webBrowser1.DocumentText = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(webBrowser1.DocumentText);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            wrd.LaunchExploit();
        }

       

private void addIntel(string label, string kind, string detail, string insertText)
        {
            string text = "\"" + label + "\"";
            string text2 = "\"" + kind + "\"";
            string text3 = "\"" + detail + "\"";
            string text4 = "\"" + insertText + "\"";
            webBrowser1.Document.InvokeScript("AddIntellisense", new object[]
            {
                label,
                kind,
                detail,
                insertText
            });
        }

        private void addGlobalF()
        {
            string[] array = File.ReadAllLines(this.defPath + "//globalf.txt");
            foreach (string text in array)
            {
                bool flag = text.Contains(':');
                if (flag)
                {
                    this.addIntel(text, "Function", text, text.Substring(1));
                }
                else
                {
                    this.addIntel(text, "Function", text, text);
                }
            }
        }

        private void addGlobalV()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalv.txt"))
            {
                this.addIntel(text, "Variable", text, text);
            }
        }

        private void addGlobalNS()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalns.txt"))
            {
                this.addIntel(text, "Class", text, text);
            }
        }

        private void addMath()
        {
            foreach (string text in File.ReadLines(this.defPath + "//classfunc.txt"))
            {
                this.addIntel(text, "Method", text, text);
            }
        }

        private void addBase()
        {
            foreach (string text in File.ReadLines(this.defPath + "//base.txt"))
            {
                this.addIntel(text, "Keyword", text, text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit()
                ;        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = "";
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            wrd.SendLuaScript(webBrowser1.DocumentText);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            module.ExecuteScript(wc.DownloadString("https://darkhub.xyz/remote-script.lua"));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            KrnlAPI.MainAPI.Inject();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            KrnlAPI.MainAPI.Execute(webBrowser1.DocumentText);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            kiwi.LaunchExploit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kiwi.ExecuteScript(webBrowser1.DocumentText);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Anemo.ExecuteScript(webBrowser1.DocumentText);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Anemo.InjectAnemo();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            api.Inject();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            api.Execute(webBrowser1.DocumentText);
        }

        private void button19_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                webBrowser1.Document.InvokeScript("SetText", new object[1]
                {
          (object) System.IO.File.ReadAllText("scripts\\" + listBox1.SelectedItem.ToString())
                });
            }
            else
            {
                int num = (int)MessageBox.Show("Please select a script from the script list to load.", "Aquatic");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                listBox1.Hide();
            }
            else
            {
                listBox1.Show();
            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {

            }
        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }

        private async void KiwiSploit_Load(object sender, EventArgs e)
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
            addGlobalV();
            addGlobalF();
            webBrowser1.Document.InvokeScript("SetText", new object[]
            {
                 "--KiwiSploit V1.0.1"
            });
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }
    }


}
