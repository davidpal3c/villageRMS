using VillageRMS.Models;
using MySqlConnector;
using System.Data;


namespace VillageRMS.Services
{
    public class CustomerMapper
    {
        public Customer MapFromReaderCustomer(MySqlDataReader reader)
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

        public RentalCategory MapFromReaderCategory(MySqlDataReader reader)
        {
            try
            {
                RentalCategory category = new RentalCategory();                               

                return new RentalCategory
                {
                    CategoryId = reader.GetInt32("category_id"),
                    CategoryDescription = reader.GetString("category_description")
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Rental MapFromReaderRental(MySqlDataReader reader)
        {
            try
            {
                Rental rental = new Rental();

                return new Rental
                {
                    RentalId = reader.GetInt32("rental_id"),
                    CustomerId = reader.GetInt32("customer_id"),
                    EquipmentId = reader.GetInt32("equipment_id"),
                    RecordDate = reader.GetDateOnly("current_date"),
                    RentalDate = reader.GetDateOnly("rental_date"),
                    ReturnDate = reader.GetDateOnly("return_date"),
                    Cost = reader.GetDouble("cost")
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<RentalEquipment> MapFromReaderEquipmentAsync(MySqlDataReader reader)
        {
            try
            {
                RentalEquipment equipment = new RentalEquipment
                {
                    EquipmentId = reader.GetInt32("equipment_id"),                    
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Daily_rental_cost = reader.GetDouble("daily_rental_cost"),
                    CategoryId = reader.GetInt32("category")

                };

                //int categoryId = reader.GetInt32("category");
                //string categoryDescription = reader.IsDBNull("category_description") ? "" : reader.GetString("category_description");

                /*equipment._category = new RentalCategory
                {
                    CategoryId = categoryId,
                    CategoryDescription = categoryDescription
                };*/

                return equipment;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
