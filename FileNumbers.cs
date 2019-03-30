using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string pattern = @"\d+\.\d+|\.\d+";
            string read = "";

            double sum = 0;

            Regex reg = new Regex(pattern);

            string directory = "";
            string output = "";
            
            string[] files;
            MatchCollection matches;

            try
            {
                directory = args[0];
                Directory.SetCurrentDirectory(directory);
            }
            catch (DirectoryNotFoundException)
            {
                //If the directory entered on the command line isn't found then
                //an exception is thrown
                MessageBox.Show(directory + " does not exist", "File Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            output = "The .txt files in this directory are:\r\n\r\n";

            files = Directory.GetFiles(directory, "*.txt");

            for (int i = 0; i < files.Length; i++)
            {
                output += files[i] + "\r\n";
                sum = 0;
                StreamReader stream = new StreamReader(files[i]);
                
                read = stream.ReadToEnd();
                matches = reg.Matches(read);

                if (matches.Count > 0)
                {
                    output += "Sum of all numbers in this file that contain a decimal point: \r\n";
                    for (int n = 0; n < matches.Count; n++)
                    {
                        sum += double.Parse(matches[n].ToString());
                    }
                    output += sum + "\r\n\r\n";
                }

                else
                {
                    output += "No numbers with a decimal point found in this file.\r\n\r\n";
                }
                
            }

            Console.Write(output);
            
        }
    }
}
