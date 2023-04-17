using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Enquiry;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Repository
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IMapper _mapper;
        private readonly SafariWaveContext _context;

        public EnquiryService(IMapper mapper,SafariWaveContext context)
        {
            _mapper = mapper;
            _context = context;
            
        }
        public async Task<Enquiry> AddEnquiry(CreateEnquiryDTO enquiryDto)
        {
            var enquiry = _mapper.Map<Enquiry>(enquiryDto);
            if (enquiry == null)
            {
                return null;
            }
            _context.Enquiries.Add(enquiry);
            await _context.SaveChangesAsync();
            return enquiry;


        }

        public async Task<bool> DeleteEnquiry(int id)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);
            if (enquiry == null)
            {
                return false;
            }
            _context.Remove(enquiry);
            return true;
        }

        public async Task<IEnumerable<Enquiry>> GetAllEnquiries()
        {
            var enquiries =await _context.Enquiries.ToListAsync();
            if (enquiries == null)
            {
                return null;
            }
            return enquiries;
        }

        public async Task<Enquiry> GetEnquiry(int id)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);
            if(enquiry == null)
            {
                return null;
            }
            return enquiry;
        }

        public async Task<Enquiry> UpdateEnquiry(int id,UpdateEnquiryDTO updateEnquiry)
        {
           var enquiry =await _context.Enquiries.FindAsync(id);
            if( enquiry == null)
            {
                return null;
            }
            _mapper.Map(updateEnquiry,enquiry);
            await _context.SaveChangesAsync();
            return enquiry;

        }
    }
}
