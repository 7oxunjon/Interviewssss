using DATA.DTO;
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
    public partial class StudentReg : Form
    {
        protected readonly HttpClient client;
        protected readonly HelperTop helper;
        protected readonly string Uri;
        protected readonly int Id;
        public StudentReg(int id)
        {
            client = new HttpClient();
            string uri = "http://localhost:5135/api/Nomzod";
            Uri = uri;
            helper = new HelperTop(client, uri);
            Id = id;
            InitializeComponent();
            textBox5.Text = Id.ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SuhbatTopshirivchiDTO dTO = new SuhbatTopshirivchiDTO();
            dTO.Fullname = textBox1.Text;
            dTO.Daraja = textBox2.Text;
            dTO.Tajriba = textBox3.Text;
            dTO.Tel = textBox4.Text;
            dTO.OluvchiId = Id;
            DialogResult result = MessageBox.Show("Update ?",
                "Do you want a date update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                string reg = await helper.Insert(dTO);
                MessageBox.Show(reg);
            }
            //DialogResult result = MessageBox.Show("Update ?",
            //   "Do you want a data update",
            //   MessageBoxButtons.YesNo,
            //   MessageBoxIcon.Question,
            //   MessageBoxDefaultButton.Button2);
            //if (result == DialogResult.Yes)
            //{
            //    string reg = await _model.InsertReg(_regionDTO);
            //    MessageBox.Show(reg);
            //}
            else
            {

            }
        }
    }
}
