using Domain.FriendshipDomain;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Data.FriendshipInfra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace Tests.FriendshipTest
{
    [TestClass]
    public class RepositoryFriendshipTest
    {
        private FriendshipContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<FriendshipContext>());

            _contextForTest = new FriendshipContext();
            _contextForTest.Friendships.Add(ObjectMother.GetFriendship());
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateFriendshipRepositoryTest()
        {
            Friendship b = ObjectMother.GetFriendship();
            IFriendshipRepository repository = new FriendshipRepository();

            Friendship newFriendship = repository.Save(b);

            Assert.IsTrue(newFriendship.Id > 0);
            Assert.IsTrue(newFriendship.posts[0].Id > 0);
        }

        [TestMethod]
        public void RetrieveFriendshipRepositoryTest()
        {
            IFriendshipRepository repository = new FriendshipRepository();

            Friendship friendship = repository.Get(1);

            Assert.IsNotNull(friendship);
            Assert.IsTrue(friendship.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(friendship.Name));

            friendship.Should().NotBeNull();
            friendship.ShouldBeEquivalentTo(ObjectMother.GetFriendship(), options => options.Excluding(b => b.Id));
        }

        [TestMethod]
        public void UpdateFriendshipRepositoryTest()
        {
            IFriendshipRepository repository = new FriendshipRepository();
            Friendship friendship = _contextForTest.Friendships.Find(1);
            friendship.Name = "teste";

            var updatedFriendship = repository.Update(friendship);

            var persistedFriendship = _contextForTest.Friendships.Find(1);
            Assert.IsNotNull(updatedFriendship);
            Assert.AreEqual(updatedFriendship.Id, persistedFriendship.Id);
            Assert.AreEqual(updatedFriendship.Name, persistedFriendship.Name);

            updatedFriendship.Should().NotBeNull();
            updatedFriendship.ShouldBeEquivalentTo(persistedFriendship);
        }

        [TestMethod]
        public void DeleteFriendshipRepositoryTest()
        {
            IFriendshipRepository repository = new FriendshipRepository();

            var deletedFriendship = repository.Delete(1);

            var persistedFriendship = _contextForTest.Friendships.Find(1);
            Assert.IsNull(persistedFriendship);

            persistedFriendship.Should().BeNull();
        }
    }
}