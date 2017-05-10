using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskBasedAsyncPattern
{
    /// <summary>
    /// Example of using the Task based Async pattern to utilize multithreading.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create a new thread and await for it to finish.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = @"Loading...";
            label1.Text = await Task.Run(() => DoWork(progressBar1));
        }

        /// <summary>
        /// Create a new thread and await for it to finish.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            label2.Text = @"Loading...";
            label2.Text = await Task.Run(() => DoWork(progressBar2));
        }

        /// <summary>
        /// Create a new thread and await for it to finish.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            label3.Text = @"Loading...";
            label3.Text = await Task.Run(() => DoWork(progressBar3));
        }

        /// <summary>
        /// Create a new thread and await for it to finish.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button4_Click(object sender, EventArgs e)
        {
            label4.Text = @"Loading...";
            label4.Text = await Task.Run(() => DoWork(progressBar4));
        }

        /// <summary>
        /// Do dummy work and then call further method within thread which returns string.
        /// </summary>
        /// <param name="progressBar"></param>
        /// <returns>Finished Message</returns>
        private async Task<string> DoWork(ProgressBar progressBar)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Invoke((MethodInvoker)(() => progressBar.Value = i));
                Thread.Sleep(10);
            }

            return await DoMoreWork();
        }

        /// <summary>
        /// Do some dummy work and return string.
        /// </summary>
        /// <returns></returns>
        private async Task<string> DoMoreWork()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }

            return "Finished";
        }
    }
}
