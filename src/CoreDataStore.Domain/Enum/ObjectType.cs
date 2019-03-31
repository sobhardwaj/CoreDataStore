using System.ComponentModel;

namespace CoreDataStore.Domain.Enum
{
    // Enumeration
    /// <summary>
    /// Enumeration ObjectType
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// Individual Landmark
        /// </summary>
        [Description("Individual Landmark")]
        L,

        /// <summary>
        /// Historic District
        /// </summary>
        [Description("Historic District")]
        H,

        /// <summary>
        /// Scenic Landmark
        /// </summary>
        [Description("Scenic Landmark")]
        S,

        /// <summary>
        /// Interior Landmark
        /// </summary>
        [Description("Interior Landmark")]
        I
    }
}
