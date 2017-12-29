using log4net;

namespace Task3Bd.Base
{
    public class Logger
    {
        private ILog logger;

        public Logger(ILog logger)
        {
            this.logger = logger;
        }

        public void Step(string result)
        {
            logger.Info(result);
        }
        public void Info(string info)
        {
            logger.Info(info);
        }

        public void Fatal(string fatal)
        {
            logger.Fatal(fatal);
        }
    }
}
