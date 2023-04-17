using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Enquiry;

namespace Safari_Wave.Repository.Interface
{
    public interface IEnquiryService
    {
        Task<IEnumerable<Enquiry>> GetAllEnquiries();
        Task<Enquiry> GetEnquiry(int id);
        Task<Enquiry> AddEnquiry(CreateEnquiryDTO enquiry);
        Task<Enquiry> UpdateEnquiry(int id,UpdateEnquiryDTO updateEnquiry);
        Task<bool> DeleteEnquiry(int id );
    }
}
