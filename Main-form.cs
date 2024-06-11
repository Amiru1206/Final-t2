using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL__
{
    public partial class Main_form : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public Main_form()
        {
            InitializeComponent();
        }
        private void Main_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //روش اصولی بهم جواب نداد مجبور شدم از این استفاده کنم
            //پرسش از استاد؟
            Environment.Exit(0);
        }
        private void Main_form_Load(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
                string date = persianCalendar.GetYear(DateTime.Now).ToString("0000/") + persianCalendar.GetMonth(DateTime.Now).ToString("00/") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("00");
                //جرا تو استرینگ نزاشتم ؟ برای اینکه اگر یک چیزی رو به جز ابجکت با رشته استرینگ جمع کنیم خودش استرینگ میشه...
                string time = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                labelItem1.Text = date + "    " + time;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
                string date = persianCalendar.GetYear(DateTime.Now).ToString("0000/") + persianCalendar.GetMonth(DateTime.Now).ToString("00/") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("00");
                //جرا تو استرینگ نزاشتم ؟ برای اینکه اگر یک چیزی رو به جز ابجکت با رشته استرینگ جمع کنیم خودش استرینگ میشه...
                string time = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                labelItem1.Text = date + "    " + time;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        Addstudent_form addstudent_Form = new Addstudent_form();   
        private void buttonItem1_Click(object sender, EventArgs e)
        {
                addstudent_Form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        Liststudents_form Liststudent_Form = new Liststudents_form();
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Liststudent_Form.Show();
        }
        Reportcard_form reportcard_Form = new Reportcard_form();
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            reportcard_Form.Show();
        }
        Addteachers_form addteachers_Form = new Addteachers_form();
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            addteachers_Form.Show();
        }
        Listteachers_form Listteachers_form = new Listteachers_form();
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Listteachers_form.Show();
        }
        Addclass_form addclass_Form = new Addclass_form();
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            addclass_Form.Show();
        }
        Listclasses_form listclasses_Form = new Listclasses_form();
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            listclasses_Form.Show();
        }
        Addpoint_form addpoint_Form = new Addpoint_form();
        private void buttonItem8_Click(object sender, EventArgs e)
        {
            addpoint_Form.Show();
        }
        Changepass_form changepass_Form = new Changepass_form();
        private void buttonItem9_Click(object sender, EventArgs e)
        {
            changepass_Form.Show();
        }
    }
}
