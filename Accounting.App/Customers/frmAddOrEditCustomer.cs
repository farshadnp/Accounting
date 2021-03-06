using Accounting.DataLayer.Context;
using System;
using System.IO;
using System.Windows.Forms;
using ValidationComponents;

namespace Accounting.App.Customers
{
    public partial class frmAddOrEditCustomer : Form
    {
        //UnitOfWork db = new UnitOfWork();
        public int CustomerId = 0;
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
            if (BaseValidator.IsFormValid(this.components))
            {
                
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                string path = Application.StartupPath + "/Images/";
                if (!Directory.Exists(path))
                {

                    Directory.CreateDirectory(path);
                }
                pcCustomer.Image.Save(path + imageName);


                Accounting.DataLayer.Customers customer = new DataLayer.Customers()
                {
                    FullName = txtName.Text,
                    Mobile = txtMobile.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    CustomerImage = imageName
                };

                using (UnitOfWork db = new UnitOfWork())
                {   if(CustomerId == 0)
                    {
                        db.CustomerRepository.insertCustomer(customer);
                    }
                    else
                    {
                        customer.CustumerID = CustomerId;
                        db.CustomerRepository.UpdateCustomer(customer);
                    }
                    
                    db.Save();
                }
                DialogResult = DialogResult.OK;
                
            }
        }

        private void frmAddOrEditCustomer_Load(object sender, EventArgs e)
        {
            
            if (CustomerId != 0)
            {
                this.Text = "ویرایش شخص";
                this.btnSave.Text = "ویرایش";

                using(UnitOfWork db = new UnitOfWork())
                {
                    var Customer = db.CustomerRepository.GetCustomersByID(CustomerId);
                    txtName.Text = Customer.FullName;
                    txtMobile.Text = Customer.Mobile;
                    txtEmail.Text = Customer.Email;
                    txtAddress.Text = Customer.Address;
                    pcCustomer.ImageLocation = Application.StartupPath + "/Images/" + Customer.CustomerImage;
                }
                
            }
        }
    }
}
