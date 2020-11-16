using Salud.Models;
using SQLite;
using System.Collections.Generic;

namespace Salud.DataBases
{
    public class DataBase
    {
        #region Definición DB
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
                    connection.CreateTable<Diabetes>();
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
                    connection.DropTable<Diabetes>();
                    connection.CreateTable<Diabetes>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        #endregion

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

        #region Tabla Diabetes
        public bool saveDiabetes(Diabetes diabetes)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Insert(diabetes);
                     return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool deleteDiabetes(Diabetes diabetes)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Delete(diabetes);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool updateDiabetes(Diabetes diabetes)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    connection.Update(diabetes);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public List<Diabetes> getDiabetes()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    return connection.Table<Diabetes>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                //Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public Diabetes getDiabetesByID(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, database)))
                {
                    return connection.Query<Diabetes>("SELECT * FROM Diabetes Where ID=?", Id)[0];
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
