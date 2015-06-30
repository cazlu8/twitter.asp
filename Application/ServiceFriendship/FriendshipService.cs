using Domain.FriendshipDomain;
using Domain.PostDomain;
using Infrastructure;
using System.Collections.Generic;

namespace Application.ServiceFriendship
{
    public class FriendshipService : IFriendshipService
    {
        private IFriendshipRepository _FriendshipRepository;

        public FriendshipService(IFriendshipRepository FriendshipRepository)
        {
            _FriendshipRepository = FriendshipRepository;
        }

        public Friendship Create(Friendship friendship)
        {
            Validator.Validate(friendship);

            var saveFriendship = _FriendshipRepository.Save(friendship);
            return saveFriendship;
        }

        public Friendship Retrieve(int id)
        {
            return _FriendshipRepository.Get(id);
        }

        public Friendship Update(Friendship friendship)
        {
            Validator.Validate(friendship);

            var updateFriendship = _FriendshipRepository.Update(friendship);
            return updateFriendship;
        }

        public Friendship Delete(int id)
        {
            return _FriendshipRepository.Delete(id);
        }

        public List<Friendship> RetrieveAll()
        {
            return _FriendshipRepository.GetAll();
        }
    }
}