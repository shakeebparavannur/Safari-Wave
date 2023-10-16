using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Booking;
using Safari_Wave.Repository.Interface;
using System.Security.Claims;

namespace Safari_Wave.Repository
{
    public class BookingService : IBookingSevice
    {
        private readonly SafariWaveContext _context;
        private readonly IMapper _mapper;


        public BookingService(SafariWaveContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }
        public async Task<BookingResponseDTO> BookingPackage(string username, CreateBookingDTO booking)
        {
            var package = _context.Packages.Find(booking.PackageId);
            decimal amount = package.OfferPrice * booking.NoOfPerson;


            Booking booking1 = new Booking()
            {
                UserId = username,
                PackageId = booking.PackageId,
                Date = DateTime.UtcNow,
                DateOfTrip = booking.DateOfTrip,
                NoOfPerson = booking.NoOfPerson,
                Amount = amount,
                Payment = "pending",
                Status = "booked"
               
            };
            _context.Bookings.Add(booking1);
            await _context.SaveChangesAsync();
            var bookingResposeDto = _mapper.Map<BookingResponseDTO>(booking1);
            return bookingResposeDto;
        }

        public async Task<BookingResponseDTO> BookingStatusUpdate(int id, BookingUpdateDTO bookingUpdate)
        {

            
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);
            if (booking == null)
            {
                throw new Exception("Not Found");
            }
            booking.Status = bookingUpdate.Status;
            await _context.SaveChangesAsync();
            var bookingDto = _mapper.Map<BookingResponseDTO>( booking);
            return bookingDto;
        }
       


        public async Task<BookingResponseDTO> CancelBooking(string user,int id)
        {
            
            var booking = _context.Bookings.FirstOrDefault(b => b.UserId==user && b.BookingId == id);
            if (booking == null)
            {
                throw new Exception("Invalid Entry");
            }
            if (booking.Status == "pending" && booking.Payment == "Pending")
            {
                booking.Status = "Cancel";
                await _context.SaveChangesAsync();
                var bookingDto = _mapper.Map<BookingResponseDTO>(booking); 
                return bookingDto;
            }
            else
            {
                throw new Exception("You cannot cancel Your Order");
            }
        }

        public async Task<IEnumerable<BookingResponseDTO>> GetBookingByUser(string user)
        {
            var bookings = await _context.Bookings.Where(b => b.UserId == user).ToListAsync();
            if (bookings.Count == 0)
            {
                return null;
            }
            var bookingDto = _mapper.Map<List<BookingResponseDTO>>(bookings);
            return bookingDto;
        }

        public async Task<BookingResponseIdDTO> GetBookingPackageById(int id)
        {
            var booking = await _context.Bookings.Include(p=>p.Package).Include(b=>b.User).FirstOrDefaultAsync(x=>x.BookingId==id);
            if (booking == null)
            {
                return null;
            }
            var bookingDto = _mapper.Map<BookingResponseIdDTO>(booking);
            return bookingDto;
        }
        
        public async Task<IEnumerable<BookingResponseDTO>> GetBookings()
        {
            var bookings = await _context.Bookings.OrderBy(b => b.DateOfTrip).ToListAsync();
            if (bookings == null)
            {
                return null;
            }
            var bookingDto = _mapper.Map<List<BookingResponseDTO>>(bookings);
            return bookingDto;
        }


    }
}
