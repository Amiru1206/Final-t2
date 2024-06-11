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

namespace FINAL__
{
    public partial class Liststudents_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Liststudents_form()
        {
            InitializeComponent();
        }
        
        private void Liststudents_form_Load(object sender, EventArgs e)
        {
            Refresh();
            comboBox2.Enabled = false;
            buttonX1.Enabled = false;
            button4.Enabled = false;
        }
        private void Refresh()
        {
            comboBoxEx1.Items.Clear();
            comboBoxEx1.Text = "";
            textBoxX1.Text = textBoxX2.Text = textBoxX3.Text = textBoxX4.Text = textBoxX5.Text = "";
            comboBoxEx1.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = "";
            try
            {
                //اینجا میتونی ور بزنی و شرط بزاری بگی کجای جدول رو نشون بده
                string query = "SELECT * FROM Students";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand sqlCommand = new SqlCommand(query, sc);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxEx1.Items.Add(dr["codemelli"] + ":" + dr["name"] + " " + dr["Lname"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            try
            {
                //اینجا میتونی ور بزنی و شرط بزاری بگی کجای جدول رو نشون بده
                string query = "SELECT * FROM classes";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand sqlCommand = new SqlCommand(query, sc);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["ID"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Liststudents_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string codemelli = comboBoxEx1.SelectedItem.ToString();
            codemelli = codemelli.Substring(0, codemelli.IndexOf(":"));
            try
            {
                string query = "DELETE FROM Students WHERE Codemelli = '" + codemelli + "'";
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("با موفقیت حذف شد ...");
                    Refresh();
                }
                else
                    MessageBox.Show("عملیات حذف ناموفق بود ...");
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string query = "DELETE FROM Points WHERE Codemelli = '" + codemelli + "'";
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand cmd = new SqlCommand(query, sc);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("با موفقیت حذف شد ...");
                    Refresh();
                }
                else
                    MessageBox.Show("عملیات حذف ناموفق بود ...");
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string idcheck = "1";
        private void button3_Click(object sender, EventArgs e)
        {
            string Codemelli = comboBoxEx1.SelectedItem.ToString();
            Codemelli = Codemelli.Substring(0, Codemelli.IndexOf(":"));
            idcheck = Codemelli;
            try
            {
                string query = "SELECT * FROM Students WHERE Codemelli = '" + Codemelli + "'";
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand cmd = new SqlCommand(query, sc);
                var dr = cmd.ExecuteReader();
                dr.Read();
                textBoxX1.Text = dr["codemelli"].ToString();
                textBoxX2.Text = dr["name"].ToString();
                textBoxX3.Text = dr["Lname"].ToString();
                textBoxX4.Text = dr["Fname"].ToString();
                textBoxX5.Text = (dr["bdate"].ToString()).Substring(0, 4);
                comboBox1.Text = dr["payeh"].ToString();
                comboBox2.Text = dr["class"].ToString();
                comboBox3.Text = (dr["bdate"].ToString()).Substring(5, 2);
                comboBox4.Text = (dr["bdate"].ToString()).Substring(8, 2);
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                buttonX1.Enabled = true;
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = textBoxX2.Text = textBoxX3.Text = textBoxX4.Text = textBoxX5.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            buttonX1.Enabled= false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string Codemelli = textBoxX1.Text.Trim();
                string name = textBoxX2.Text;
                string lname = textBoxX3.Text;
                string fname = textBoxX4.Text;
                if (textBoxX5.Text.Length == 4)
                {
                    if (comboBox3.Text == "")
                    {
                        MessageBox.Show("لطفا ماه تولد را صحیح وارد کنید ...");
                    }
                    else
                    {
                        if (comboBox4.Text == "")
                        {
                            MessageBox.Show("لطفا روز تولد راه وارد کنید ...");
                        }
                        else
                        {
                            string bdate = textBoxX5.Text + "/" + comboBox3.Text + "/" + comboBox4.Text;
                            string payeh = comboBox1.Text;
                            string claas = comboBox2.Text;
                            string query = "UPDATE Students SET codemelli=N'" + Codemelli + "'" +
                            ",name=N'" + name + "',Lname=N'" + lname + "'" +
                            ",Fname=N'" + fname + "',bdate=N'" + bdate + "',payeh=N'" + payeh + "',class=N'" + claas + "'" +
                            "Where codemelli='" + idcheck + "'";
                            SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                            sc.Open();
                            SqlCommand cmd = new SqlCommand(query, sc);
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("با موفقیت ثبت شد ...");
                                textBoxX4.Text = textBoxX5.Text = textBoxX1.Text = textBoxX2.Text = textBoxX3.Text = "";
                                comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = "";
                                Refresh();
                                button1.Enabled = true;
                                button2.Enabled = true;
                                button3.Enabled = true;
                                button4.Enabled = false;
                                buttonX1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("عملیات ثبت ناموفق بود...");
                            }
                            sc.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("لطفا سال تولد را صحیح وارد کنید ...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
