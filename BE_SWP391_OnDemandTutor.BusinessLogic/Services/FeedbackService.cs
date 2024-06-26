using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using OnDemandTutor.DataAccess.ExceptionModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IFeedbackService
    {
        Task<FeedbackViewModel> CreateFeedbacksAsync(CreateFeedbackRequestModel feedbacksCreate);
        Task<FeedbackViewModel> UpdateFeedbacks(UpdateFeedbackRequestModel feedbacksUpdate);
        Task<bool> DeleteFeedback(int idTmp);
        Task<List<FeedbackViewModel>> GetAll();
        Task<FeedbackViewModel> GetById(int idTmp);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;

        public FeedbackService(BE_SWP391_OnDemandTutorDbContext context)
        {
            _context = context;
        }


        public async Task<FeedbackViewModel> CreateFeedbacksAsync(CreateFeedbackRequestModel feedbacksCreate)
        {
            var feedbacks = feedbacksCreate.Adapt<Feedback>();

            _context.Feedbacks.Add(feedbacks);
            await _context.SaveChangesAsync();

            return feedbacks.Adapt<FeedbackViewModel>();
        }

        public async Task<FeedbackViewModel> UpdateFeedbacks(UpdateFeedbackRequestModel feedbacksUpdate)
        {
            var update = await _context.Feedbacks.FindAsync(feedbacksUpdate.FeedbackId);
            if (update == null)
            {
                throw new NotFoundException("Can not find the Feedback");
            }
            update.Evaluation = feedbacksUpdate.Evaluation;
            update.Content = feedbacksUpdate.Content;


            await _context.SaveChangesAsync();

            return update.Adapt<FeedbackViewModel>();
        }

        public async Task<bool> DeleteFeedback(int idTmp)
        {
            var delete = await _context.Feedbacks.FindAsync(idTmp);
            if (delete == null)
            {
                throw new NotFoundException("Can not find the Feedback");
            }

            _context.Feedbacks.Remove(delete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<FeedbackViewModel>> GetAll()
        {
            var feedbacks = await _context.Feedbacks.ToListAsync();
            return feedbacks.Select(feedbacks => new FeedbackViewModel
            {
                FeedbackID = feedbacks.FeedbackID,
                Evaluation = feedbacks.Evaluation,
                Content = feedbacks.Content,
                StudentId = feedbacks.StudentId,
                CreateDate = feedbacks.CreateDate,
                ClassId = feedbacks.ClassId

            }).ToList();
        }

        public async Task<FeedbackViewModel> GetById(int idTmp)
        {
            var feedbacks = await _context.Feedbacks.FindAsync(idTmp);
            if (feedbacks == null)
            {
                throw new NotFoundException("Can not find the Feedback");
            }

            return feedbacks.Adapt<FeedbackViewModel>();
        }

    }

}
