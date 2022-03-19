using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADOwpf
{
    public partial class AddRequest : Window
    {
        private AddRequest() { InitializeComponent(); }

        public AddRequest(DataBaseManager dbm) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                Request req = new Request
                {
                    email = txtEmail.Text,
                    codeProduct = txtCodeProduct.Text,
                    nameProduct = txtNameProduct.Text
                };

                dbm.AddRequest(req);
                this.DialogResult = !false;
            };

        }
    }
}
