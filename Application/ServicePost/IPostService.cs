using Domain.PostDomain;
using System.Collections.Generic;

namespace Application.ServicePost
{
    public interface IPostService
    {
        Post Create(Post post);

        Post Retrieve(int id);

        Post Update(Post post);

        Post Delete(int id);

        List<Post> RetrieveAll();
    }
}