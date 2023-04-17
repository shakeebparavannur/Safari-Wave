using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Review;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Repository
{
    public class ReviewService : IReviewServices
    {
        private readonly SafariWaveContext _context;
        private readonly IMapper _mapper;
        public ReviewService(SafariWaveContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Review> AddReview(string username,ReviewReqDTO reviewReqDto)
        {
            var review = new Review()
            {
                Review1 = reviewReqDto.Review1,
                Rating = reviewReqDto.Rating,
                PackageId = reviewReqDto.PackageId,
                UserName = username,
                Package =await _context.Packages.FirstOrDefaultAsync(x => x.PackId == reviewReqDto.PackageId),

            };
            if(review ==  null )
            {
                return null;
            }
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;

        }

        public async Task <bool> DeleteReview(int id)
        {
            var review =await _context.Reviews.FirstOrDefaultAsync(x=>x.ReviewId == id);
            if(review == null)
            {
                return false;
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<IEnumerable<Review>> GetAllReview()
        {
            var reviews = await _context.Reviews.ToListAsync();
            if(reviews== null)
            {
                return null;
            }
            return reviews;
        }

        public async Task<Review> GetReview(int id)
        {
           var review = await _context.Reviews.FirstOrDefaultAsync(x=>x.ReviewId==id);
            if(review == null)
            {
                return null;
            }
            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewsofPackage(int PackId)
        {
            var reviews =await _context.Reviews.Where(p=>p.PackageId==PackId).ToListAsync();
            if(reviews== null)
            {
                return null;
            }
            return reviews;
        }

        public async Task<Review> UpdateReview(int id, ReviewReqDTO reviewReqDTO)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x=>x.ReviewId == id);
            if(review == null)
            {
                return null;
            }
            _mapper.Map(reviewReqDTO, review);
            await _context.SaveChangesAsync();
            return review;
        }
    }
}
