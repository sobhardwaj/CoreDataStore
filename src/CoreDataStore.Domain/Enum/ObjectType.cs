using System.ComponentModel;

namespace CoreDataStore.Domain.Enum
{
    public enum ObjectType
    {
        [Description("Individual Landmark")]
        L,

        [Description("Historic District")]
        H,

        [Description("Scenic Landmark")]
        S,

        [Description("Interior Landmark")]
        I
    }
}
