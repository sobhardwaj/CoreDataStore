using System.ComponentModel;

namespace CoreDataStore.Domain.Enum
{
    public enum Borough
    {
        [BoroughId("BK")]
        [Description("Brooklyn")]
        B,

        [BoroughId("BX")]
        [Description("Bronx")]
        X,

        [BoroughId("MN")]
        [Description("Manhattan")]
        M,

        [BoroughId("QN")]
        [Description("Queens")]
        Q,

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
