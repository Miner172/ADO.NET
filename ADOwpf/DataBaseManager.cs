using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Controls;
using System.Windows;

namespace ADOwpf
{
    public class DataBaseManager
    {
        private ModelDBContainer db;

        private DataGrid person;
        private DataGrid request;

        public DataBaseManager(DataGrid person, DataGrid request)
        {
            db = new ModelDBContainer();
            this.person = person;
            this.request = request;
            Load();
        }

        public void DeletePerson()
        {
            try
            {
                db.PersonSet.Remove((Person)person.SelectedItem);
                Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Тут нечего удалять!");
            }
        }

        public void AddRequest(Request r)
        {
            db.RequestSet.Add(r);
            Save();
            ReloadDataGrids();
        }

        public void AddPerson(Person p)
        {
            db.PersonSet.Add(p);
            Save();
            ReloadDataGrids();
        }

        private void ReloadDataGrids()
        {
            request.ItemsSource = db.RequestSet.Local.ToBindingList<Request>();
            request.Items.Refresh();

            person.ItemsSource = db.PersonSet.Local.ToBindingList<Person>();
            person.Items.Refresh();
        }

        public void Load()
        {
            db.PersonSet.Load();
            db.RequestSet.Load();
            person.ItemsSource = db.PersonSet.Local.ToBindingList<Person>();
            request.ItemsSource = db.RequestSet.Local.ToBindingList<Request>();
        }

        public void Save() => db.SaveChanges(); 

        public void Clear()
        {
            List<Person> p = new List<Person>();
            List<Request> r = new List<Request>();

            foreach (var item in person.ItemsSource) { p.Add((Person)item); }
            foreach (var item in p) { db.PersonSet.Remove(item); }

            foreach (var item in request.ItemsSource) { r.Add((Request)item); }
            foreach (var item in r) { db.RequestSet.Remove(item); }

            ReloadDataGrids();
            Save();
        }
    }
}
