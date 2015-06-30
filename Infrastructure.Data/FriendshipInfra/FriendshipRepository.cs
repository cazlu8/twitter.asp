using Domain.FriendshipDomain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Infrastructure.Data.FriendshipInfra
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private FriendshipContext _context;

        public FriendshipRepository()
        {
            _context = new FriendshipContext();
        }

        public Friendship Save(Friendship friendship)
        {
            var newFriendship = _context.Friendships.Add(friendship);
            _context.SaveChanges();
            return newFriendship;
        }

        public Friendship Get(int id)
        {
            var Friendship = _context.Friendships.Find(id);
            return Friendship;
        }

        public Friendship Update(Friendship friendship)
        {
            DbEntityEntry entry = _context.Entry(friendship);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return friendship;
        }

        public Friendship Delete(int id)
        {
            var friendship = _context.Friendships.Find(id);
            DbEntityEntry entry = _context.Entry(friendship);
            entry.State = EntityState.Deleted;
            _context.SaveChanges();
            return friendship;
        }

        public List<Friendship> GetAll()
        {
            return _context.Friendships.ToList();
        }
    }
}