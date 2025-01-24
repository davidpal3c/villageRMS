using MySqlConnector;
using VillageRMS.Models;
using System.Text.Json;
using System.Net.Http.Json;
using VillageRMS.Settings;
using System.Text;

namespace VillageRMS.Services
{
    public class DatabaseService
    {

        public DatabaseService() { }

        public async Task<bool> isSuccessfulConnection()
        {
            bool result = false;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // api test endpoint
                    //string apiUrl = "http://localhost:3000/test";
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/test";
                    Console.WriteLine($"running test on api end point {apiUrl}");

                    //get
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    // success check
                    result = response.IsSuccessStatusCode;
                }
                catch (Exception ex) // errors
                {
                    Console.WriteLine($"error connecting to API: {ex.Message}");
                    result = false;
                }
            }

            return result;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var custList = new List<Customer>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.customers}";

                    // get
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // json response
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        // omg why did we not create objects with matching db fields
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new CustomerJsonConverter() } // pulling your brain out to map objects
                        };

                        // deserialize with mapping
                        custList = JsonSerializer.Deserialize<List<Customer>>(jsonResponse, options);

                    }
                    else
                    {
                        // handle erros
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // handle more errors
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }

            if (custList != null)
            {
                return custList;
            }
            else
            {
                return new List<Customer>(); //null
            }


        }

        public async Task AddNewCustomer(List<string> customerData)
        {
            if (customerData == null || customerData.Count != 6)
                throw new ArgumentException("Invalid customer data");

            var customer = new
            {
                CustomerID = customerData[0],
                LastName = customerData[1],
                FirstName = customerData[2],
                ContactPhone = customerData[3],
                Email = customerData[4],
                Notes = customerData[5]
            };

            using (var httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.customers}";
                    var response = await httpClient.PostAsJsonAsync(apiUrl, customer);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task UpdateCustomer(Customer updatedCustomer)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.customers}";
                    apiUrl = $"{apiUrl}/{updatedCustomer.CustomerId}";
                    var response = await httpClient.PutAsJsonAsync(apiUrl, updatedCustomer);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task DeleteCustomer(Customer customer)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.customers}";
                    apiUrl = $"{apiUrl}/{customer.CustomerId}";
                    var response = await httpClient.DeleteAsync(apiUrl);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task<List<RentalCategory>> GetCategories()
        {
            var categoryList = new List<RentalCategory>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // end point
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.categories}";

                    // get
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // json
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new CategoryJsonConverter() } //map
                        };

                        // Deserialize
                        categoryList = JsonSerializer.Deserialize<List<RentalCategory>>(jsonResponse, options);
                    }
                    else
                    {
                        // errors
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    //  more errors
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }

            return categoryList ?? new List<RentalCategory>(); 
        }

        public async Task AddCategory(List<object> catData)
        {
            if (catData == null || catData.Count < 2)
                throw new ArgumentException("Invalid category data");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.categories}";

                    // data
                    var category = new
                    {
                        CategoryId = catData[0],
                        CategoryDescription = catData[1]
                    };

                    // post
                    var response = await httpClient.PostAsJsonAsync(apiUrl, category);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // error
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task UpdateCategory(RentalCategory category)
        {
            if (category == null)
                throw new ArgumentException("Invalid category");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.categories}/{category.CategoryId}";

                    // put
                    var response = await httpClient.PutAsJsonAsync(apiUrl, category);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // error
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task DeleteCategory(RentalCategory category)
        {
            if (category == null)
                throw new ArgumentException("Invalid category");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.categories}/{category.CategoryId}";

                    // del
                    var response = await httpClient.DeleteAsync(apiUrl);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // error
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task<List<RentalEquipment>> GetRentalEquipmentAsync()
        {
            var equipmentList = new List<RentalEquipment>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.equipment}";

                    // get
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {

                        //var jsonResponse = await response.Content.ReadAsStringAsync();

                        // deserialize
                        //equipmentList = JsonSerializer.Deserialize<List<RentalEquipment>>(jsonResponse, new JsonSerializerOptions
                        //{
                        //    PropertyNameCaseInsensitive = true
                        //});

                        // response
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new EquipmentJsonConverter() } //map
                        };

                        // deserialize
                        equipmentList = JsonSerializer.Deserialize<List<RentalEquipment>>(jsonResponse, options);

                    }
                    else
                    {
                        // error responses
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // more errors
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }

            return equipmentList ?? new List<RentalEquipment>(); 
        }

        public async Task AddNewEquipment(List<object> equipmentData)
        {
            if (equipmentData == null || !(equipmentData.Count == 5 || equipmentData.Count == 4))
                throw new ArgumentException("Invalid equipment data");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.equipment}";

                    // payload
                    var equip = new
                    {
                        EquipmentId = equipmentData.Count == 5 ? equipmentData[0] : null, // Set null for auto-increment
                        CategoryId = equipmentData.Count == 5 ? equipmentData[1] : equipmentData[0],
                        Name = equipmentData.Count == 5 ? equipmentData[2] : equipmentData[1],
                        Description = equipmentData.Count == 5 ? equipmentData[3] : equipmentData[2],
                        DailyCost = equipmentData.Count == 5 ? equipmentData[4] : equipmentData[3]
                    };

                    // post
                    var response = await httpClient.PostAsJsonAsync(apiUrl, equip);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // errors
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task UpdateEquipment(RentalEquipment updateEquipment)
        {
            if (updateEquipment == null)
                throw new ArgumentNullException(nameof(updateEquipment), "Equipment data cannot be null");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.equipment}/{updateEquipment.EquipmentId}";

                    // equipment update
                    var equipment = new
                    {
                        Name = updateEquipment.Name,
                        CategoryId = updateEquipment.CategoryId,
                        Description = updateEquipment.Description,
                        DailyCost = updateEquipment.Daily_rental_cost
                    };

                    // put
                    var response = await httpClient.PutAsJsonAsync(apiUrl, equipment);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // errors
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task DeleteEquipment(RentalEquipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment), "Equipment data cannot be null");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.equipment}/{equipment.EquipmentId}";

                    //delete
                    var response = await httpClient.DeleteAsync(apiUrl);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // error
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        // get equipment by id
        public async Task<List<RentalEquipment>> GetEquipmentAsync(int? catId)
        {
            var equipmentList = new List<RentalEquipment>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // hand endpoint with or without param
                    string apiUrl = catId.HasValue
                        ? $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.equipment}?categoryId={catId}"
                        : $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.equipment}";

                    // get
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // json
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new EquipmentJsonConverter() } //map
                        };

                        equipmentList = JsonSerializer.Deserialize<List<RentalEquipment>>(jsonResponse, options);


                    }
                    else
                    {
                        // error
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // more error
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }

            return equipmentList ?? new List<RentalEquipment>();
        }

        //list rentals
        public async Task<List<Rental>> GetRentals()
        {
            var rentalList = new List<Rental>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // end point
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.rental}";

                    // get
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // json
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new RentalJsonConverter() } //map
                        };

                        rentalList = JsonSerializer.Deserialize<List<Rental>>(jsonResponse, options);
                    }
                    else
                    {
                        // error
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // more erros
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }

            return rentalList ?? new List<Rental>();
        }

        //rental with date param
        public async Task<List<Rental>> GetRentalInformationAsync(DateOnly? filter = null)
        {
            var rentals = new List<Rental>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.rental}";

                    // param
                    if (filter.HasValue)
                    {
                        apiUrl += $"?rental_date={filter.Value.ToString("yyyy-MM-dd")}";
                    }

                    // get
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    { 
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new RentalJsonConverter() } 
                        };

                        // deserialize
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        rentals = JsonSerializer.Deserialize<List<Rental>>(jsonResponse, options);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }

            return rentals;
        }

        //rental with int param overload
        public async Task<List<Rental>> GetRentalInformationAsync(int? customerId)
        {
            var rentals = new List<Rental>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.rental}";

                    // param
                    if (customerId.HasValue)
                    {
                        apiUrl += $"?customer_id={customerId}";
                    }

                    // get
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // json
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new RentalJsonConverter() } 
                        };

                        // deserialize
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        rentals = JsonSerializer.Deserialize<List<Rental>>(jsonResponse, options);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }

            return rentals;
        }

        /*
        public async Task AddRental(List<object> rentalData)
        {
            if (rentalData == null || !(rentalData.Count == 7 || rentalData.Count == 6))
                throw new ArgumentException("Invalid rental data");
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string additionalColumn = String.Empty;
                    string additionalParam = String.Empty;

                    if (rentalData.Count == 6) //no id and use auto increment
                    {
                        additionalColumn = "";
                        additionalParam = "";
                    } else
                    {
                        additionalColumn = "rental_id,";
                        additionalParam = "@rentalid,";
                    }


                    string commandString = $"INSERT INTO rental_info ({additionalColumn} currentdate, customer_id, equipment_id, rental_date, return_date, cost) VALUES ({additionalParam} @CurrentDate, @CustomerId, @EquipmentId, @RentalDate, @ReturnDate, @Cost);";

                    using (MySqlCommand cmd = new MySqlCommand(commandString, conn))
                    {
                        int moveIndex = 0;

                        if (rentalData.Count == 7)
                        {
                            moveIndex = 1;
                            cmd.Parameters.AddWithValue("@rentalid", rentalData[0]);
                        } 
                      
                        cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Parse(rentalData[0 + moveIndex].ToString()).ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@CustomerId", rentalData[1 + moveIndex]);
                        cmd.Parameters.AddWithValue("@EquipmentId", rentalData[2 + moveIndex]);
                        cmd.Parameters.AddWithValue("@RentalDate", DateTime.Parse(rentalData[3 + moveIndex].ToString()).ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Parse(rentalData[4 + moveIndex].ToString()).ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Cost", rentalData[5 + moveIndex]);
                        

                        string cmdString = BuildQueryString(cmd);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex) { }
            
        }*/

        public async Task AddRental(List<object> rentalData)
        {
            if (rentalData == null || !(rentalData.Count == 7 || rentalData.Count == 6))
                throw new ArgumentException("Invalid rental data");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.rental}";

                    // rental
                    var rentalPayload = new
                    {
                        RentalId = rentalData.Count == 7 ? rentalData[0] : null,
                        CurrentDate = DateTime.Parse(rentalData[rentalData.Count == 7 ? 1 : 0].ToString()).ToString("yyyy-MM-dd"),
                        CustomerId = rentalData[rentalData.Count == 7 ? 2 : 1],
                        EquipmentId = rentalData[rentalData.Count == 7 ? 3 : 2],
                        RentalDate = DateTime.Parse(rentalData[rentalData.Count == 7 ? 4 : 3].ToString()).ToString("yyyy-MM-dd"),
                        ReturnDate = DateTime.Parse(rentalData[rentalData.Count == 7 ? 5 : 4].ToString()).ToString("yyyy-MM-dd"),
                        Cost = rentalData[rentalData.Count == 7 ? 6 : 5]
                    };

                    // json
                    var jsonPayload = JsonSerializer.Serialize(rentalPayload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // post
                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }


        public async Task UpdateRental(Rental rental)
        {
            if (rental == null)
                throw new ArgumentNullException(nameof(rental), "Rental cannot be null");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.rental}/{rental.RentalId}";

                    // payload
                    var rentalPayload = new
                    {
                        CurrentDate = rental.CurrentDate.ToString("yyyy-MM-dd"),
                        CustomerId = rental.CustomerId,
                        EquipmentId = rental.EquipmentId,
                        RentalDate = rental.RentalDate.ToString("yyyy-MM-dd"),
                        ReturnDate = rental.ReturnDate.ToString("yyyy-MM-dd"),
                        Cost = rental.Cost
                    };

                    // json
                    var jsonPayload = JsonSerializer.Serialize(rentalPayload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // put
                    var response = await httpClient.PutAsync(apiUrl, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task DeleteRental(Rental rental)
        {
            if (rental == null)
                throw new ArgumentNullException(nameof(rental), "Rental cannot be null");

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.rental}/{rental.RentalId}";

                    // delete
                    var response = await httpClient.DeleteAsync(apiUrl);

                    // success
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                }
            }
        }

        public async Task<int> GetNextIdAsync(string table, string idcol)
        {
            int result = 0;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // api endpoint
                    string apiUrl = $"{SystemSettings.ApiURL}:{SystemSettings.ApiURLPort}/{SystemSettings.nextID}";
                    apiUrl = $"{apiUrl}?table={table}&idcol={idcol}";

                    //send get
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var data = JsonSerializer.Deserialize<JsonElement>(jsonResponse);

                        result = data.GetProperty("nextId").GetInt32();
                    }
                    else
                    {
                        throw new Exception("Failed to fetch next ID from API.");
                    }
                }
            }
            catch (Exception ex)
            {
                // error
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result; // next id of table
        }


    }

}


