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
    /// Логика взаимодействия для AddRequest.xaml
    /// </summary>
    public partial class AddRequest : Window
    {
        private AddRequest() { InitializeComponent(); }

        public AddRequest(DataGrid dataGrid, ModelDBContainer db) : this()
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

                db.RequestSet.Add(req);
                db.SaveChanges();
                dataGrid.ItemsSource = db.RequestSet.Local.ToBindingList<Request>();
                dataGrid.Items.Refresh();
                this.DialogResult = !false;
            };

        }
    }
}
