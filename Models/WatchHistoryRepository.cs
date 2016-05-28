using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace FletNix.Models
{
    public class WatchHistoryRepository : IWatchHistoryRepository
    {
        private FletNixContext _context;

        public WatchHistoryRepository(FletNixContext context)
        {
            _context = context;
        }

        public bool AddWatchHistory(int movieId, FletNixUser user)
        {
            if (!alreadyCustomer(user))
            {
                var customer = new Customer();
                customer.customer_mail_address = user.Email;
                customer.name = user.UserName;
                customer.paypal_account = user.Email;
                customer.subscription_start = DateTime.Now.Date;
                customer.subscription_end = DateTime.Now.AddMonths(3).Date;
                customer.password = "Protected";

                try
                {
                    _context.Customer.Add(customer);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return addWatch(movieId, user);
        }

        public IEnumerable<Watchhistory> getWatchHistoryByCustomer(string userEmail)
        {
            return _context.Watchhistory.Include(w => w.movie).Where(w => w.customer_mail_address == userEmail);
        }

        private bool alreadyCustomer(FletNixUser user)
        {
            return _context.Customer.Count(c => c.customer_mail_address == user.Email) > 0;
        }

        private bool addWatch(int movieId, FletNixUser user)
        {
            var watchHistory = new Watchhistory();
            watchHistory.movie_id = movieId;
            watchHistory.customer_mail_address = user.Email;
            watchHistory.price = (decimal)2.50;
            watchHistory.watch_date = DateTime.Now.Date;
            watchHistory.invoiced = false;

            try
            {
                _context.Watchhistory.Add(watchHistory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
