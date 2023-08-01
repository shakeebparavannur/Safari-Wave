using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Order;

namespace Safari_Wave.Repository.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> MakeanOrder(MakeOrderDTO order);
        Task<Order> UpdateOrder(int id, OrderUpdateDTO order);
        Task<Order> GetOrderById(int id);
        Task <IEnumerable<Order>> GetOrderByUser(string username);

    }
}
