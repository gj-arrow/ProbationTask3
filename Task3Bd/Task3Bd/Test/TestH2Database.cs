using NUnit.Framework;
using Task3Bd.Base;
using Task3Bd.H2;

namespace Task3Bd.Test
{
    [TestFixture]
    public class TestH2Database
    {
        private static readonly string FirtstSQl = RunConfigurator.GetValue("firtstSql");
        private static readonly string SecondSQl = RunConfigurator.GetValue("secondSql");
        private static readonly string ThirdSQl = RunConfigurator.GetValue("thirdSql");
        private static readonly string FourthSQl = RunConfigurator.GetValue("fourthSql");

        private static readonly object[] FilesSqlQuery =
        {
            new object[] { FirtstSQl },
            new object[] { SecondSQl },
            new object[] { ThirdSQl },
            new object[] { FourthSQl }
        };

        [Test]
        [TestCaseSource("FilesSqlQuery")]
        public void Test(string fileName)
        {
            ConnectionH2 connectionH2 = new ConnectionH2(Configuration.GetUrl(), Configuration.GetUsername(), Configuration.GetPassword());
            connectionH2.OpenConnection();
            ExecuteQuery execQuery = new ExecuteQuery();
            execQuery.CreateStatement(connectionH2);
            execQuery.ExecuteFromFile(fileName);
        }
    }
}