using Domain.PostDomain;
using Infrastructure;
using System.Collections.Generic;

namespace Application.ServicePost
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Create(Post post)
        {
            Validator.Validate(post);

            var savePost = _postRepository.Save(post);
            return savePost;
        }

        public Post Retrieve(int id)
        {
            return _postRepository.Get(id);
        }

        public Post Update(Post Post)
        {
            Validator.Validate(Post);

            var updatePost = _postRepository.Update(Post);
            return updatePost;
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public List<Post> RetrieveAll()
        {
            return _postRepository.GetAll();
        }
    }
}