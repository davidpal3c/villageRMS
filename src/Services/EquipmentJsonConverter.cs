using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using VillageRMS.Models;

namespace VillageRMS.Services
{
    public class EquipmentJsonConverter : JsonConverter<RentalEquipment>
    {
        public override RentalEquipment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                // map it
                return new RentalEquipment
                {
                    EquipmentId = root.TryGetProperty("equipment_id", out var equipid) ? equipid.GetInt32() : 0,
                    CategoryId = root.TryGetProperty("category", out var catid) ? catid.GetInt32() : 0,
                    Name = root.TryGetProperty("name", out var n) ? n.GetString() : null,
                    Description = root.TryGetProperty("description", out var desc) ? desc.GetString() : null,
                    Daily_rental_cost = root.TryGetProperty("daily_rental_cost", out var rent) ? rent.GetDouble() : 0,
                };

            }
        }

        public override void Write(Utf8JsonWriter writer, RentalEquipment value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }

}

