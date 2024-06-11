using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace FINAL__
{
    public partial class Addstudent_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Addstudent_form()
        {
            InitializeComponent();
        }

        private void Addstudent_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            textBoxX4.Text = textBoxX5.Text = textBoxX1.Text = textBoxX2.Text = textBoxX3.Text = "";
            comboBox1.SelectedItem = comboBox2.SelectedItem = comboBox3.SelectedItem = comboBox4.SelectedItem = "";
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        static bool isnumcodemelli(string codemelli)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(codemelli);
        }
        static bool isnumbdate(string bdate)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(bdate);
        }
        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Codemelli = textBoxX1.Text.Trim();
                if (Codemelli.Length == 10)
                {
                    if (isnumcodemelli(Codemelli))
                    {
                        string reshtehvclass = comboBox2.Text;
                        if (reshtehvclass.Length == 0)
                        {
                            MessageBox.Show("لطفا کلاس را انتخاب کنید ...");
                        }
                        else
                        {
                            string query = "INSERT INTO Points (Codemelli,reshtehvclass,nriazi,nphysic,nshimi,nzist)" +
                            "VALUES(N'" + Codemelli + "',N'" + reshtehvclass + "','','','','')";
                            SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                            sc.Open();
                            SqlCommand cmd = new SqlCommand(query, sc);
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {

                            }
                            else
                            {
                                MessageBox.Show("عملیات ثبت ناموفق بود...");
                            }
                            sc.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفا برای کد ملی فقط از کاراکتر عددی استفاده کنید ...");
                    }
                    
                }
                else
                {
                    MessageBox.Show("لطفا کد ملی را کامل و صحیح وارد کنید");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string Codemelli = textBoxX1.Text.Trim();
                if(Codemelli.Length == 10)
                {
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
                                if(isnumbdate(textBoxX5.Text))
                                {
                                    string bdate = textBoxX5.Text + "/" + comboBox3.Text + "/" + comboBox4.Text;
                                    string payeh = comboBox1.Text;
                                    string claas = (comboBox2.Text).Substring(0, 3); ;
                                    string query = "INSERT INTO Students (Codemelli,name,lname,fname,bdate,payeh,class)" +
                                    "VALUES(N'" + Codemelli + "',N'" + name + "',N'" + lname + "',N'" + fname + "'" +
                                    ",N'" + bdate + "',N'" + payeh + "',N'" + claas + "')";
                                    SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                                    sc.Open();
                                    SqlCommand cmd = new SqlCommand(query, sc);
                                    int i = cmd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        textBoxX4.Text = textBoxX5.Text = textBoxX1.Text = textBoxX2.Text = textBoxX3.Text = "";
                                        comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("عملیات ثبت ناموفق بود...");
                                    }
                                    sc.Close();
                                }
                                else
                                {
                                    MessageBox.Show("لطفا برای سال تولد از کاراکتر عددی استفاده کنید ...");
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفا سال تولد را صحیح وارد کنید ...");
                    }
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refresh()
        {
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
                    comboBox2.Items.Add(dr["ID"] + ":" + dr["reshteh"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Addstudent_form_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}