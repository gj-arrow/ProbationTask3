using System;
using java.lang;
using java.sql;
using Task3Bd.Base;

namespace Task3Bd.H2
{
    public class ExecuteQuery : BaseEntity
    {
        private Statement _statement;
        private ResultSetMetaData _resultSetMetaData;
        private ResultSet _resultQuery;
        private readonly string _pathToResources = Environment.CurrentDirectory + "/Task3Bd/Resources/SqlQueries/";
        private const string Null = "<null>";
        private const string Dash = "-";
        private const string Space = " ";

        public void CreateStatement(ConnectionH2 conn)
        {
            _statement = conn.GetConnection().createStatement();
        }

        public void ExecuteFromFile(string fileNameQuery)
        {
            var sqlQuery = ReadSqlQueryFromFile(fileNameQuery);
            ExecuteSql(sqlQuery);
        }

        private string ReadSqlQueryFromFile(string fileName)
        {
            string text = System.IO.File.ReadAllText(_pathToResources + fileName);
            return text;
        }

        private static string Format(string str, int width)
        {
            StringBuffer buffer = new StringBuffer(str);
            for (int i = str.Length; i < width; ++i)
                buffer.append(Space);
            return buffer.toString();
        }

        private void DashLine(int[] columnWidths)
        {
            StringBuffer dashedLine = new StringBuffer();
            for (int i = 1; i <= columnWidths.Length; ++i)
            {
                for (int j = 1; j <= columnWidths[i - 1]; ++j)
                    dashedLine.append(Dash);
            }
            Log.Info(dashedLine.toString());
        }

        public void ExecuteSql(string sqlQuery)
        {
            string outputSrting = "";
            _resultQuery = _statement.executeQuery(sqlQuery);
            _resultSetMetaData = _resultQuery.getMetaData();
            int columnCount = _resultSetMetaData.getColumnCount();
            int[] columnWidths = new int[columnCount];
            for (int i = 1; i <= columnCount; ++i)
            {
                switch (columnCount)
                {
                    case 1:
                    {
                        columnWidths[0] = 100;
                    }break;

                    case 2:
                    {
                        columnWidths[0] = 60;
                        columnWidths[1] = 60;
                    }break;

                    case 3:
                    {
                        columnWidths[0] = 25;
                        columnWidths[1] = 140;
                        columnWidths[2] = 30;
                    }break;
                }
            }
            DashLine(columnWidths);
            Log.Info(sqlQuery);
            Log.Info("Sql query start to execute");
            DashLine(columnWidths);
            outputSrting = "";
            for (int i = 1; i <= columnCount; ++i)
            {
                outputSrting += Format(_resultSetMetaData.getColumnLabel(i), columnWidths[i - 1]);
            }
            Log.Info(outputSrting);
            DashLine(columnWidths);
            while (_resultQuery.next())
            {
                outputSrting = "";
                for (int i = 1; i <= columnCount; ++i)
                {
                    string value = _resultQuery.getString(i);
                    if (_resultQuery.wasNull())
                        value = Null;
                    outputSrting += Format(value, columnWidths[i - 1]);
                }
                Log.Info(outputSrting);
            }
            DashLine(columnWidths);
            Log.Info("Query was successed completed!");
        }
    }
}