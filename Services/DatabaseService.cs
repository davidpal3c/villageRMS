using MySqlConnector;
using VillageRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace VillageRMS.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;
        private readonly CustomerMapper _custMapper;
        private readonly EquipmentMapper _equipmentMapper;
        private readonly RentalInformationMapper _rentalInformationMapper;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
            _custMapper = new CustomerMapper();
            _equipmentMapper = new EquipmentMapper();
            _rentalInformationMapper = new RentalInformationMapper();
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

        // get equipment
        public async Task<List<RentalEquipment>> GetEquipmentAsync()
        {
            List<RentalEquipment> equipmentList = new List<RentalEquipment>();

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (var cmd = new MySqlCommand("SELECT * FROM rental_equipment", conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var equipment = _equipmentMapper.MapFromReaderRentalEquipment(reader);
                                equipmentList.Add(equipment);
                            }
                        }
                    }
                }
            } catch (Exception e)
            {

            }


            return equipmentList;
        }

        // get rental information
        public async Task<List<Rental>> GetRentalInformationAsync(string filter = "")
        {
            List<Rental> rentals = new List<Rental>();

            string query = "SELECT * FROM rental_information ";
            if (!string.IsNullOrEmpty(filter))
            {
                query += "WHERE current_date = @date";
            }

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(filter))
                        {
                            cmd.Parameters.AddWithValue("@date", filter);
                        }

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var rentalinfo = _rentalInformationMapper.MapFromReaderRentalInformation(reader);
                                rentals.Add(rentalinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine($"Error: {e.Message}");
                //throw;
            }

            return rentals;
        }

    }
}


