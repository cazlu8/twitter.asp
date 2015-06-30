using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PostDomain
{
    public interface IPostRepository
    {
        Post Save(Post post);

        Post Get(int id);

        Post Update(Post post);

        Post Delete(int id);

        List<Post> GetAll();
    }
}