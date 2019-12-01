using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Web.Configuration;
using Dapper;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using ProjetoFaculdade2.App_Data.Exceptions;
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

                User currentUser = await _mySqlConnection.QueryFirstOrDefaultAsync<User>(@"
                    SELECT *
                    FROM Usuarios
                    WHERE Login = @Login", new { Login = user.Login });
                
                if(currentUser != null)
                    throw new EntityAlreadyExists();
                
                await _mySqlConnection.ExecuteAsync(@"
                    INSERT INTO 
                        Usuarios()
                    VALUES 
                           (null, @Login, @Password, true);", new
                {
                    user.Login,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
                });
                return user;
            }
        }

        public async Task<User> DoLogin(User user)
        {
            using (_mySqlConnection)
            {
                User currentUser = await _mySqlConnection.QueryFirstOrDefaultAsync<User>(@"
                    SELECT *
                    FROM Usuarios
                    WHERE Login = @Login", user);
                if (currentUser == null)
                    throw new EntityNotFoundException();
                return BCrypt.Net.BCrypt.Verify(user.Password, currentUser.Password).IfNotNull((result) =>
                {
                    if (result)
                        return currentUser;
                    throw new InvalidCredentialException();
                });
            }
        }


        public async  void SeedUserData()
        {
            using (_mySqlConnection)
            {
                int rows = await _mySqlConnection.QueryFirstAsync<int>("SELECT COUNT(*) FROM Usuarios;");
                if (!rows.Equals(0))
                    return;
                await _mySqlConnection.ExecuteAsync(@"
                    INSERT INTO Usuarios() VALUES (0, 'admin@admin.com', @Password, true)
                ", new
                {
                    Password = BCrypt.Net.BCrypt.HashPassword("admin")
                });
            }
        }
    }
}