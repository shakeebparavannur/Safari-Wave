using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safari_Wave.Models.DTOs.Enquiry;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiryService _enquiryservice;
        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryservice = enquiryService;
        }
        [HttpPost]
        public async Task<ActionResult> NewEnquiry(CreateEnquiryDTO enquiryDTO)
        {
            var enquiry = await _enquiryservice.AddEnquiry(enquiryDTO);
            return Ok(enquiry);
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateStatus(int id, UpdateEnquiryDTO enquiryDTO)
        {
            var updated = await _enquiryservice.UpdateEnquiry(id, enquiryDTO);
            return Ok(updated);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> GetEnquiry()
        {
            try
            {
                var enquiries = await _enquiryservice.GetAllEnquiries();
                return Ok(enquiries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        
        public async Task<ActionResult> GetEnquiryById(int id)
        {
            try
            {
                var enquiry = await _enquiryservice.GetEnquiry(id);
                return Ok(enquiry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEnquiry(int id)
        {
            try
            {
                var enquiry = await _enquiryservice.DeleteEnquiry(id);
                return Ok(enquiry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
