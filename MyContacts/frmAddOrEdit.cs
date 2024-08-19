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
    public partial class frmAddOrEdit : Form
    {
        IContactsRepository repository;
        public int contactId = 0;

        public frmAddOrEdit()
        {
            InitializeComponent();
            repository = new ContactsRepository();
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
                DataTable dt = repository.SelectRow(contactId);
                txtName.Text = dt.Rows[0][1].ToString();
                txtAge.Text = dt.Rows[0][2].ToString();
                txtEmail.Text = dt.Rows[0][3].ToString();
                txtMobile.Text = dt.Rows[0][4].ToString();
                txtAddress.Text = dt.Rows[0][5].ToString();
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
                bool isSuccess;
                if(contactId == 0)
                {
                isSuccess = repository.Insert(txtName.Text, txtMobile.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);
                }else
                {
                    isSuccess = repository.Update(contactId, txtName.Text, txtMobile.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);
                }

                if (isSuccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
