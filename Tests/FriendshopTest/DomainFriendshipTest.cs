using Domain.FriendshipDomain;
using FluentAssertions;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.FriendshipTest
{
    [TestClass]
    public class DomainFriendshipTest
    {
        private Friendship _Friendship;

        [TestInitialize]
        public void Setup()
        {
            _Friendship = ObjectMother.GetFriendship();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidFriendshipTest()
        {
            _Friendship.Should().Be(_Friendship);
            Validator.Validate(_Friendship);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAValidFriendshiNameAndIdTest()
        {
            Friendship Friendship = new Friendship();
            Friendship.Name = "Lages";
            Friendship.Id = 1;
            Validator.Validate(Friendship);
        }
    }
}