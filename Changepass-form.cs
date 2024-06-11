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
    public partial class Changepass_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Changepass_form()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Changepass_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text == textBox3.Text)
                {
                    string id = textBox4.Text;
                    string lpass = textBox1.Text;
                    string npass = textBox2.Text;
                    string query1 = "SELECT * FROM Login Where id='" + id + "'";
                    SqlConnection sc1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                    sc1.Open();
                    SqlCommand sqlCommand1 = new SqlCommand(query1, sc1);
                    var dr = sqlCommand1.ExecuteReader();
                    dr.Read();
                    if (dr["id"].ToString() == id)
                    {
                        if (dr["pass"].ToString() == lpass)
                        {
                            string query = "UPDATE Login SET pass='" + npass + "'" +
                            "Where id='" + id + "'";
                            SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                            sc.Open();
                            SqlCommand sqlCommand = new SqlCommand(query, sc);
                            int i = sqlCommand.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("عملیات تغییر رمز رمز عبور با موفقیت انجام شد ...");
                                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                            }
                            else
                                MessageBox.Show("عملیات تفییر رمز عبور ناموفق بود ...");
                            sc.Close();
                        }
                        else
                        {
                            MessageBox.Show("رمز عبور صحیح نمیباشد ...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("نام کاربری صحیح نمیباشد ...");
                    }
                    sc1.Close();
                }
                else
                {
                    MessageBox.Show("عدم تطابق رمز عبور جدید ...");
                }
            }
            catch(Exception ex)
            {
                if(ex.Message == "Invalid attempt to read when no data is present.")
                {
                    MessageBox.Show("نام کاربری صحیح نمیباشد");
                }
                else
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
