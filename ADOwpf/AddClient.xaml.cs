using System;
using System.Collections.Generic;
using System.Data;
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

        public AddClient(DataRow row) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                row["lastName"] = txtLastName.Text;
                row["firstName"] = txtFirstName.Text;
                row["patronymic"] = txtPatronomic.Text;
                row["phoneNumber"] = txtTelephone.Text;
                row["email"] = txtEmail.Text;
                this.DialogResult = !false;
            };

        }
    }
}
