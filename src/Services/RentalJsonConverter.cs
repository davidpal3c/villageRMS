using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using VillageRMS.Models;

namespace VillageRMS.Services
{
    public class RentalJsonConverter : JsonConverter<Rental>
    {
        public override Rental Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                return new Rental
                {
                    RentalId = root.TryGetProperty("rental_id", out var rid) ? rid.GetInt32() : 0,
                    CurrentDate = root.TryGetProperty("currentdate", out var cdate) ? GetDateOnly(cdate).GetValueOrDefault() : default,
                    CustomerId = root.TryGetProperty("customer_id", out var cid) ? cid.GetInt32() : 0,
                    EquipmentId = root.TryGetProperty("equipment_id", out var eid) ? eid.GetInt32() : 0,
                    RentalDate = root.TryGetProperty("rental_date", out var reDate) ? GetDateOnly(reDate).GetValueOrDefault() : default,
                    ReturnDate = root.TryGetProperty("return_date", out var rnDate) ? GetDateOnly(rnDate).GetValueOrDefault() : default,
                    Cost = root.TryGetProperty("cost", out var cost) ? cost.GetDouble() : 0,
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, Rental value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }

        private DateOnly? GetDateOnly(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.String && DateTime.TryParse(element.GetString(), out DateTime parsedDate))
            {
                return DateOnly.FromDateTime(parsedDate);
            }
            return null;
        }
    }
}
