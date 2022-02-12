﻿using Accounting.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                DGCustomers.AutoGenerateColumns = false;
                DGCustomers.DataSource= db.CustomerRepository.GetAllCustomers();
            }

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using(UnitOfWork db = new UnitOfWork())
            {
                DGCustomers.DataSource= db.CustomerRepository.GetCustomersByFilter(txtFilter.Text);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
            txtFilter.Text = "";
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if(DGCustomers.CurrentRow != null)
            {
                using(UnitOfWork db = new UnitOfWork())
                {
                    string FullName = DGCustomers.CurrentRow.Cells[1].Value.ToString();
                    int customerId = (int)DGCustomers.CurrentRow.Cells[0].Value;
                    if(MessageBox.Show($"آیا از حذف {FullName} مطمئن هستید؟","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.CustomerRepository.DeleteCustomer(customerId);
                        db.Save();
                    }
                    
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک نفر را انتخاب کنید");
            }
        }
    }
}
