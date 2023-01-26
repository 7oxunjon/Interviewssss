using DATA.Model;
using Helper.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interviewww.Controller
{
    public partial class StudentControl2 : UserControl
    {
        protected readonly HttpClient client;
        protected readonly string Uri;
        protected readonly SuhbatTopshiruvchi suhbat;
        protected readonly HelperTop helper;
        public StudentControl2(SuhbatTopshiruvchi topshiruvchi)
        {
            HttpClient http = new HttpClient();
            client = http;
            suhbat = topshiruvchi;
            string uri = "http://localhost:5135/api/Nomzod";
            Uri = uri;
            HelperTop top = new HelperTop(client,uri);
            helper = top;
            InitializeComponent();
            label1.Text = suhbat.Fullname;
            label5.Text = suhbat.Daraja;
            label6.Text = suhbat.Tajriba;
            label7.Text = suhbat.Tel;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            StudentUpdate students = new StudentUpdate(suhbat.Id, suhbat);
            students.Show();
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete",
                "A Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                var s = await helper.Delete(suhbat.Id);
                MessageBox.Show(s);
            }
            else
            {

            }
                
                
                
        }
    }
}
