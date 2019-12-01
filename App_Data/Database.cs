using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ProjetoFaculdade2.App_Data
{
    public class Database
    {
        private string _connectionString;
        private MySqlConnection _mySqlConnection;

        public Database()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mainConnectionString"].ConnectionString;
            _mySqlConnection = new MySqlConnection(_connectionString);
            try
            {
                _mySqlConnection.Open();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        
        public MySqlConnection GetConnection() => this._mySqlConnection;
        public static Database GetInstance() => new Database();
    }
}