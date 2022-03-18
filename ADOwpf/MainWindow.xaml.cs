using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADOwpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModelDBContainer db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ModelDBContainer();

            db.PersonSet.Load();
            db.RequestSet.Load();
            dataPerson.ItemsSource = db.PersonSet.Local.ToBindingList<Person>();
            dataRequest.ItemsSource = db.RequestSet.Local.ToBindingList<Request>();
        }

        private void BtnAddRequest(object sender, RoutedEventArgs e)
        {
            AddRequest add = new AddRequest(dataRequest, db);
            add.ShowDialog();
        }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClient add = new AddClient(dataPerson, db);
            add.ShowDialog();
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.PersonSet.Remove((Person)dataPerson.SelectedItem);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Тут нечего удалять!");
            }
        }

        private void BtnClearTable(object sender, RoutedEventArgs e)
        {
            List<Person> p = new List<Person>();
            foreach (var item in dataPerson.ItemsSource) { p.Add((Person)item); }
            foreach (var item in p) { db.PersonSet.Remove(item); }
            db.SaveChanges();
            dataPerson.ItemsSource = db.PersonSet.Local.ToBindingList<Person>();
            dataPerson.Items.Refresh();

            List<Request> r = new List<Request>();
            foreach (var item in dataRequest.ItemsSource) { r.Add((Request)item); }
            foreach (var item in r) { db.RequestSet.Remove(item); }
            db.SaveChanges();
            dataRequest.ItemsSource = db.RequestSet.Local.ToBindingList<Request>();
            dataRequest.Items.Refresh();
        }
    }
}
