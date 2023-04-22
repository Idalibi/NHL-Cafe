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
        public void UpdateOrder(OrderLine neworder)
        {
            using var connection = GetConnection();
            var sql = @"UPDATE OrderLine
                        SET Amount = @Amount
                        WHERE RTableId = @RTableID && ProductId = @ProductID;";
            connection.Execute(sql, neworder);
        }
        public void RemoveOrder(int RTableId, int ProductId)
        {

        }
        public List<OrderLine> GetOrders(int RTableId)
        {
            using var connection = GetConnection();
            var sql = @"select Amount, AmountPaid, Price, (Price*(Amount-AmountPaid)) as Total, p.Name as Name, p.ProductId from orderline o 
                        join product p on o.ProductId = p.ProductId WHERE RtableId = @RTableId";
            var orders = connection.Query<OrderLine>(sql, new { RTableId });
            return orders.ToList();
        }
        public void Betaal(OrderLine order)
        {
            using var connection = GetConnection();
            var sql = @"UPDATE OrderLine
                        SET AmountPaid = @AmountPaid
                        WHERE RtableId = @RTableId && ProductId = @ProductId;";
            connection.Execute(sql, order);
        }
        
    }
}