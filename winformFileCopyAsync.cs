using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncFileIOWindForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task<long> CopyAsync(string FromPath, string ToPath)
        {
            asynce.Enabled = false;
            long totalCopied = 0;

            using (var FromStream = new System.IO.FileStream(FromPath, System.IO.FileMode.Open))
            {
                using (var ToStream = new System.IO.FileStream(ToPath, System.IO.FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int nRead = 0;
                    while ((nRead = await FromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await ToStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;
                        progressBar1.Value = (int)((totalCopied * 100) / FromStream.Length);
                    }
                }
            }
            asynce.Enabled = true;
            return totalCopied;
        }

        private long CopySync(string FromPath, string ToPath)
        {
            synccopy.Enabled = false;
            long totalCopied = 0;

            using (var FromStream = new System.IO.FileStream(FromPath, System.IO.FileMode.Open))
            {
                using (var ToStream = new System.IO.FileStream(ToPath, System.IO.FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int nRead = 0;
                    while ((nRead = FromStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ToStream.Write(buffer, 0, nRead);
                        totalCopied += nRead;
                        progressBar1.Value = (int)((totalCopied * 100) / FromStream.Length);
                    }
                }
            }
            synccopy.Enabled = true;
            return totalCopied;
        }


        private void source_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = ofd.FileName;
            }
        }

        private void target_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtTarget.Text = sfd.FileName;
            }
        }

        private async void asynce_Click(object sender, EventArgs e)
        {
            long totalCopied = await CopyAsync(txtSource.Text, txtTarget.Text);
        }

        private void synccopy_Click(object sender, EventArgs e)
        {
            long totalCopied = CopySync(txtSource.Text, txtTarget.Text);
        }
    }
}
