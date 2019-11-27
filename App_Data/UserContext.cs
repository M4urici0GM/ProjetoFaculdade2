using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using ProjetoFaculdade2.Entities;

namespace ProjetoFaculdade2.App_Data
{
    public class UserContext
    {
        private readonly MySqlConnection _mySqlConnection;

        public UserContext()
        {
            _mySqlConnection = Database.GetInstance().GetConnection();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using (_mySqlConnection)
            {
                return await _mySqlConnection.QueryAsync<User>(@"
                        SELECT * FROM Usuarios
                        WHERE
                            Status != false
                            AND Id != 0;");
            }
        }

        public async Task<User> GetUser(long id)
        {
            using (_mySqlConnection)
            {
                return await _mySqlConnection.QueryFirstOrDefaultAsync<User>(@"
                    SELECT * FROM Usuarios
                    WHERE
                        Id = @Id;", new { Id = id});
            }
        }

        public async Task<User> CreateUser(User user)
        {
            using (_mySqlConnection)
            {
                await _mySqlConnection.ExecuteAsync(@"
                    INSERT INTO 
                        Usuarios()
                    VALUES 
                           (null, @Login, @Password, true);", new
                {
                    Login = user.Login,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
                });
                return user;
            }
        }
        
    }
}