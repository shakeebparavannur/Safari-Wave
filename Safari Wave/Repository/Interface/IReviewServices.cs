using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Review;

namespace Safari_Wave.Repository.Interface
{
    public interface IReviewServices
    {
        Task<Review> AddReview(string username,ReviewReqDTO reviewReqDto);
        Task<Review> UpdateReview(int id,ReviewReqDTO reviewReqDTO);
        Task<bool> DeleteReview(int id);
        Task<Review> GetReview(int id);
        Task<IEnumerable<Review>> GetAllReview();
        Task<IEnumerable<Review>> GetReviewsofPackage(int PackId);
    }
}
