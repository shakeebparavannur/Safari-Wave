using Safari_Wave.Models;

namespace Safari_Wave.Repository.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> MakeanOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<Order> GetOrderById(int id);

    }
}
