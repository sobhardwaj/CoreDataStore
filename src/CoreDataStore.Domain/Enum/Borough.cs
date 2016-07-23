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

    public class BoroughId : System.Attribute
    {
        private string _value;
        public BoroughId(string value)
        {
            _value = value;
        }
        public string Value
        {
            get { return _value; }
        }
    }


}
