using MySqlConnector;
using VillageRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Maui.Controls;

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
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
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

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Customer", conn))
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

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "INSERT INTO Customer (LastName, FirstName, ContactPhone, Email) VALUES (@LastName, @FirstName, @ContactPhone, @Email)";

                using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
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
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "UPDATE Customer SET LastName = @Lastname, FirstName = @FirstName, ContactPhone = @ContactPhone, Email = @Email, Status = @Status WHERE CustomerID = @CustomerId";

                using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
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
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "DELETE FROM Customer WHERE CustomerId = @CustomerId";

                using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            
        }

        public async Task DeleteEquipment(RentalEquipment equipment)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string commandString = "DELETE FROM rental_equipment WHERE equipment_id = @EquipmentId";

                    using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
                    {
                        cmd.Parameters.AddWithValue("@EquipmentId", equipment.EquipmentId);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<List<RentalCategory>> GetCategories()
        {
            List < RentalCategory> categoryList = new List<RentalCategory>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM category_list", conn))
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

        public async Task<RentalCategory> GetCategoryByIdAsync(int categoryId)
        {
            RentalCategory category = null;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = "SELECT category_id, category_description FROM rental_category WHERE category_id = @categoryId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            category = new RentalCategory
                            {
                                CategoryId = reader.GetInt32("category_id"),
                                CategoryDescription = reader.GetString("category_description")
                            };
                        }
                    }
                }
            }

            return category;
        }


        public async Task<List<RentalEquipment>> GetRentalEquipmentAsync()
        {
            List<RentalEquipment> equipmentList = new List<RentalEquipment>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"SELECT re.equipment_id, re.name, re.description, re.daily_rental_cost, re.category, cl.category_description 
                                FROM rental_equipment re LEFT JOIN category_list cl ON re.category = cl.category_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var equipment = await _custMapper.MapFromReaderEquipmentAsync(reader);
                            equipmentList.Add(equipment);
                        }
                    }
                }
            }
            return equipmentList;
        }

        // get rental information
        public async Task<List<Rental>> GetRentalInformationAsync(DateOnly? filter = null)
        {
            List<Rental> rentals = new List<Rental>();

            string query = "SELECT * FROM `rental_information` ";
            if (filter.HasValue)
            {
                query += "WHERE `current_date` = @date";
            }

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (filter.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@date", filter.Value.ToString("yyyy-MM-dd"));
                        }

                        string finalQuery = BuildQueryString(cmd);
                        //Console.WriteLine(finalQuery);

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

        public async Task<List<Rental>> GetRentalInformationAsync(int? customerId)
        {
            List<Rental> rentals = new List<Rental>();

            string query = "SELECT * FROM `rental_information` ";
            if (customerId.HasValue)
            {
                query += "WHERE `customer_id` = @custid";
            }

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (customerId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@custid", customerId);
                        }

                        string finalQuery = BuildQueryString(cmd);
                        Console.WriteLine(finalQuery);

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

            }

            return rentals;
        }

            //for debuggin only
            private string BuildQueryString(MySqlCommand cmd)
        {
            string query = cmd.CommandText;
            foreach (MySqlParameter param in cmd.Parameters)
            {
                query = query.Replace(param.ParameterName, $"'{param.Value}'");
            }
            return query;
        }
                           
        public async Task AddNewEquipment(List<object> equipmentData)
        {
            if (equipmentData == null || equipmentData.Count != 4)
                throw new ArgumentException("Invalid equipment data");

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string commandString = "INSERT INTO rental_equipment (name, category, description, daily_rental_cost) VALUES (@Name, @CategoryId, @Description, @DailyCost)";

                using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", equipmentData[0]);
                    cmd.Parameters.AddWithValue("@CategoryId", equipmentData[1]);
                    cmd.Parameters.AddWithValue("@Description", equipmentData[2]);
                    cmd.Parameters.AddWithValue("@DailyCost", equipmentData[3]);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
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


        public async Task UpdateEquipment(RentalEquipment updateEquipment)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    string commandString = "UPDATE rental_equipment SET name = @Name, category = @CategoryId, description = @Description, daily_rental_cost = @DailyCost WHERE equipment_id = @EquipmentId";

                    using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", updateEquipment.Name);
                        cmd.Parameters.AddWithValue("@CategoryId", updateEquipment.CategoryId);
                        cmd.Parameters.AddWithValue("@Description", updateEquipment.Description);
                        cmd.Parameters.AddWithValue("@DailyCost", updateEquipment.Daily_rental_cost);
                        cmd.Parameters.AddWithValue("@EquipmentId", updateEquipment.EquipmentId);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
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
                    cmd.Parameters.AddWithValue("@CurrentDate", rental.RecordDate);
                    cmd.Parameters.AddWithValue("@CustomerId", rental.CustomerId);
                    cmd.Parameters.AddWithValue("@EquipmentId", rental.EquipmentId);
                    cmd.Parameters.AddWithValue("@RentalDate", rental.RentalDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", rental.ReturnDate);
                    cmd.Parameters.AddWithValue("@RentalId", rental.RentalId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
                        
        }

        public async Task<RentalCategory> LoadCategoryByIdAsync(int categoryId)
        {
            RentalCategory result = new RentalCategory();
            try
            {
                result = await GetCategoryByIdAsync(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while loading the category: {ex.Message}");
            }

            return result;
        }
    }

    
}


