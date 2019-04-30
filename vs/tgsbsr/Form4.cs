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
    public partial class Form4 : Form
    {
        OleDbConnection konek = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\kuliah\s4\sbd\tgsbsr.mdb");
        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
            textBox8.Text = row.Cells[7].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                string sql = string.Format("INSERT INTO pelanggan VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", textBox1.Text,
                    textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                OleDbCommand perintah = new OleDbCommand(sql, konek);
                perintah.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan");
                perintah.Dispose();
            }
            catch(Exception)
            {
                MessageBox.Show("Data Gagal Disimpan");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            konek.Open();
            string query = "SELECT * FROM pelanggan";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM pelanggan";
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
                string sql = string.Format("UPDATE pelanggan SET kode='" + textBox1.Text + "',nama='" + textBox2.Text
                    + "',alamat='" + textBox3.Text + "',no_id='" + textBox4.Text + "',no_hp='"+ textBox5.Text
                    + "',pinjam='" + textBox6.Text + "',tgl_pinjam='" + textBox7.Text + "',lama_pinjam='" + textBox8.Text
                    + "'WHERE kode ='" + textBox1.Text + "'");
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
                string sql = string.Format("DELETE FROM pelanggan WHERE kode='" + textBox1.Text + "'");
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

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}
