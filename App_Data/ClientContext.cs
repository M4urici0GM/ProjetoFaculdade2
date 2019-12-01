using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using ProjetoFaculdade2.Entities;
using Slapper;

namespace ProjetoFaculdade2.App_Data
{
    public class ClientContext
    {

        private readonly MySqlConnection _mySqlConnection;

        public ClientContext()
        {
            _mySqlConnection = Database.GetInstance().GetConnection();
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            using (_mySqlConnection)
            {
                return await _mySqlConnection.QueryAsync<Client>(@"
                    SELECT * 
                    FROM Clientes
                    WHERE Status != false;");
            }
        }

        public async Task<Client> GetClient(long? id)
        {
            using (_mySqlConnection)
            {
                return await _mySqlConnection.QueryFirstOrDefaultAsync<Client>(@"
                    SELECT * 
                    FROM Clientes
                    WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<Client> CreateClient(Client client)
        {
            using (_mySqlConnection)
            {
                int insertedId = await _mySqlConnection.ExecuteScalarAsync<int>(@"
                INSERT INTO Clientes()
                VALUES
                    (null, @Name, @Document, true);
                    
                SELECT LAST_INSERT_ID();", client);
                return await GetClient(insertedId);
            }
        }

        public async Task<Client> UpdateClient(Client client)
        {
            using (_mySqlConnection)
            {
                await _mySqlConnection.ExecuteAsync(@"
                    UPDATE Clientes
                    SET Nome = @Name, Documento = @Documento", client);
                
                return await GetClient(client.Id);
            }
        }

        public async Task<Client> DeleteClient(long id)
        {
            using (_mySqlConnection)
            {
                await _mySqlConnection.ExecuteAsync(@"
                    UPDATE Clientes
                    SET Status = false
                    WHERE Id = @Id", new { Id = id });
                return await GetClient(id);
            }
        }
    }
}