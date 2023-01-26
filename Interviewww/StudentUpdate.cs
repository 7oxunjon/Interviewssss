using DATA.DTO;
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

namespace Interviewww
{
    public partial class StudentUpdate : Form
    {
        protected readonly HttpClient client;
        protected readonly int _id;
        protected readonly string Uri;
        protected readonly HelperTop helper;
        protected readonly SuhbatTopshiruvchi suhbat;

        public StudentUpdate(int Id, SuhbatTopshiruvchi topshiruvchi)
        {
            client = new HttpClient();
            Uri = "http://localhost:5135/api/Nomzod";
            suhbat = topshiruvchi;
            helper = new HelperTop(client, Uri);
            _id = Id;
            InitializeComponent();
            textBox6.Text = _id.ToString();
            textBox1.Text = suhbat.Fullname;
            textBox2.Text = suhbat.Daraja;
            textBox3.Text = suhbat.Tajriba;
            textBox4.Text = suhbat.Tel;
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SuhbatTopshirivchiDTO dTO = new SuhbatTopshirivchiDTO();
            dTO.Fullname = textBox1.Text;
            dTO.Daraja = textBox2.Text;
            dTO.Tajriba = textBox3.Text;
            dTO.Tel = textBox4.Text;
            dTO.OluvchiId = _id;
            
            DialogResult result = MessageBox.Show("Update ?",
               "Do you want a data update",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                
                string reg = await helper.Update(suhbat.Id, dTO);
                MessageBox.Show(reg);
            }
            else
            {

            }


        }


    }
}
