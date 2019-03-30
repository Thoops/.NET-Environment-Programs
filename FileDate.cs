using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp2
{
    class Lab7NET
    {

        
        static void ReturnFiles(string dirName, ref List<string> files)
        {
            files.AddRange(Directory.GetFiles(dirName));
            
            foreach (string dir in Directory.GetDirectories(dirName))
            {
                ReturnFiles(dir, ref files);
            }
            
        }

        static void Main(string[] args)
        {
            DateTime date;
            date = Convert.ToDateTime(args[1]);
            string dirName;
            string output = "";
            DateTime modTime;
            dirName = args[0];
            

            if (Directory.Exists(dirName))
            {
                modTime = File.GetLastWriteTime(dirName);

                List<string> fileNames = new List<string>();

                ReturnFiles(dirName, ref fileNames);

                output += "Files changed on or after " + date + ":\r\n";

                for (int i = 0; i < fileNames.Count; i++)
                {
                    if (DateTime.Compare(File.GetLastWriteTime(fileNames[i]), date) >= 0)
                    {
                        output += fileNames[i] + "\r\n";
                    }
                }
                
            }
            else
            {
                MessageBox.Show(dirName + " does not exist", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Console.Write(output);
            Console.WriteLine(date);
        }
    }
}
