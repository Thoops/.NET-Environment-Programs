using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int endPoint;
        private Thread thread;


        private void startButton_Click(object sender, EventArgs e)
        {
            string str = primeTextBox.Text;

            try
            {
                endPoint = int.Parse(str);
            }
            catch(Exception)
            {
                MessageBox.Show("Not a valid number");
                return;
            }
            
            
            startButton.Enabled = false;
            cancelButton.Enabled = true;
            thread = new Thread(ThreadFunc);

            thread.Start();

            thread.Join();
        }

        public void ThreadFunc()
        {
            List<int> primes = new List<int>();
            int primeAmount = 0;
            for (int i = 2; i <= endPoint; i++)
            {
                if (checkPrime(i))
                {
                    primes.Add(i);
                    primeListBox.Items.Add(i);
                    primeAmount++;
                }
            }
        }

        public bool checkPrime(int num)
        {
            int i = 2;
            if(num < 2)
            {
                return false;
            }

            else if(num % 2 == 0)
            {
                return false;
            }

            while(i < num)
            {
                if (num % i == 0 && i != num)
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            thread.Join();
            startButton.Enabled = true;
            cancelButton.Enabled = false;
        }
    }
}
