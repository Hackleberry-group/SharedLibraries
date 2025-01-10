using System.Text.Json;

namespace HackleberrySharedModels.Config.CustomExtensions;

public static class JsonElementExtension
{
    public static bool TryGetProperty(this JsonElement jsonElement, string propertyName, out JsonElement value, StringComparison comparison)
    {
        foreach (var property in jsonElement.EnumerateObject())
        {
            if (string.Equals(property.Name, propertyName, comparison))
            {
                value = property.Value;
                return true;
            }
        }

        value = default;
        return false;
    }
}