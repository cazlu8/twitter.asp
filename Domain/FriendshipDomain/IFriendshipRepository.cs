using Domain.PostDomain;
using System.Collections.Generic;

namespace Domain.FriendshipDomain
{
    public interface IFriendshipRepository
    {
        Friendship Save(Friendship Friendship);

        Friendship Get(int id);

        Friendship Update(Friendship Friendship);

        Friendship Delete(int id);

        List<Friendship> GetAll();
    }
}