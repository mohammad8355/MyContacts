using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
    InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {  BindGrid();
        }
        private void BindGrid()
        {
            using (Contact_DBEntities db = new Contact_DBEntities())
            {
                dgContact.AutoGenerateColumns = false;
                dgContact.DataSource = db.MyContacts.ToList();
            }
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgContact.CurrentRow !=null)
            {
                string name = dgContact.CurrentRow.Cells[1].Value.ToString();
                string lastname = dgContact.CurrentRow.Cells[2].Value.ToString();
                string fullname = name + " " + lastname;
                if(MessageBox.Show($"مطمِین هستید؟{fullname}آیا از حذف ","توجه",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    int contactId = int.Parse(dgContact.CurrentRow.Cells[0].Value.ToString());
                   using(Contact_DBEntities db = new Contact_DBEntities())
                    {
                       MyContact contact =  db.MyContacts.Single(p=>p.ContactId==contactId);
                        db.MyContacts.Remove(contact);
                    }
                    BindGrid();
                }
                
            }
        
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if(dgContact.CurrentRow != null)
            {
              
                int ContactId = int.Parse(dgContact.CurrentRow.Cells[0].Value.ToString());
          
                Form2 form = new Form2();
                form.contactId = ContactId;
               
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void dgContact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
