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

        public IEnumerable<CustomerFeedback> getCustomerFeedbackByMovieId(int movieId)
        {
            return _context.CustomerFeedback.Where(cf => cf.movie_id == movieId).ToList();
        }

        public bool addCustomerFeedback(FletNixUser user, int rating, string comment, int movieId)
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
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<CustomerFeedback> getCustomerFeedbackByCustomer(string userEmail)
        {
            return _context.CustomerFeedback.Where(cf => cf.customer_mail_address == userEmail).ToList();
        }
    }
}
