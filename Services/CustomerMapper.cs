using VillageRMS.Models;
using MySqlConnector;

namespace VillageRMS.Services
{
    public class CustomerMapper
    {
        public Customer MapFromReader(MySqlDataReader reader)
        {
            try
            {
                Customer customer = new Customer();

                //string _ph = reader.GetString("ContactPhone");
                //int phoneNumber = Int32.Parse(_ph);

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
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            
        }
    }

}
