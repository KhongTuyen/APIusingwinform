using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Call_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void HienThi()
        {
            string link = "https://localhost:44383/api/Product";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Products[]));
            object data = js.ReadObject(response.GetResponseStream());
            Products[] arrNV = data as Products[];
            show.DataSource = arrNV;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?id={0}&name={1}&price={2}&quantity={3}", txt_id.Text, txt_name.Text, txt_price.Text,txt_quantity.Text);
            string link = "https://localhost:44383/api/Product" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] arrByte = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = arrByte.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(arrByte, 0, arrByte.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThi();
                MessageBox.Show("Add success !");

            }
            else
            {
                MessageBox.Show("Add failed...");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThi();
            DataGridViewRow row = new DataGridViewRow();
            row = show.Rows[e.RowIndex];
            txt_id.Text = Convert.ToString(row.Cells[0].Value);
            txt_name.Text = Convert.ToString(row.Cells[1].Value);
            txt_price.Text = Convert.ToString(row.Cells[2].Value);
            txt_quantity.Text = Convert.ToString(row.Cells[3].Value);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            string postString = string.Format("?id={0}&name={1}&price={2}&quantity={3}", txt_id.Text, txt_name.Text, txt_price.Text, txt_quantity.Text);
            string link = "https://localhost:44383/api/Product" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] arrByte = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = arrByte.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(arrByte, 0, arrByte.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThi();
                MessageBox.Show("Update success !");

            }
            else
            {
                MessageBox.Show("Updtate failed...");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?id={0}", txt_id.Text);
            string link = "https://localhost:44383/api/Product" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] arrByte = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = arrByte.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(arrByte, 0, arrByte.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThi();
                MessageBox.Show("Delete success !");

            }
            else
            {
                MessageBox.Show("Delete failed...");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
