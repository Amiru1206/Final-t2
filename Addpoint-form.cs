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
    public partial class Addpoint_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Addpoint_form()
        {
            InitializeComponent();
        }

        private void Addpoint_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Addpoint_form_Load(object sender, EventArgs e)
        {
            refresh();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
        }
        private void refresh()
        {
            comboBoxEx1.Items.Clear();
            comboBoxEx1.Text = "";
            try
            {
                //اینجا میتونی ور بزنی و شرط بزاری بگی کجای جدول رو نشون بده
                string query = "SELECT * FROM Points";
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                sc.Open();
                //دوتا خط پایین توضیح؟
                SqlCommand sqlCommand = new SqlCommand(query, sc);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxEx1.Items.Add(dr["codemelli"] + " /// " + dr["Reshtehvclass"]);
                }
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }
        string idcheck = "1";
        private void button3_Click(object sender, EventArgs e)
        {
            //
            string Codemelli = comboBoxEx1.SelectedItem.ToString();
            Codemelli = Codemelli.Substring(0, 10);
            idcheck = Codemelli;
            try
            {
                if (comboBoxEx1.Text.Substring(19,11) == "ریاضی فیزیک")
                {
                    string query = "SELECT * FROM Points WHERE Codemelli = '" + Codemelli + "'";
                    SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                    sc.Open();
                    //دوتا خط پایین توضیح؟
                    SqlCommand cmd = new SqlCommand(query, sc);
                    var dr = cmd.ExecuteReader();
                    dr.Read();
                    textBox1.Text = dr["codemelli"].ToString();
                    textBox2.Text = dr["reshtehvclass"].ToString();
                    textBox3.Text = dr["nriazi"].ToString();
                    textBox4.Text = dr["nphysic"].ToString();
                    textBox5.Text = dr["nshimi"].ToString();
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    button2.Enabled = true;
                    button4.Enabled = true;
                    button1.Enabled = false;
                    button3.Enabled = false;
                    sc.Close();
                }
                else
                {
                    string query = "SELECT * FROM Points WHERE Codemelli = '" + Codemelli + "'";
                    SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                    sc.Open();
                    //دوتا خط پایین توضیح؟
                    SqlCommand cmd = new SqlCommand(query, sc);
                    var dr = cmd.ExecuteReader();
                    dr.Read();
                    textBox1.Text = dr["codemelli"].ToString();
                    textBox2.Text = dr["reshtehvclass"].ToString();
                    textBox4.Text = dr["nphysic"].ToString();
                    textBox5.Text = dr["nshimi"].ToString();
                    textBox6.Text = dr["nzist"].ToString();
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    button2.Enabled = true;
                    button4.Enabled = true;
                    button1.Enabled = false;
                    button3.Enabled = false;
                    sc.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = true;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            refresh();
        }
        static bool isnumnriazi(string nriazi)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(nriazi);
        }
        static bool isnumnphysic(string nphysic)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(nphysic);
        }
        static bool isnumnshimi(string nshimi)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(nshimi);
        }
        static bool isnumnzist(string nzist)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(nzist);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //
            try
            {
                string codemelli = textBox1.Text;
                string reshtehvclass = textBox2.Text;
                string nriazi = textBox3.Text.Trim();
                string nphysic = textBox4.Text.Trim();
                string nshimi = textBox5.Text.Trim();
                string nzist = textBox6.Text.Trim();
                if (isnumnriazi(nriazi))
                {
                    if (isnumnphysic(nphysic))
                    {
                        if (isnumnshimi(nshimi))
                        {
                            if (isnumnzist(nzist))
                            {
                                string query = "UPDATE Points SET reshtehvclass=N'" + reshtehvclass + "'" +
                                    ",nriazi=N'" + nriazi + "',nphysic=N'" + nphysic + "'" +
                                    ",nshimi=N'" + nshimi + "',nzist=N'" + nzist + "'" +
                                    "Where codemelli='" + idcheck + "'";
                                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Me\Source\Repos\Final++\FINAL++\Database1.mdf;Integrated Security=True");
                                sc.Open();
                                //دوتا خط پایین توضیح؟
                                SqlCommand sqlCommand = new SqlCommand(query, sc);
                                int i = sqlCommand.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("با موفقیت ثبت شد ...");
                                    textBox1.Enabled = false;
                                    textBox2.Enabled = false;
                                    textBox3.Enabled = false;
                                    textBox4.Enabled = false;
                                    textBox5.Enabled = false;
                                    textBox6.Enabled = false;
                                    button2.Enabled = false;
                                    button4.Enabled = false;
                                    button1.Enabled = true;
                                    button3.Enabled = true;
                                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
                                    refresh();
                                }
                                else
                                {
                                    MessageBox.Show("عملیات ثبت ناموفق بود...");
                                }
                                sc.Close();
                            }
                            else
                            {
                                MessageBox.Show("لطفا برای نمره از کاراکتر عددی استفاده کنید ...");
                            }
                        }
                        else
                        {
                            MessageBox.Show("لطفا برای نمره از کاراکتر عددی استفاده کنید ...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفا برای نمره از کاراکتر عددی استفاده کنید ...");
                    }
                }
                else
                {
                    MessageBox.Show("لطفا برای نمره از کاراکتر عددی استفاده کنید ...");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        }
    }
}
