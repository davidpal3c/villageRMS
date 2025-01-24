using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using VillageRMS.Models;

namespace VillageRMS.Services
{
    public class CategoryJsonConverter : JsonConverter<RentalCategory>
    {
        public override RentalCategory Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                // map it
                return new RentalCategory
                {
                    CategoryId = root.TryGetProperty("category_id", out var catid) ? catid.GetInt32() : 0,
                    CategoryDescription = root.TryGetProperty("category_description", out var desc) ? desc.GetString() : null
                };

            }
        }

        public override void Write(Utf8JsonWriter writer, RentalCategory value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }

}

