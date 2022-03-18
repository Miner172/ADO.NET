using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ADOwpf
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private AddClient() { InitializeComponent(); }

        public AddClient(DataGrid dataGrid, ModelDBContainer db) : this()
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

                db.PersonSet.Add(client);
                db.SaveChanges();
                dataGrid.ItemsSource = db.PersonSet.Local.ToBindingList<Person>();
                dataGrid.Items.Refresh();
                this.DialogResult = !false;
            };
        }
    }
}
