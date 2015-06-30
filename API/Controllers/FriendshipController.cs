using Domain.FriendshipDomain;
using Domain.PostDomain;
using Infrastructure.Data.FriendshipInfra;
using Infrastructure.Data.PostInfra;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;

namespace twitter.Controllers
{
    public class FriendshipController : ApiController
    {
        private IFriendshipRepository friendshipRepository = new FriendshipRepository();
        private IPostRepository postRepository = new PostRepository();

        // GET api/friendship
        public IEnumerable<Friendship> Get()
        {
            return friendshipRepository.GetAll();
        }

        // GET api/friendship/5
        public Friendship Get(int id)
        {
            return friendshipRepository.Get(id);
        }

        // POST api/friendship
        public void Post([FromBody] Friendship friendship)
        {
            friendshipRepository.Save(friendship);
        }

        [HttpGet]
        [Route("api/friendship/posts/id")]
        public IEnumerable<Post> GetAllPostsOfFriendship(Friendship friendship)
        {
            IEnumerable<Post> posts = null;
            foreach (var post in friendship.posts)
            {
                posts = postRepository.GetAll().Where(x => x.Message == post.Message);
            }
            return posts;
        }

        // PUT api/friendship/5
        public void Put(int id, [FromBody] Friendship friendship)
        {
            friendshipRepository.Update(friendshipRepository.Get(friendship.Id));
        }

        // DELETE api/friendship/5
        public void Delete(int id)
        {
            friendshipRepository.Delete(id);
        }
    }
}