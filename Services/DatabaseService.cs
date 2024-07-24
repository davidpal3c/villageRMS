using MySqlConnector;
using VillageRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;
        private readonly CustomerMapper _custMapper;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
            _custMapper = new CustomerMapper();
        }

        //for testing only
        public bool isSuccessfulConnection()
        {
            bool result = false;
            using (var conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }

            return result;
        }

        //get customer list
        public async Task<List<Customer>> GetCustomers()
        {
            var custList = new List<Customer>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (var cmd = new MySqlCommand("SELECT * FROM Customer", conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var customer = _custMapper.MapFromReader(reader);
                            custList.Add(customer);
                        }
                    }
                }
            }

            return custList;
        }
    }
}
