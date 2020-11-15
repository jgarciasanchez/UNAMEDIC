using Salud.Models;
using SQLite;
using System.Collections.Generic;

namespace Salud.DataBase
{
    public class DataBase
    {
        public string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public string database = "Salud";

        public bool instanceDB()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    var temp = System.IO.Path.Combine(folder, database);
                    connection.CreateTable<Item>();
                    connection.CreateTable<Pacientes>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool rebuildDB()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.DropTable<Item>();
                    connection.CreateTable<Item>();
                    connection.DropTable<Pacientes>();
                    connection.CreateTable<Pacientes>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        #region Tabla Ejemplo Item
        public bool saveItem(Item item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool deleteItem(Item item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Delete(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool updateItem(Item item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Update(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool savePacientes(Pacientes item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool updatePacientes(Pacientes item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Update(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public Item getPacienteByUsuarioClave(string usuario, string clave)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    return connection.Query<Item>("SELECT * FROM Pacientes Where usuario=? and clave = ?", usuario, clave)[0];
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public List<Item> getItems()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    return connection.Table<Item>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                //Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public Item getItemByID(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    return connection.Query<Item>("SELECT * FROM Item Where ID=?", Id)[0];
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        #endregion
    }
}
