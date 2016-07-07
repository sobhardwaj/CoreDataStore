using System.ComponentModel;

namespace CoreDataStore.Domain.Enum
{
    public enum Borough
    {
        [Description("Brooklyn")]
        B,

        [Description("Bronx")]
        X,

        [Description("Manhattan")]
        M,

        [Description("Queens")]
        Q,

        [Description("Staten Island")]
        R
    }
}
