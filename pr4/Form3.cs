using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr4
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=PC310-15\SQLEXPRESS;Initial Catalog=bretta;Integrated Security=True");
        SqlCommand cmd;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string check = "INSERT INTO [dbo].[questions]([question],[answer])VALUES('" + richTextBox1.Text + "','" + textBox1.Text + "')";
            cmd = new SqlCommand(check, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Добавлено!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            Hide();
        }
    }
}
