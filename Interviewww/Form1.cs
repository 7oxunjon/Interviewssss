using DATA.Model;
using Helper.Help;
using Interviewww.Controller;
using GetTokenClaimsAIS;
namespace Interviewww
{
    public partial class Form1 : Form
    {
       
        protected readonly HttpClient client;
        protected readonly string Uri;
        protected readonly string UrI;
        protected readonly ModelHelper model;
        public Form1()
        {
            HttpClient http = new HttpClient();
            client = http;
            string uRi = "http://localhost:5135";
            string uri = "http://localhost:5135/api/Suhbat";
            Uri = uri;
            UrI = uRi;
            ModelHelper helper = new ModelHelper(client,Uri);
            model = helper;
            InitializeComponent();
            pictureBox1.ImageLocation = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSO-po4WrEi0cf6ouHgvGZn7VtDefIwpSfNcw&usqp=CAU";

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var con = await model.GetAll();
            PanRuyxat.Controls.Clear();
            foreach(var con2 in con)
            {
                AddControl(con2);
            }
        }
        private void AddControl(SuhbatOluvchi suhbat)
        {
            TeacherControl1 teacher = new TeacherControl1(suhbat);
            teacher.Dock = DockStyle.Top;
            PanRuyxat.Controls.Add(teacher);
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            if (PanRuyxat != null)
            {
                var con = await model.GetAll();
                PanRuyxat.Controls.Clear();
                foreach (var con2 in con)
                {
                    AddControl(con2);
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5135/");
            HttpResponseMessage http = await client.GetAsync("login");
            string rezualt = await http.Content.ReadAsStringAsync();
            label2.Text = rezualt;
        }
    }
}