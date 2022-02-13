using Accounting.DataLayer.Context;
using System;
using System.Windows.Forms;
using ValidationComponents;

namespace Accounting.App.Customers
{
    public partial class frmAddOrEditCustomer : Form
    {
        UnitOfWork db = new UnitOfWork();

        public frmAddOrEditCustomer()
        {
            InitializeComponent();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pcCustomer.ImageLocation = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Accounting.DataLayer.Customers customer = new DataLayer.Customers()
            {
                FullName = txtName.Text,
                Mobile = txtMobile.Text,
                Email=txtEmail.Text,
                Address = txtAddress.Text,
                CustomerImage = "NoPhoto.jpg"
            };

            if (BaseValidator.IsFormValid(this.components))
            {
                db.CustomerRepository.insertCustomer(customer);
                db.Save();
                DialogResult = DialogResult.OK;
                
            }
        }

        private void frmAddOrEditCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
