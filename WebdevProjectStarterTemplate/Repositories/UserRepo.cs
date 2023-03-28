using System.Collections;
using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class UserRepo
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }

        public CafeUser AddUser(CafeUser CafeUser) //register/sign up
        {
            string sql = @" INSERT INTO CafeUser (UserName, Password) VALUES (@UserName, @Password);
                            SELECT * FROM CafeUser WHERE UniqueId = LAST_INSERT_ID()";
            var connection = GetConnection();
            var returnuser = connection.QuerySingleOrDefault<CafeUser>(sql, CafeUser);//zou moeten falen als niet uniek
            return returnuser;
        }
    }
}
