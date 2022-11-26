using OrderManager.Oms;
using TransactionExporter.Interface;
using TransactionExporter.Oms.Exceptions;

namespace TransactionExporter.Oms
{
    public class OmsTypeFactory
    {
        public static Ioms GetOmsType(string type)
        {
            switch (type.ToUpper())
            {
                case "AAA":
                    return new AAAOms();
                case "BBB":
                    return new BBBOms();
                case "CCC":
                    return new CCCOms();
                default:
                    throw new MissingOmsTypeException($" Missing OMS Type { type } ");
            }
        }
    }
}
