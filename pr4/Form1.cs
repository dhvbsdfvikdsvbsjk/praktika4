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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=PC310-15\SQLEXPRESS;Initial Catalog=bretta;Integrated Security=True");
        SqlCommand cmd;
        public static bool qu =true;
        public Form1()
        {
            InitializeComponent();
            button6.Visible = false;
            button7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {               
                con.Open();
                string check = "select position from yser where login = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                cmd = new SqlCommand(check, con);
                var res = cmd.ExecuteScalar().ToString();
                roli.rol = res;
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {                  
                    con.Close();
                    MessageBox.Show(res);
                    Form2 f = new Form2();
                    f.Show();
                    Hide();
                }
                else
                {
                    qu = false;
                    con.Close();
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            else
            {
                MessageBox.Show("Пароль не совпадает");
            }


        }
        public class yu
        {
            public string prover(string ae, string f)
            {
                ae = "true";
                f = "false";
                if (qu == true)
                {
                    return ae;
                }
                return f;
            }
        }             
        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox4.Text.Length == 0 | textBox5.Text.Length == 0 | textBox6.Text.Length == 0)
            {
                MessageBox.Show("Пустые поля");
            }
            else
            {
                string check = "INSERT INTO [dbo].[yser]([position],[login],[password])VALUES('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd = new SqlCommand(check, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Добавлено!");
                Form2 f = new Form2();
                f.Show();
                Hide();
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.UseSystemPasswordChar = true;
            button6.Visible = true;
            button4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            button7.Visible = true;
            button3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.UseSystemPasswordChar = false;
            button6.Visible = false;
            button4.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            button7.Visible = false;
            button3.Visible = true;
        }
    }
}
