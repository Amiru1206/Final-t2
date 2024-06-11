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

namespace FINAL__
{
    public partial class Listclasses_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Listclasses_form()
        {
            InitializeComponent();
        }

        private void Listclasses_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Listclasses_form_Load(object sender, EventArgs e)
        {
            Refresh();
            Refresh2();
            buttonX1.Enabled = false;
            button4.Enabled = false;
            buttonX4.Enabled = false;
            buttonX3.Enabled = false;
            buttonX2.Enabled = false;
        }
        private void Refresh()
        {
            comboBox2.Enabled = comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled = false;
            comboBoxEx1.Items.Clear();
            comboBoxEx1.Text = "";
            textBoxX1.Text = "";
            comboBoxEx1.Text = comboBox1.Text = comboBox3.Text = comboBox4.Text = comboBox2.Text = comboBox5.Text = "";
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
                    comboBoxEx1.Items.Add(dr["ID"] + ": " + dr["reshteh"]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string id = comboBoxEx1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf(":"));
            try
            {
                string query = "DELETE FROM classes WHERE Id = '" + id + "'";
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
        string idcheck = "1";
        private void button3_Click(object sender, EventArgs e)
        {
            string id = comboBoxEx1.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf(":"));
            idcheck = id;
            try
            {
                string query = "SELECT * FROM classes WHERE id = '" + id + "'";
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand cmd = new SqlCommand(query, sc);
                var dr = cmd.ExecuteReader();
                dr.Read();
                textBoxX1.Text = dr["id"].ToString();
                comboBox1.Text = dr["reshteh"].ToString();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                buttonX2.Enabled  = buttonX4.Enabled = true;
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Refresh2()
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = "";
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
                    comboBox2.Items.Add(dr["codemelli"] + ":" + dr["name"] + " " + dr["Lname"]);
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
        private void buttonX4_Click(object sender, EventArgs e)
        {
            Refresh2();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("لطفا رشته تحصیلی را انتخاب کنید ...");
                }
                else
                {
                    comboBox1.Enabled = false;
                    if (comboBox1.Text == "ریاضی فیزیک")
                    {
                        comboBox2.Enabled = true;
                        comboBox3.Enabled = true;
                        comboBox4.Enabled = true;
                        buttonX3.Enabled = true;
                        buttonX2.Enabled = false;
                        buttonX1.Enabled = true;
                    }
                    else
                    {
                        comboBox5.Enabled = true;
                        comboBox3.Enabled = true;
                        comboBox4.Enabled = true;
                        buttonX3.Enabled = true;
                        buttonX2.Enabled = false;
                        buttonX1.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            buttonX1.Enabled=buttonX3.Enabled = false;
            comboBox2.Enabled = comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled=false;
            buttonX2.Enabled = comboBox1.Enabled = true;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = "";
            textBoxX1.Enabled = comboBox1.Enabled = comboBox2.Enabled = comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled = false;
            buttonX1.Enabled = buttonX2.Enabled = buttonX3.Enabled = buttonX4.Enabled = button4.Enabled =false;
            button1.Enabled = button2.Enabled = button3.Enabled = true;

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "ریاضی فیزیک")
                {
                    if (comboBox2.Text.Length == 0)
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
                                string reshteh = comboBox1.Text;
                                string triazi = (comboBox2.Text).Substring(0, 10);
                                string tphysic = (comboBox3.Text).Substring(0, 10);
                                string tshimi = (comboBox4.Text).Substring(0, 10);
                                string query = "UPDATE classes SET reshteh=N'" + reshteh + "'" +
                                ",triazi=N'" + triazi + "',tphysic=N'" + tphysic + "'" +
                                ",tshimi=N'" + tshimi + "'" +
                                "Where id='" + idcheck + "'";
                                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                                sc.Open();
                                //دوتا خط پایین توضیح؟
                                SqlCommand sqlCommand = new SqlCommand(query, sc);
                                int i = sqlCommand.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("با موفقیت ثبت شد ...");
                                    Refresh();
                                    textBoxX1.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = "";
                                    textBoxX1.Enabled = comboBox1.Enabled = comboBox2.Enabled = comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled = false;
                                    buttonX1.Enabled = buttonX2.Enabled = buttonX3.Enabled = buttonX4.Enabled = button4.Enabled = false;
                                    button1.Enabled = button2.Enabled = button3.Enabled = true;
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
                                string reshteh = comboBox1.Text;
                                string tphysic = (comboBox3.Text).Substring(0, 10);
                                string tshimi = (comboBox4.Text).Substring(0, 10);
                                string tzist = (comboBox5.Text).Substring(0, 10);
                                string query = "UPDATE classes SET reshteh=N'" + reshteh + "'" +
                                ",tphysic=N'" + tphysic + "'" +
                                ",tshimi=N'" + tshimi + "',tzist=N'" + tzist + "'" +
                                "Where id='" + idcheck + "'";
                                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                                sc.Open();
                                //دوتا خط پایین توضیح؟
                                SqlCommand sqlCommand = new SqlCommand(query, sc);
                                int i = sqlCommand.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("با موفقیت ثبت شد ...");
                                    Refresh();
                                    textBoxX1.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = "";
                                    textBoxX1.Enabled = comboBox1.Enabled = comboBox2.Enabled = comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled = false;
                                    buttonX1.Enabled = buttonX2.Enabled = buttonX3.Enabled = buttonX4.Enabled = button4.Enabled = false;
                                    button1.Enabled = button2.Enabled = button3.Enabled =  true;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
