using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form2 : Form
    {
        Contact_DBEntities db = new Contact_DBEntities();
        public int contactId = 0;
        public Form2()
        {
   
            InitializeComponent();
        }
        
       

        bool validationinputs()
        {
            bool isvalid = true;
            if (txtname.Text == "")
            {
                MessageBox.Show("لطفا نام خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtlastname.Text == "")
            {

                MessageBox.Show("لطفا نام خانوادگی خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtphone.Text == "")
            {

                MessageBox.Show("لطفا شماره موبایل خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtage.Value == 0)
            {

                MessageBox.Show("لطفا سن خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtemail.Text == "")
            {

                MessageBox.Show("لطفا ایمیل خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return isvalid;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {   
            if (validationinputs())
                    {
                
                
                bool issuccess = true;
                if (contactId == 0)
                {
                    MyContact contact = new MyContact();
                    contact.Name = txtname.Text;
                    contact.Lastname = txtlastname.Text;
                    contact.Phone = txtphone.Text;
                    contact.Email = txtemail.Text;
                    contact.Age = (int)txtage.Value;
                    db.MyContacts.Add(contact);
                }
                else
                {
                    var contact = db.MyContacts.Find(contactId);
                    contact.Name = txtname.Text;
                    contact.Lastname = txtlastname.Text;
                    contact.Email = txtemail.Text;
                    contact.Age = (int)txtage.Value;
                    contact.Phone = txtphone.Text;
               

                }
                db.SaveChanges();
                if (issuccess == true)
                {
                    MessageBox.Show("عمایات با موفقیت انجام شد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("عمایات باشکست  مواجه شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (contactId!=0)
            {
                bool issuccess = true;
                if (issuccess == true)
                {
                    MessageBox.Show("ویرایش با موفقیت انجام شد");
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص جدید";

            }
            else
            {
                this.Text = "ویرایش شخص";
                MyContact contact = db.MyContacts.Find(contactId);
                txtname.Text = contact.Name;
                txtlastname.Text = contact.Lastname;
                txtphone.Text = contact.Phone;
                txtage.Value = contact.Age;
                txtemail.Text = contact.Email;
                btnsubmit.Text = "ویرایش";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}



    
    
    

