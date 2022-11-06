using MySql.Data.MySqlClient;
using System.Data;
using System.ServiceModel;

namespace WCF_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceLogin : IServiceLogin
    {
        public int Connect(string username, string password)
        {
            DataTable table = null;
            DB db = new DB();
            db.openConnection();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE (username=@username AND password=@password)", db.getConnection());
            command1.Parameters.AddWithValue("username", username);
            command1.Parameters.AddWithValue("password", password);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command1);

            table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count != 0)
                  return System.Convert.ToInt32(table.Rows[0][0].ToString());
              //  return 1;
            return 0;
        }

        public int Registration(string username, string password)
        {
            DataTable table = null;
            //     List<string> row = null;
            //todo sql
            DB db = new DB();
            db.openConnection();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE username=@username", db.getConnection());
            command1.Parameters.AddWithValue("username", username);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command1);

            table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count != 0)
                return 0;
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `username`," +
                "`password`) VALUES (NULL, @username, @password)", db.getConnection());
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            command.ExecuteNonQuery();
            table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count != 0)
                return System.Convert.ToInt32(table.Rows[0][0].ToString());
            return 0;
        }

    }
}
