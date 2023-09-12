using System.Text.Json;
using System.Text.Json.Serialization;
using VendorDeck.Domain.Enums;

public class OrderStatusConverter : JsonConverter<OrderStatus>
{
    public override OrderStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {

        if (reader.TokenType == JsonTokenType.Number && Enum.TryParse<OrderStatus>(reader.GetInt32().ToString(), out var status))
            return status;

        if (reader.TokenType == JsonTokenType.String && Enum.TryParse<OrderStatus>(reader.GetString(), out var orderStatus))
            return orderStatus;
    
        throw new JsonException($"Unable to parse OrderStatus from JSON: {reader.GetString()}");
    }

    public override void Write(Utf8JsonWriter writer, OrderStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}