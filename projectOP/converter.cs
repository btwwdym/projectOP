using System.Text.Json;
using System.Text.Json.Serialization;

namespace app
{
    public class InterfaceConverter : JsonConverter<IContract>
    {
        public override IContract Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                if (root.TryGetProperty("ContractType", out var contractTypeProperty))
                {
                    string contractType = contractTypeProperty.GetString();
                    return contractType switch
                    {
                        "Shipping" => JsonSerializer.Deserialize<ShippingContract>(root.GetRawText(), options),
                        "Warehouse Lease" => JsonSerializer.Deserialize<WarehouseLeaseContract>(root.GetRawText(), options),
                        "Route Planning" => JsonSerializer.Deserialize<RoutePlanningContract>(root.GetRawText(), options),
                        _ => throw new JsonException($"Unknown contract type: {contractType}")
                    };
                }
                throw new JsonException("ContractType property not found");
            }
        }

        public override void Write(Utf8JsonWriter writer, IContract value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
