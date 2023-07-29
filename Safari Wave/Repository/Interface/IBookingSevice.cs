using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Booking;

namespace Safari_Wave.Repository.Interface
{
    public interface IBookingSevice
    {
        Task <BookingResponseDTO> BookingPackage ( string username,CreateBookingDTO  booking);
        Task<IEnumerable<BookingResponseDTO>> GetBookings();
        Task<BookingResponseIdDTO> GetBookingPackageById(int id);
        Task <IEnumerable<BookingResponseDTO>> GetBookingByUser(string user);
        Task<BookingResponseDTO> BookingStatusUpdate(int id, BookingUpdateDTO bookingUpdate);
        Task<BookingResponseDTO> CancelBooking(string user,int id);

    }
}
