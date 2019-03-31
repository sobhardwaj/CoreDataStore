using System.ComponentModel;

namespace CoreDataStore.Domain.Enum
{
    // Enumeration
    /// <summary>
    /// Enumeration Borough
    /// </summary>
    public enum Borough
    {
        /// <summary>
        /// Brooklyn
        /// </summary>
        [BoroughId("BK")]
        [Description("Brooklyn")]
        B,

        /// <summary>
        /// Bronx
        /// </summary>
        [BoroughId("BX")]
        [Description("Bronx")]
        X,

        /// <summary>
        /// Manhattan
        /// </summary>
        [BoroughId("MN")]
        [Description("Manhattan")]
        M,

        /// <summary>
        /// Queens
        /// </summary>
        [BoroughId("QN")]
        [Description("Queens")]
        Q,

        /// <summary>
        /// Staten Island
        /// </summary>
        [BoroughId("SI")]
        [Description("Staten Island")]
        R
    }

    [System.AttributeUsage(System.AttributeTargets.All)]
    public class BoroughIdAttribute : System.Attribute
    {
        public BoroughIdAttribute(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }
}
