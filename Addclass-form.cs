using DevComponents.DotNetBar.Controls;
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
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FINAL__
{
    public partial class Addclass_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Addclass_form()
        {
            InitializeComponent();
        }

        private void Addclass_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Addclass_form_Load(object sender, EventArgs e)
        {
            Refresh();
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            buttonX2.Enabled = false;
            buttonX3.Enabled = false;

        }
        private void Refresh()
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox1.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = "";
            try
            {
                //اینجا میتونی ور بزنی و شرط بزاری بگی کجای جدول رو نشون بده
                string query = "SELECT * FROM Teachers Where lesson=N'ریاضی'";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand sqlCommand = new SqlCommand(query, sc);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["codemelli"] + ":" + dr["name"] + " " + dr["Lname"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                //اینجا میتونی ور بزنی و شرط بزاری بگی کجای جدول رو نشون بده
                string query = "SELECT * FROM Teachers Where lesson=N'فیزیک'";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand sqlCommand = new SqlCommand(query, sc);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["codemelli"] + ":" + dr["name"] + " " + dr["Lname"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                //اینجا میتونی ور بزنی و شرط بزاری بگی کجای جدول رو نشون بده
                string query = "SELECT * FROM Teachers Where lesson=N'شیمی'";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand sqlCommand = new SqlCommand(query, sc);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    comboBox4.Items.Add(dr["codemelli"] + ":" + dr["name"] + " " + dr["Lname"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                //اینجا میتونی ور بزنی و شرط بزاری بگی کجای جدول رو نشون بده
                string query = "SELECT * FROM Teachers Where lesson=N'زیست'";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand sqlCommand = new SqlCommand(query, sc);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["codemelli"] + ":" + dr["name"] + " " + dr["Lname"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("لطفا رشته تحصیلی را انتخاب کنید ...");
                }
                else
                {
                    comboBox2.Enabled = false;
                    if (comboBox2.Text == "ریاضی فیزیک")
                    {
                        comboBox1.Enabled = true;
                        comboBox3.Enabled = true;
                        comboBox4.Enabled = true;
                        buttonX2.Enabled = true;
                        buttonX1.Enabled = false;
                        buttonX3.Enabled = true;
                    }
                    else
                    {
                        comboBox5.Enabled = true;
                        comboBox3.Enabled = true;
                        comboBox4.Enabled = true;
                        buttonX2.Enabled = true;
                        buttonX1.Enabled = false;
                        buttonX3.Enabled = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            buttonX2.Enabled = false;
            buttonX1.Enabled = true;
            buttonX3.Enabled = false;
            comboBox2.Enabled = true;
            comboBox1.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = "";
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "ریاضی فیزیک")
                {
                    if(comboBox1.Text.Length == 0)
                    {
                        MessageBox.Show("لطفا استاد ریاضی را انتخاب کنید ...");
                    }
                    else
                    {
                        if (comboBox3.Text.Length == 0)
                        {
                            MessageBox.Show("لطفا استاد فیزیک را انتخاب کنید ...");
                        }
                        else
                        {
                            if (comboBox4.Text.Length == 0)
                            {
                                MessageBox.Show("لطفا استاد شیمی را انتخاب کنید ...");
                            }
                            else
                            {
                                string reshteh = comboBox2.Text;
                                string triazi = (comboBox1.Text).Substring(0, 10);
                                string tphysic = (comboBox3.Text).Substring(0, 10);
                                string tshimi = (comboBox4.Text).Substring(0, 10);
                                string query = "INSERT INTO classes (reshteh,triazi,tphysic,tshimi)" +
                                            "VALUES(N'" + reshteh + "',N'" + triazi + "',N'" + tphysic + "',N'" + tshimi + "')";
                                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                                sc.Open();
                                //دوتا خط پایین توضیح؟
                                SqlCommand sqlCommand = new SqlCommand(query, sc);
                                int i = sqlCommand.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("با موفقیت ثبت شد ...");
                                    comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox1.Text = "";
                                    Refresh();
                                    comboBox1.Enabled = false;
                                    comboBox3.Enabled = false;
                                    comboBox4.Enabled = false;
                                    comboBox5.Enabled = false;
                                    buttonX2.Enabled = false;
                                    buttonX3.Enabled = false;
                                    buttonX1.Enabled = true;
                                    comboBox2.Enabled = true;
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
                    if (comboBox3.Text.Length == 0)
                    {
                        MessageBox.Show("لطفا استاد فیزیک را انتخاب کنید ...");
                    }
                    else
                    {
                        if (comboBox4.Text.Length == 0)
                        {
                            MessageBox.Show("لطفا استاد شیمی را انتخاب کنید ...");

                        }
                        else
                        {
                            if (comboBox5.Text.Length == 0)
                            {
                                MessageBox.Show("لطفا استاد زیست را انتخاب کنید ...");
                            }
                            else
                            {
                                string reshteh = comboBox2.Text;
                                string tphysic = (comboBox3.Text).Substring(0, 10);
                                string tshimi = (comboBox4.Text).Substring(0, 10);
                                string tzist = (comboBox5.Text).Substring(0, 10);
                                string query = "INSERT INTO classes (reshteh,tphysic,tshimi,tzist)" +
                                            "VALUES(N'" + reshteh + "',N'" + tphysic + "',N'" + tshimi + "',N'" + tzist + "')";
                                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                                sc.Open();
                                //دوتا خط پایین توضیح؟
                                SqlCommand sqlCommand = new SqlCommand(query, sc);
                                int i = sqlCommand.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("با موفقیت ثبت شد ...");
                                    comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox1.Text = "";
                                    Refresh();
                                    comboBox1.Enabled = false;
                                    comboBox3.Enabled = false;
                                    comboBox4.Enabled = false;
                                    comboBox5.Enabled = false;
                                    buttonX2.Enabled = false;
                                    buttonX3.Enabled = false;
                                    buttonX1.Enabled = true;
                                    comboBox2.Enabled = true;
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
