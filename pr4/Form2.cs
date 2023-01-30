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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=PC310-15\SQLEXPRESS;Initial Catalog=bretta;Integrated Security=True");
        SqlCommand cmd;
        public int count = 1;
        public Form2()
        {
            InitializeComponent();
            string check = "select question from questions where id = '" + count + "'";
            cmd = new SqlCommand(check, con);
            con.Open();
            var res = cmd.ExecuteScalar().ToString();
            label8.Text = res;
            con.Close();
            if(roli.rol != "admin")
            {
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcount = new SqlCommand("use bretta select count(id) from questions", con);
            var countque = cmdcount.ExecuteScalar().ToString();
            con.Close();
            if (count >= Convert.ToInt32(countque))
            {
                MessageBox.Show("Загадки кончились!");
                Application.Exit();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select question from questions where answer = '" + textBox1.Text + "' and id = '" + count + "'", con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    con.Close();
                    MessageBox.Show("Правильно!!!");
                    count++;
                    string check = "select question from questions where id = '" + count + "'";
                    cmd = new SqlCommand(check, con);
                    con.Open();
                    var res = cmd.ExecuteScalar().ToString();
                    label8.Text = res;
                    con.Close();
                    label1.Text = count.ToString();
                    textBox1.Text = "";
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Неправильно");
                }
            }                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
