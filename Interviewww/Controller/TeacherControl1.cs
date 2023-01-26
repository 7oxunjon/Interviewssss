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
    public partial class TeacherControl1 : UserControl
    {
        protected readonly SuhbatOluvchi oluvchi;
        protected readonly HttpClient client;
        protected readonly string Uri;
        protected readonly ModelHelper model;
        public TeacherControl1(SuhbatOluvchi suhbat)
        {
            HttpClient http = new HttpClient();
            client = http;
            string uri = "http://localhost:5135/api/Suhbat";
            Uri = uri;
            oluvchi = suhbat;
            InitializeComponent();
            label1.Text = oluvchi.Fullname;
            label2.Text = oluvchi.Yunalish;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Students students = new Students(oluvchi);
            students.Show();
        }

        

        
    }
}
