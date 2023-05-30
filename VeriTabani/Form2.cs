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
    public partial class Form2 : Form
    {
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand com;
        public Form2()
        {
            InitializeComponent();
        }

        void PersonelGetir()
        {
            conn = new SqlConnection("Data Source=DESKTOP-PAA1B67;Initial Catalog=UrunSatis;Integrated Security=True");
            conn.Close();
            conn.Open();
            com = new SqlCommand("PersonelListele", conn);
            com.CommandType = CommandType.StoredProcedure;
            DataTable tablo = new DataTable();
            tablo.Load(com.ExecuteReader());
            dataGridView1.DataSource = tablo;
            conn.Close();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=DESKTOP-PAA1B67;Initial Catalog=UrunSatis;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT * FROM PersonelTip";
            com.Connection = conn;
            com.CommandType = CommandType.Text;
            SqlDataReader dr;
            conn.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Tip_ID"]);
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            com = new SqlCommand("Personelguncel", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sicilNo", SqlDbType.Int).Value = txtsicilno.Text.Trim();
            com.Parameters.AddWithValue("@tc", SqlDbType.VarChar).Value = maskedTc.Text.Trim();
            com.Parameters.AddWithValue("@ad", SqlDbType.VarChar).Value = txtad.Text.Trim();
            com.Parameters.AddWithValue("@soyad", SqlDbType.VarChar).Value = txtsoyad.Text.Trim();
            com.Parameters.AddWithValue("@personeltip", SqlDbType.Int).Value = comboBox1.Text.Trim();
            com.Parameters.AddWithValue("@telefon", SqlDbType.Money).Value = msktel.Text.Trim();
            com.ExecuteNonQuery();
            MessageBox.Show("Personel Başarı Şekilde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            PersonelGetir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PersonelGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtsicilno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            msktel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            com = new SqlCommand("Personelekle", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sicilNo", SqlDbType.Int).Value = txtsicilno.Text.Trim();
            com.Parameters.AddWithValue("@tc", SqlDbType.VarChar).Value = maskedTc.Text.Trim();
            com.Parameters.AddWithValue("@ad", SqlDbType.VarChar).Value = txtad.Text.Trim();
            com.Parameters.AddWithValue("@soyad", SqlDbType.VarChar).Value = txtsoyad.Text.Trim();
            com.Parameters.AddWithValue("@personeltip", SqlDbType.Int).Value = comboBox1.Text.Trim();
            com.Parameters.AddWithValue("@telefon", SqlDbType.Money).Value = msktel.Text.Trim();
            com.ExecuteNonQuery();
            MessageBox.Show("Personel Başarı Şekilde Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            PersonelGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            com = new SqlCommand("PersonelSil", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SicilNo", SqlDbType.Int).Value = txtsicilno.Text.Trim();
            com.ExecuteNonQuery();
            MessageBox.Show("Personel Başarı Şekilde Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            PersonelGetir();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AD SOYAD: FAİDE KARATAŞ" + "  " + " " +
                " BİLGİSAYAR MÜHENDİSİ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=DESKTOP-PAA1B67;Initial Catalog=UrunSatis;Integrated Security=True");
            conn.Close();
            conn.Open();
            com = new SqlCommand("AdresListele", conn);
            com.CommandType = CommandType.StoredProcedure;
            DataTable tablo = new DataTable();
            tablo.Load(com.ExecuteReader());
            dataGridView2.DataSource = tablo;
            conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=DESKTOP-PAA1B67;Initial Catalog=UrunSatis;Integrated Security=True");
            conn.Close();
            conn.Open();
            com = new SqlCommand("BolgeListele", conn);
            com.CommandType = CommandType.StoredProcedure;
            DataTable tablo = new DataTable();
            tablo.Load(com.ExecuteReader());
            dataGridView3.DataSource = tablo;
            conn.Close();
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=DESKTOP-PAA1B67;Initial Catalog=UrunSatis;Integrated Security=True");
            conn.Close();
            conn.Open();
            com = new SqlCommand("PersonelTipListele", conn);
            com.CommandType = CommandType.StoredProcedure;
            DataTable tablo = new DataTable();
            tablo.Load(com.ExecuteReader());
            dataGridView4.DataSource = tablo;
            conn.Close();
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox9.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            conn = new SqlConnection("Data Source=DESKTOP-PAA1B67;Initial Catalog=UrunSatis;Integrated Security=True");
            com = new SqlCommand("PersonelSayisi", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@personelTipi", comboBox2.Text);
            ds = new DataSet();
            da = new SqlDataAdapter(com);
            da.Fill(ds);
            dataGridView5.DataSource = ds.Tables[0];
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}
