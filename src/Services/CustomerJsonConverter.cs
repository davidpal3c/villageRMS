using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using VillageRMS.Models;

namespace VillageRMS.Services
{
    public class CustomerJsonConverter : JsonConverter<Customer>
    {
        public override Customer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                // map it
                return new Customer
                {
                    CustomerId = root.TryGetProperty("CustomerID", out var customerId) ? customerId.GetInt32() : 0,
                    LastName = root.TryGetProperty("LastName", out var lastName) ? lastName.GetString() : null,
                    FirstName = root.TryGetProperty("FirstName", out var firstName) ? firstName.GetString() : null,
                    PhoneNumber = root.TryGetProperty("ContactPhone", out var contactPhone) ? contactPhone.GetString() : null,  //  'contactPhone' <->'PhoneNumber'
                    EmailAddress = root.TryGetProperty("Email", out var email) ? email.GetString() : null,  //  'email' <-> 'EmailAddress'
                    Status = root.TryGetProperty("Status", out var status) ? status.GetString() : null,
                    Notes = root.TryGetProperty("Notes", out var notes) ? notes.GetString() : null
                };

            }
        }

        public override void Write(Utf8JsonWriter writer, Customer value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }

}

