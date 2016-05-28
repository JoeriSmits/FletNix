using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FletNix.Models
{
    public interface ICustomerFeedbackRepository
    {
        IEnumerable<CustomerFeedback> getCustomerFeedbackByMovieId(int movieId);
        bool addCustomerFeedback(FletNixUser user, int rating, string comment, int movieId);
        IEnumerable<CustomerFeedback> getCustomerFeedbackByCustomer(string userEmail);
    }
}
