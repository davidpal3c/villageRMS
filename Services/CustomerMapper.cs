using VillageRMS.Models;
using MySqlConnector;

namespace VillageRMS.Services
{
    public class CustomerMapper
    {
        public Customer MapFromReader(MySqlDataReader reader)
        {
            Customer customer = new Customer();

            return new Customer
            {
                CustomerId = reader.GetInt32("CustomerID"),
                LastName = reader.GetString("LastName"),
                FirstName = reader.GetString("FirstName"),
                PhoneNumber = reader.GetString("ContactPhone"),
                EmailAddress = reader.GetString("Email"),
                Status = reader.GetString("Status"),
            };
        }
    }

}
