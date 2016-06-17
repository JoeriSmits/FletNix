using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace FletNix.Models
{
    public class CustomerFeedbackRepository : ICustomerFeedbackRepository
    {
        private FletNixContext _context;

        public CustomerFeedbackRepository(FletNixContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerFeedback>> getCustomerFeedbackByMovieId(int movieId)
        {
            IQueryable<CustomerFeedback> query = _context.CustomerFeedback.AsNoTracking();
            return await query.Where(cf => cf.movie_id == movieId).ToListAsync();
        }

        public async Task<bool> addCustomerFeedback(FletNixUser user, int rating, string comment, int movieId)
        {
            try
            {
                var customerFeedback = new CustomerFeedback();
                customerFeedback.comments = comment;
                customerFeedback.rating = rating;
                customerFeedback.movie_id = movieId;
                customerFeedback.feedback_date = DateTime.Now.Date;
                customerFeedback.customer_mail_address = user.Email;

                _context.CustomerFeedback.Add(customerFeedback);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CustomerFeedback>> getCustomerFeedbackByCustomer(string userEmail)
        {
            IQueryable<CustomerFeedback> query = _context.CustomerFeedback.AsNoTracking();
            return await query.Where(cf => cf.customer_mail_address == userEmail).ToListAsync();
        }
    }
}
