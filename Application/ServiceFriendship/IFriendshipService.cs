using Domain.FriendshipDomain;
using Domain.PostDomain;
using System.Collections.Generic;

namespace Application.ServiceFriendship
{
    public interface IFriendshipService
    {
        Friendship Create(Friendship friendship);

        Friendship Retrieve(int id);

        Friendship Update(Friendship friendship);

        Friendship Delete(int id);

        List<Friendship> RetrieveAll();
    }
}