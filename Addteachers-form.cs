using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL__
{
    public partial class Addteachers_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Addteachers_form()
        {
            InitializeComponent();
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
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string Codemelli = textBoxX1.Text.Trim();
                if (isnumcodemelli(Codemelli))
                {
                    if (isnumbdate(textBoxX5.Text))
                    {
                        if (Codemelli.Length == 10)
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
                                        string bdate = textBoxX5.Text + "/" + comboBox3.Text + "/" + comboBox4.Text;
                                        string Lesson = comboBox2.Text;
                                        if (comboBox2.Text == "")
                                        {
                                            MessageBox.Show("لطفا درس مربوطه را وارد کنید ...");
                                        }
                                        else
                                        {
                                            string query = "INSERT INTO Teachers (Codemelli,name,lname,fname,bdate,lesson)" +
                                            "VALUES(N'" + Codemelli + "',N'" + name + "',N'" + lname + "',N'" + fname + "'" +
                                            ",N'" + bdate + "',N'" + Lesson + "')";
                                            SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                                            sc.Open();
                                            SqlCommand cmd = new SqlCommand(query, sc);
                                            int i = cmd.ExecuteNonQuery();
                                            if (i > 0)
                                            {
                                                MessageBox.Show("با موفقیت ثبت شد ...");
                                                textBoxX4.Text = textBoxX5.Text = textBoxX1.Text = textBoxX2.Text = textBoxX3.Text = "";
                                                comboBox2.Text = comboBox3.Text = comboBox4.Text = "";
                                            }
                                            else
                                            {
                                                MessageBox.Show("عملیات ثبت ناموفق بود...");
                                            }
                                            sc.Close();
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
                            MessageBox.Show("لطفا کد ملی را صحیح وارد کنید ...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفا برای سال تولد فقط از کاراکتر عددی استفاده کنید ...");
                    }
                }
                else
                {
                    MessageBox.Show("لطفا برای کد ملی فقط از کاراکتر عددی استفاده کنید ...");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
