using System.Collections;
using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class OrderRepo
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }

        public void AddOrder(int RTableId, int ProductId, int Amount)
        {

        }
        public void UpdateOrder(int AmountPaid)
        {

        }
        public void RemoveOrder(int RTableId, int ProductId)
        {

        }
        public List<OrderLine> GetOrders(int RTableId)
        {

            return null;
        }
        
    }
}