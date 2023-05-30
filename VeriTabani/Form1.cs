using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace VeriTabani
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataReader dr;
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanıcı = textBox1.Text;
            string sifre = textBox2.Text;
            conn = new SqlConnection("Data Source=DESKTOP-PAA1B67;Initial Catalog=UrunSatis;Integrated Security=True");
            com = new SqlCommand();
            conn.Open();
            com.Connection = conn;
            com.CommandText = "select *from Personel Where Ad= '" + textBox1.Text + "'And Tc= '" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("giriş başarılı");
                Form2 gecis = new Form2();
                gecis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı giriş");
            }
            conn.Close();
        }
    }
}
