using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace tgsbsr
{
    public partial class Form5 : Form
    {
        OleDbConnection konek = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\kuliah\s4\sbd\tgsbsr.mdb");
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            konek.Open();
            string query = "SELECT * FROM kamera";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("INSERT INTO kamera VALUES('{0}','{1}','{2}','{3}')", textBox1.Text,
                    textBox2.Text, textBox3.Text, textBox4.Text);
                OleDbCommand perintah = new OleDbCommand(sql, konek);
                perintah.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan");
                perintah.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Data Gagal Disimpan");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM kamera";
                OleDbCommand perintah = new OleDbCommand(query, konek);
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(perintah);
                adapter.Fill(ds, "res");
                dataGridView1.DataSource = ds.Tables["res"];
                adapter.Dispose();
                perintah.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal menampilkan data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("UPDATE kamera SET tipe='" + textBox1.Text + "',merk='" + textBox2.Text
                   + "',harga='" + textBox3.Text + "',stok='" + textBox4.Text
                   + "'WHERE tipe ='" + textBox1.Text + "'");
                OleDbCommand perintah = new OleDbCommand(sql, konek);
                perintah.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diedit");
                perintah.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Data Gagal Diedit");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("DELETE FROM kamera WHERE tipe='" + textBox1.Text + "'");
                OleDbCommand perintah = new OleDbCommand(sql, konek);
                perintah.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
                perintah.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Data Gagal Dihapus");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
