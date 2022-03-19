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
    public partial class AddClient : Window
    {
        private AddClient() { InitializeComponent(); }

        public AddClient(DataBaseManager dbm) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                Person client = new Person
                {
                    lastName = txtLastName.Text,
                    firstName = txtFirstName.Text,
                    patronymic = txtPatronomic.Text,
                    phoneNumber = txtTelephone.Text,
                    email = txtEmail.Text
                };

                dbm.AddPerson(client);
                this.DialogResult = !false;
            };
        }
    }
}
