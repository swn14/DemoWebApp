using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

public static class Extensions
{
    public static byte[] ToByteArray(this Object obj) => JsonSerializer.SerializeToUtf8Bytes(obj);

    public static T FromByteArray<T>(byte[] data, JsonSerializerOptions options = null)
    {
        var jsonUtfReader = new ReadOnlySpan<byte>(data);
        return JsonSerializer.Deserialize<T>(jsonUtfReader, options ?? JsonHelpers.JsonSerializerOptions);
    }

}

public static class JsonHelpers
{
    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
    };
}
