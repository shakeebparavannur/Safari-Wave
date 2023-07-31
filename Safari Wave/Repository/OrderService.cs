using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Repository
{
    public class OrderService : IOrderService
    {
        private readonly SafariWaveContext _context;
        private readonly IMapper _mapper;


        public OrderService(SafariWaveContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            if(orders.Count == 0)
            {
                throw new Exception("No data found");
            }
            return orders;

        }

        public async Task<Order> MakeanOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
