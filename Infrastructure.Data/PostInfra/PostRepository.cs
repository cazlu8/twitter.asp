using Domain.PostDomain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Infrastructure.Data.PostInfra
{
    public class PostRepository : IPostRepository
    {
        private FriendshipContext _context;

        public PostRepository()
        {
            _context = new FriendshipContext();
        }

        public Post Save(Post Post)
        {
            var newPost = _context.Posts.Add(Post);
            _context.SaveChanges();
            return newPost;
        }

        public Post Get(int id)
        {
            var post = _context.Posts.Find(id);
            return post;
        }

        public Post Update(Post post)
        {
            DbEntityEntry entry = _context.Entry(post);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return post;
        }

        public Post Delete(int id)
        {
            var post = _context.Posts.Find(id);
            DbEntityEntry entry = _context.Entry(post);
            entry.State = EntityState.Deleted;
            _context.SaveChanges();
            return post;
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }
    }
}