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
    public partial class StudentControl1 : UserControl
    {
        protected readonly HttpClient client;
        protected readonly SuhbatTopshiruvchi suhbat;
        protected readonly string Uri;
        protected readonly HelperTop top;
        public StudentControl1(SuhbatTopshiruvchi topshiruvchi)
        {
            HttpClient http = new HttpClient();
            client = http;
            string uri = "http://localhost:5135/api/Nomzod";
            Uri = uri;
            HelperTop helper = new HelperTop(client, uri);
            top = helper;
            suhbat = topshiruvchi;
            InitializeComponent();
            label1.Text = suhbat.Fullname;
            label2.Text = suhbat.Tel;
        }
        
    }
}
