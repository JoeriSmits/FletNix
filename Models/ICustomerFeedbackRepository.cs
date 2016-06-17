using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface ICustomerFeedbackRepository
    {
        Task<IEnumerable<CustomerFeedback>> getCustomerFeedbackByMovieId(int movieId);
        Task<bool> addCustomerFeedback(FletNixUser user, int rating, string comment, int movieId);
        Task<IEnumerable<CustomerFeedback>> getCustomerFeedbackByCustomer(string userEmail);
    }
}
