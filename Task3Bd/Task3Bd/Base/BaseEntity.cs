using log4net;
using log4net.Config;

namespace Task3Bd.Base
{
    public class BaseEntity
    {
        public static Logger Log;
        protected BaseEntity()
        {
            XmlConfigurator.Configure();
            Log = new Logger(LogManager.GetLogger(typeof(BaseEntity)));
        }
    }
}
