using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Models; 

namespace eCommerce.Repository
{
    public class UserData : IDataRepository<User>
    {
        private readonly ShopDBContext _context; 
        public UserData (ShopDBContext context)
        {
            _context = context; 
        }
        
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList(); 
        }
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(e => e.Id == id); 
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(); 
        }
        public void Update(User user, User entity)
        {
            user.username = entity.username;
            user.password = entity.password;
            _context.SaveChanges(); 
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges(); 
        }
    }
}
