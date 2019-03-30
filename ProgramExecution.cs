/* Program that takes a series program names as its command line arguments.
The goal is to make sure that these programs are always executing. So, if 
they die, the program will restart them. */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] proc = new Process[args.Length];

            for(int i = 0; i < args.Length; i++)
            {
                proc[i].StartInfo.FileName = args[i];
                proc[i].Start();
            }
            
            while (true)
            {
                for (int i = 0; i < proc.Length; i++)
                {
                    if (proc[i].HasExited)
                    {
                        proc[i].Start();
                    }
                }
            }
        }
    }
}
