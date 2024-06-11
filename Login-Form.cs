using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace FINAL__
{
    public partial class Login_Form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Login_Form()
        {
            InitializeComponent();
        }
        int i = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (i == 0)
            {
                i = 1;
                textBoxX1.UseSystemPasswordChar = false;
            }
            else
            {
                i = 0;
                textBoxX1.UseSystemPasswordChar = true;
            }
        }
        Main_form main_Form = new Main_form();
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBoxX2.Text.Trim();
                string pass = textBoxX1.Text.Trim();
                int id1 = id.Length;
                int pass1 = pass.Length;
                //برای پر بودن فیلد ها
                if (id1 == 0)
                {
                    MessageBox.Show(".لطفا نام کاربری را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //برای پر بودن فیلد ها
                    if (pass1 == 0)
                    {
                        MessageBox.Show(".لطفا رمز عبور را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //برای عدد بودن ورودی های کاربر
                        if (isnumid(id))
                        {
                            //برای عدد بودن ورودی های کاربر
                            if (isnumpass(pass))
                            {
                                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                                string query = "SELECT * FROM Login Where id='" + int.Parse(id) + "'";
                                sc.Open();
                                SqlCommand cmd = new SqlCommand(query, sc);
                                var dr = cmd.ExecuteReader();
                                dr.Read();
                                //برای صحیح بودن رمز عبور
                                if (dr["pass"].ToString() == pass)
                                {
                                    this.Hide();
                                    main_Form.Show();
                                }
                                else
                                    MessageBox.Show(".رمز عبور صحیح نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                sc.Close();
                            }
                            else
                                MessageBox.Show("... لطفا فقط از کاراکتر های عددی استفاده کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                            MessageBox.Show("... لطفا فقط از کاراکتر های عددی استفاده کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch(Exception ex)
            {
                //برای صحیح بودن آی دی
                if (ex.Message == "Invalid attempt to read when no data is present.")
                {
                    MessageBox.Show(".نام کاربری صحیح نمیباشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        static bool isnumid(string id)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(id);
        }
        static bool isnumpass(string pass)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(pass);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
        }
    }
}