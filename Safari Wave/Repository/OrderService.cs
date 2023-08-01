using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Order;
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

        public async Task<IEnumerable<Order>> GetOrderByUser(string username)
        {
            var orders = await _context.Orders.Include(x=>x.Booking).ThenInclude(x=>x.Package).Where(x => x.Booking.UserId == username).ToListAsync();
            if(orders.Count == 0)
            {
                throw new ArgumentNullException("No orders found");
            }
            return orders;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _context.Orders.Include(x=>x.Booking).ToListAsync();
            if(orders.Count == 0)
            {
                throw new Exception("No data found");
            }
            return orders;

        }

        public async Task<Order> MakeanOrder(MakeOrderDTO order)
        {
            var booking=_context.Bookings.FirstOrDefault(x=>x.BookingId==order.BookingId);
            if (booking == null)
            {
                throw new ArgumentNullException("Booking not found");
            }
            var _order = _mapper.Map<Order>(order);
            _context.Orders.Add(_order);
            _context.SaveChanges();
            return _order;
        }

        public async Task<Order> UpdateOrder(int id,OrderUpdateDTO order)
        {
            var _order =await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (_order == null)
            {
                throw new Exception("No order found");
            }
            _order.Status = order.Status;
            _order.PaymentStatus = order.PaymentStatus;

            _context.SaveChangesAsync();

            return _order;

        }
    }
}
