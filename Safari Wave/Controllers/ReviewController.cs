using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safari_Wave.Models.DTOs.Review;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;
        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllReview()
        {
            try
            {
                var reviews = await _reviewServices.GetAllReview();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> NewReview(ReviewReqDTO reviewDto)
        {
            var currentUser = HttpContext.User.Identity.Name;
            try
            {
                var review =await _reviewServices.AddReview(currentUser, reviewDto);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetReviewById(int id)
        {
            try
            {
                var review = await _reviewServices.GetReview(id);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("review/package")]
        public async Task<ActionResult> GetReviewsofPackage(int id)
        {
            try
            {
                var reviews = await _reviewServices.GetReviewsofPackage(id);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete/review")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleteReview =await _reviewServices.DeleteReview(id);
                return Ok(deleteReview);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
