using SecurityApp.Data;
using SecurityApp.Service.IService;

namespace SecurityApp.Service
{
    public class NumberOfDaysForAccount : INumberOfDaysForAccount
    {
        private readonly SecurityAppDbContext _db;
        public NumberOfDaysForAccount(SecurityAppDbContext db)
        {
            _db = db;
        }
        public int Get(string userId)
        {
            var user = _db.applicationUser.FirstOrDefault(u => u.Id == userId);
            if (user != null && user.DateCreated != DateTime.MinValue)
            {
                return (DateTime.Today - user.DateCreated).Days;
            }
            return 0;
        }
    }
}
