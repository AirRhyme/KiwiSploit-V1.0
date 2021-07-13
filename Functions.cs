using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiwiSploit
{
    class Functions
    {

        public static void PopulateListBox(ListBox lsb, String Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach(FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        public static void addToScriptList(ListBox lsb, String Folder, String FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }
    }
}
