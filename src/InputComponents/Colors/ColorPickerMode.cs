using System;

namespace InputComponents.Colors
{
    /// <summary>
    /// Enumeration of supported <c>ColorPicker</c> modes.
    /// </summary>
    public enum ColorPickerMode
    {
        /// <summary>
        /// RGBA format with base 10 numbers.
        /// </summary>
        [FriendlyName("RGBA (dec)")] RgbaDec,
        /// <summary>
        /// RGBA format with base 16 numbers.
        /// </summary>
        [FriendlyName("RGBA (hex)")] RgbaHex
    }

    /// <summary>
    /// An attribute that adds a user-friendly string to an enum value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class FriendlyNameAttribute : Attribute
    {
        /// <summary>
        /// Add specified user-friendly name to enum value.
        /// </summary>
        /// <param name="name">User-friendly string to show in UI.</param>
        public FriendlyNameAttribute(string name) => Name = name;

        /// <summary>
        /// User-friendly name of enum value.
        /// </summary>
        public string Name { get; }
    }

    /// <summary>
    /// Helpers for <c>FriendlyNameAttribute</c>.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get user-friendly name of given enum value.
        /// </summary>
        /// <param name="value">Value of enum type with <c>FriendlyNameAttribute</c> on it.</param>
        /// <returns>User-friendly name.</returns>
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
