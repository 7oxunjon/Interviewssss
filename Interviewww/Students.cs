using DATA.Model;
using Helper.Help;
using Interviewww.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interviewww
{
    public partial class Students : Form
    {
        protected readonly HttpClient http;
        protected readonly HelperTop helper;
        protected readonly SuhbatOluvchi suhbat;
        protected readonly string Uri;
        public Students(SuhbatOluvchi oluvchi)
        {
            HttpClient client = new HttpClient();
            string uri = "http://localhost:5135/api/Nomzod";
            http = client;
            HelperTop top = new HelperTop(client, uri);
            helper = top;
            suhbat = oluvchi;
           
            InitializeComponent();
            label1.Text = suhbat.Fullname;
            label2.Text = suhbat.Yunalish;
            label3.Text = suhbat.Darajasi;
            label4.Text = suhbat.Loyxasi;
            label5.Text = suhbat.Loyxasi;
            foreach(var c in suhbat.suhbatTopshiruvchis)
            {
                AddPanel(c);
            }
            
        }
        private void AddPanel(SuhbatTopshiruvchi topshiruvchi)
        {
            StudentControl2 student = new StudentControl2(topshiruvchi);
            student.Dock = DockStyle.Top;
            panel1.Controls.Add(student);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentReg reg = new StudentReg(suhbat.Id);
            reg.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (var c in suhbat.suhbatTopshiruvchis)
            {
                AddPanel(c);
            }
        }
    }
}
