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
                            SELECT * FROM CafeUser WHERE UniqueGuid = LAST_INSERT_ID()";
            var connection = GetConnection();
            var returnuser = connection.QuerySingleOrDefault<CafeUser>(sql, CafeUser);//zou moeten falen(of defaulten?) als naam niet uniek
            return returnuser;
        }

        public CafeUser GetUser(CafeUser CafeUser)//login
        {
            string sql = @" SELECT * FROM CafeUser WHERE UserName = @UserName AND Password = @Password;";
            var connection = GetConnection();
            var returnuser = connection.QuerySingleOrDefault<CafeUser> (sql, CafeUser);
            return returnuser;
        }
        public CafeUser GetUser(int id)//ophalen van gegevens tijdens sessie
        {
            string sql = @"SELECT * WHERE UniqueGuid = @ID";
            var connection = GetConnection();
            var returnuser = connection.QuerySingleOrDefault<CafeUser>(sql, new {ID =id});
            return returnuser;
        }
    }
}
