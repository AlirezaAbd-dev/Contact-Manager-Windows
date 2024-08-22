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
    public partial class frmAddOrEdit : Form
    {
        ContactsEntities db = new ContactsEntities();

        IContactsRepository repository;
        public int contactId = 0;

        public frmAddOrEdit()
        {
            InitializeComponent();
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                MyContact contact = db.MyContacts.Find(contactId);
                txtName.Text = contact.name;
                txtAge.Text = contact.age.ToString();
                txtEmail.Text = contact.email;
                txtMobile.Text = contact.mobile;
                txtAddress.Text = contact.address;
                btnSubmit.Text = "ویرایش";
            }
        }

        bool ValidateInputs()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا موبایل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (contactId == 0)
                {
                MyContact contact = new MyContact();
                    contact.name = txtName.Text;
                    contact.address = txtAddress.Text;
                    contact.mobile = txtMobile.Text;
                    contact.age = (int)txtAge.Value;
                    contact.email = txtEmail.Text;
                    db.MyContacts.Add(contact);
                }
                else
                {
                    var contact = db.MyContacts.Find(contactId);
                    contact.name = txtName.Text;    
                    contact.address = txtAddress.Text;
                    contact.email= txtEmail.Text;
                    contact.age= (int)txtAge.Value;
                    contact.mobile= txtMobile.Text;
                }
                db.SaveChanges();

                MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
