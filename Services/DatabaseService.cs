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
                            var customer = _custMapper.MapFromReaderCustomer(reader);
                            custList.Add(customer);
                        }
                    }
                }
            }

            return custList;
        }

        public async Task AddNewCustomer(List<string> customerData)
        {
            if (customerData == null || customerData.Count != 4)
                throw new ArgumentException("Invalid customer data");

            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "INSERT INTO Customer (LastName, FirstName, ContactPhone, Email) VALUES (@LastName, @FirstName, @ContactPhone, @Email)";

                using (var cmd = new MySqlCommand(commandString, conn))
                {
                    cmd.Parameters.AddWithValue("@LastName", customerData[0]);
                    cmd.Parameters.AddWithValue("@FirstName", customerData[1]);
                    cmd.Parameters.AddWithValue("@ContactPhone", customerData[2]);
                    cmd.Parameters.AddWithValue("@Email", customerData[3]);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task UpdateCustomer(Customer updatedCustomer)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "UPDATE Customer SET LastName = @Lastname, FirstName = @FirstName, ContactPhone = @ContactPhone, Email = @Email, Status = @Status WHERE CustomerID = @CustomerId";

                using (var cmd = new MySqlCommand(commandString, conn))
                {
                    cmd.Parameters.AddWithValue("@LastName", updatedCustomer.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", updatedCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@ContactPhone", updatedCustomer.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", updatedCustomer.EmailAddress);
                    cmd.Parameters.AddWithValue("@Status", updatedCustomer.Status);
                    cmd.Parameters.AddWithValue("@CustomerId", updatedCustomer.CustomerId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteCustomer(Customer customer)
        {
            
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "DELETE FROM Customer WHERE CustomerId = @CustomerId";

                using (var cmd = new MySqlCommand(commandString, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            
        }


        public async Task<List<RentalCategory>> GetCategories()
        {
            var categoryList = new List<RentalCategory>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (var cmd = new MySqlCommand("SELECT * FROM category_list", conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var category = _custMapper.MapFromReaderCategory(reader);
                            categoryList.Add(category);
                        }
                    }
                }
            }

            return categoryList;
        }

        public async Task<List<Rental>> GetRentals()
        {
            var rentalList = new List<Rental>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM rental_information", conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var rental = _custMapper.MapFromReaderRental(reader);
                            rentalList.Add(rental);
                        }
                    }
                }
            }

            return rentalList;
        }

        public async Task AddRental(List<object> rentalData)
        {
            if (rentalData == null || rentalData.Count != 4)
                throw new ArgumentException("Invalid rental data");

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "INSERT INTO rental_information (current_date, customer_id, equipment_id, rental_date, return_date) VALUES (@CurrentDate, @CustomerId, @EquipmentId, @RentalDate, @ReturnDate)";

                using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentDate", rentalData[0]);
                    cmd.Parameters.AddWithValue("@CustomerId", rentalData[1]);
                    cmd.Parameters.AddWithValue("@EquipmentId", rentalData[2]);
                    cmd.Parameters.AddWithValue("@RentalDate", rentalData[3]);
                    cmd.Parameters.AddWithValue("@ReturnDate", rentalData[4]);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task UpdateRental(Rental rental)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "UPDATE rental_information SET current_date = @CurrentDate, customer_id = @CustomerId, equipment_id = @EquipmentId, rental_date = @RentalDate, return_date = @ReturnDate WHERE rental_id = @RentalId";

                using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentDate", rental.CurrentDate);
                    cmd.Parameters.AddWithValue("@CustomerId", rental.CustomerId);
                    cmd.Parameters.AddWithValue("@EquipmentId", rental.EquipmentId);
                    cmd.Parameters.AddWithValue("@RentalDate", rental.RentalDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", rental.ReturnDate);
              
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}


