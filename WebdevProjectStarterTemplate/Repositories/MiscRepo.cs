using System.Collections;
using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class MiscRepo
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }
        public void createDatabase()
        {
            string fileURL = "MysqlCafe.SQL";
            string fileContent = File.ReadAllText(fileURL);
            using var connection = GetConnection();
            connection.Execute(fileContent);
        }
        public List<Table> GetTables()
        {
            string sql = @"SELECT * FROM RTable;";
            using var connection = GetConnection();
            var tables = connection.Query<Table>(sql);
            return tables.ToList();
        }

    }
}