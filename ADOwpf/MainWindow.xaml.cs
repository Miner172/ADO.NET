using System.Windows;

namespace ADOwpf
{
    public partial class MainWindow : Window
    {
        private DataBaseManager dbm;

        public MainWindow() { InitializeComponent(); dbm = new DataBaseManager(dataPerson, dataRequest); }

        private void BtnAddRequest(object sender, RoutedEventArgs e) { AddRequest add = new AddRequest(dbm); add.ShowDialog(); }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e) { AddClient add = new AddClient(dbm); add.ShowDialog(); }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e) => dbm.DeletePerson();

        private void BtnClearTable(object sender, RoutedEventArgs e) => dbm.Clear();
    }
}
