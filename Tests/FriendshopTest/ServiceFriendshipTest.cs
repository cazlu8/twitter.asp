using Application.ServiceFriendship;
using Domain.FriendshipDomain;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.FriendshipTest
{
    [TestClass]
    public class ServiceFriendshipTest
    {
        private Friendship _Friendship;
        private MockRepository _mockRepository;
        private Mock<IFriendshipRepository> _FriendshipRepoMoq;
        private FriendshipService _service;

        [TestInitialize]
        public void Setup()
        {
            _Friendship = ObjectMother.GetFriendship();
            _mockRepository = new MockRepository(MockBehavior.Default);
            _FriendshipRepoMoq = _mockRepository.Create<IFriendshipRepository>();
            _service = new FriendshipService(_FriendshipRepoMoq.Object);
        }

        [TestMethod]
        public void CreateAFriendshipTest()
        {
            _FriendshipRepoMoq.Setup(a => a.Save(It.IsAny<Friendship>()));

            var Friendship = _mockRepository.Create<Friendship>();

            Friendship.As<IObjectValidation>().Setup(a => a.Validate());

            _service.Create(Friendship.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveAFriendshipTest()
        {
            _FriendshipRepoMoq.Setup(a => a.Get(It.IsAny<int>()));

            _service.Retrieve(1);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RetrieveAllAFriendshipTest()
        {
            _FriendshipRepoMoq.Setup(a => a.GetAll());

            _service.RetrieveAll();

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void UpdateAFriendshipTest()
        {
            _FriendshipRepoMoq.Setup(a => a.Update(It.IsAny<Friendship>()));

            var Friendship = _mockRepository.Create<Friendship>();

            _service.Update(Friendship.Object);

            _mockRepository.VerifyAll();
        }

        [TestMethod]
        public void DeleteAFriendshipTest()
        {
            _FriendshipRepoMoq.Setup(a => a.Delete(It.IsAny<int>()));

            _service.Delete(1);

            _mockRepository.VerifyAll();
        }
    }
}