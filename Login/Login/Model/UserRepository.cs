using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace Login.Model
{

    public class UserRepository
    {

        private SQLiteConnection con;
        private static UserRepository instancia;
        public static UserRepository Instancia
        {

            get
            {

                if (instancia == null)
                    throw new Exception("debe llamar al inicializador");


                return instancia;
            }
        }

        public static void Inicializador(string filename)
        {

            if (filename == null)
                throw new ArgumentNullException();

            if (instancia != null)
                instancia.con.Close();
            instancia = new UserRepository(filename);

        }
        private UserRepository(string dbPath)
        {

            con = new SQLiteConnection(dbPath);

            con.CreateTable<User>();

        }

        public string EstadoMensaje;
        public int AddNewUser(string username, string email, string password)

        {
            int result = 0;

            try
            {

                result = con.Insert(new User()
                {
                    Username = username,
                    Email = email,
                    Password = password
                });


                EstadoMensaje = string.Format("Usuario agregado correctamente");

            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;

            }

            return result;

        }

        public IEnumerable<User> GetAllUsers()
        {
            {

                try
                {


                    return con.Table<User>();

                }
                catch (Exception e)
                {

                    EstadoMensaje = e.Message;
                }


            }

            return Enumerable.Empty<User>();
        }
    }
}
