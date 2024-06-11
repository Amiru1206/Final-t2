using DevComponents.DotNetBar;
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
    public partial class Reportcard_form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Reportcard_form()
        {
            InitializeComponent();
        }

        private void Reportcard_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            comboBoxEx1.Items.Clear();
            comboBoxEx1.Text = "";
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
        }

        private void Reportcard_form_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string codemelli = comboBoxEx1.Text.Substring(0, 10);
                string query = "SELECT * FROM Points Where Codemelli='" + codemelli + "'";
                SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Me\\Source\\Repos\\Final++\\FINAL++\\Database1.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand cmd = new SqlCommand(query, sc);
                var dr = cmd.ExecuteReader();
                dr.Read();
                if (dr["reshtehvclass"].ToString().Substring(4, 11) == "ریاضی فیزیک")
                {
                    string nr = dr["nriazi"].ToString().Trim();
                    string np = dr["nphysic"].ToString().Trim();
                    string ns = dr["nshimi"].ToString().Trim();
                    int nr1, np1, ns1;
                    if (nr == "")
                    {
                        nr1 = 0;
                    }
                    else
                    {
                        nr1 = int.Parse(nr);
                    }
                    if (np == "")
                    {
                        np1 = 0;
                    }
                    else
                    {
                        np1 = int.Parse(np);
                    }
                    if (ns == "")
                    {
                        ns1 = 0;
                    }
                    else
                    {
                        ns1 = int.Parse(ns);
                    }
                    int nj = nr1 + np1 + ns1;
                    float ave = nj / 3;
                    Refresh();
                    MessageBox.Show("ریاضی :" + nr1 + '\n' + "فیزیک :" + np1 + '\n' + "شیمی :" + ns1 + '\n' + "معدل :" + ave);
                }
                else
                {
                    string nz = dr["nzist"].ToString().Trim();
                    string np = dr["nphysic"].ToString().Trim();
                    string ns = dr["nshimi"].ToString().Trim();
                    int nz1, np1, ns1;
                    if (nz == "")
                    {
                        nz1 = 0;
                    }
                    else
                    {
                        nz1 = int.Parse(nz);
                    }
                    if (np == "")
                    {
                        np1 = 0;
                    }
                    else
                    {
                        np1 = int.Parse(np);
                    }
                    if (ns == "")
                    {
                        ns1 = 0;
                    }
                    else
                    {
                        ns1 = int.Parse(ns);
                    }
                    int nj = nz1 + np1 + ns1;
                    float ave = nj / 3;
                    Refresh();
                    MessageBox.Show("ریاضی :" + nz1 + '\n' + "فیزیک :" + np1 + '\n' + "شیمی :" + ns1 + '\n' + "معدل :" + ave);
                }
                sc.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
