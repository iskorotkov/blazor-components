using System;

namespace InputComponents.Colors
{
    public enum ColorPickerMode
    {
        [FriendlyName("RGBA (dec)")] RgbaDec,
        [FriendlyName("RGBA (hex)")] RgbaHex
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class FriendlyNameAttribute : Attribute
    {
        public FriendlyNameAttribute(string name) => Name = name;
        public string Name { get; }
    }

    public static class EnumExtensions
    {
        public static string FriendlyName(this Enum value)
        {
            var type = value.GetType();
            var field = type.GetField(value.ToString());
            var attrType = typeof(FriendlyNameAttribute);
            return Attribute.GetCustomAttribute(field!, attrType) switch
            {
                FriendlyNameAttribute attr => attr.Name,
                _ => throw new ArgumentException($"{value} must have {nameof(FriendlyNameAttribute)} on it.")
            };
        }
    }
}
