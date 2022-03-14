using System;
using System.Collections.Generic;
using System.Data;
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
        private DataTable dtPerson;
        private SqlDataAdapter daPerson;
        private SqlConnection conPerson;
        private DataRowView rowPerson;

        private DataTable dtRequest;
        private SqlDataAdapter daRequest;
        private SqlConnection conRequest;
        private DataRowView rowRequest;

        private SqlConnectionStringBuilder ConMSSQLLocalDB;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                ConMSSQLLocalDB = new SqlConnectionStringBuilder()
                {
                    DataSource = @"(localdb)\MSSQLLocalDB",
                    InitialCatalog = "LocalDB",
                    IntegratedSecurity = true,
                    Pooling = false,
                };

                InitPerson();
                InitRequest();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Current.Shutdown();
            }
        }

        private void InitRequest()
        {
            conRequest = new SqlConnection(ConMSSQLLocalDB.ConnectionString);
            daRequest = new SqlDataAdapter();
            dtRequest = new DataTable();

            var sql = @"SELECT * FROM Request Order By Request.id";
            daRequest.SelectCommand = new SqlCommand(sql, conRequest);

            sql = @"INSERT INTO Request (email,  codeProduct,  nameProduct) 
                                 VALUES (@email, @codeProduct, @nameProduct); 
                     SET @id = @@IDENTITY;";

            daRequest.InsertCommand = new SqlCommand(sql, conRequest);

            daRequest.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            daRequest.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");
            daRequest.InsertCommand.Parameters.Add("@codeProduct", SqlDbType.NVarChar, 50, "codeProduct");
            daRequest.InsertCommand.Parameters.Add("@nameProduct", SqlDbType.NVarChar, 50, "nameProduct");

            sql = @"UPDATE Request SET 
                           email = @email,
                           codeProduct = @codeProduct, 
                           nameProduct = @nameProduct,
                    WHERE id = @id";

            daRequest.UpdateCommand = new SqlCommand(sql, conRequest);
            daRequest.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;
            daRequest.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");
            daRequest.UpdateCommand.Parameters.Add("@codeProduct", SqlDbType.NVarChar, 50, "codeProduct");
            daRequest.UpdateCommand.Parameters.Add("@nameProduct", SqlDbType.NVarChar, 50, "nameProduct");

            sql = "DELETE FROM Request WHERE id = @id";

            daRequest.DeleteCommand = new SqlCommand(sql, conRequest);
            daRequest.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            daRequest.Fill(dtRequest);
            dataRequest.DataContext = dtRequest;
        }

        private void InitPerson()
        { 
            conPerson = new SqlConnection(ConMSSQLLocalDB.ConnectionString);
            daPerson = new SqlDataAdapter();
            dtPerson = new DataTable();

            var sql = @"SELECT * FROM Person Order By Person.id";
            daPerson.SelectCommand = new SqlCommand(sql, conPerson);

            sql = @"INSERT INTO Person (lastName,  firstName,  patronymic, phoneNumber, email) 
                                 VALUES (@lastName, @firstName, @patronymic, @phoneNumber, @email); 
                     SET @id = @@IDENTITY;";

            daPerson.InsertCommand = new SqlCommand(sql, conPerson);

            daPerson.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            daPerson.InsertCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 50, "lastName");
            daPerson.InsertCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 50, "firstName");
            daPerson.InsertCommand.Parameters.Add("@patronymic", SqlDbType.NVarChar, 50, "patronymic");
            daPerson.InsertCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 50, "phoneNumber");
            daPerson.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");

            sql = @"UPDATE Person SET 
                           lastName = @lastName,
                           firstName = @firstName, 
                           patronymic = @patronymic,
                           phoneNumber = @phoneNumber,
                           email = @email
                    WHERE id = @id";

            daPerson.UpdateCommand = new SqlCommand(sql, conPerson);
            daPerson.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;
            daPerson.UpdateCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 50, "lastName");
            daPerson.UpdateCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 50, "firstName");
            daPerson.UpdateCommand.Parameters.Add("@patronymic", SqlDbType.NVarChar, 50, "patronymic");
            daPerson.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 50, "phoneNumber");
            daPerson.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");

            sql = "DELETE FROM Person WHERE id = @id";

            daPerson.DeleteCommand = new SqlCommand(sql, conPerson);
            daPerson.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            daPerson.Fill(dtPerson);
            dataPerson.DataContext = dtPerson;
        }

        private void BtnAddRequest(object sender, RoutedEventArgs e)
        {
            DataRow r = dtRequest.NewRow();
            AddRequest add = new AddRequest(r);
            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                dtRequest.Rows.Add(r);
                daRequest.Update(dtRequest);
            }
        }

        private void BtnClearTable(object sender, RoutedEventArgs e)
        {
            foreach (var item in dataPerson.ItemsSource)
            {
                rowPerson = (DataRowView)item;
                rowPerson.Row.Delete();
                daPerson.Update(dtPerson);
            }

            foreach (var item in dataRequest.ItemsSource)
            {
                rowRequest = (DataRowView)item;
                rowRequest.Row.Delete();
                daRequest.Update(dtRequest);
            }
        }

        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (rowPerson == null) return;
            rowPerson.EndEdit();
            daPerson.Update(dtPerson);
        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            rowPerson = (DataRowView)dataPerson.SelectedItem;
            rowPerson.BeginEdit();
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rowPerson = (DataRowView)dataPerson.SelectedItem;
                rowPerson.Row.Delete();
                daPerson.Update(dtPerson);
            }
            catch (Exception)
            {
                MessageBox.Show("Тут нечего удалять");
            }
        }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRow r = dtPerson.NewRow();
            AddClient add = new AddClient(r);
            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                dtPerson.Rows.Add(r);
                daPerson.Update(dtPerson);
            }
        }
    }
}
