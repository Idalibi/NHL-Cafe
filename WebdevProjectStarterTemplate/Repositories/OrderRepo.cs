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

        public void AddOrder(OrderLine order)
        {
            using var connection = GetConnection();
            var sql = @"insert into OrderLine (RTableId, ProductId, Amount) values (@RTableId, @ProductId, @Amount);";
            connection.Execute(sql, order);

        }
        public void UpdateOrder(int AmountPaid)
        {

        }
        public void RemoveOrder(int RTableId, int ProductId)
        {

        }
        public List<OrderLine> GetOrders(int RTableId)
        {
            using var connection = GetConnection();
            var sql = @"SELECT * FROM OrderLine WHERE RtableId = @RTableId";
            var orders = connection.Query<OrderLine>(sql, new {RTableId = RTableId });
            return orders.ToList();
        }
        
    }
}