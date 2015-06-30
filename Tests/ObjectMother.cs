using Domain.FriendshipDomain;
using Domain.PostDomain;
using System.Collections.Generic;

namespace Tests
{
    public class ObjectMother
    {
        public static Friendship GetFriendship()
        {
            Friendship friendship = new Friendship();
            friendship.Name = "user1";
            friendship.FollowersCount = 20;
            friendship.Id = 1;
            friendship.followers.Add(new Friendship()
            {
                Name = "user1",
                FollowersCount = 20,
                Id = 1,
                posts = new List<Post>() {
               new Post(){
                Id = 1,
                Name = "name1",
                Message = "Post1" }}
            });
            friendship.posts.Add(new Post()
            {
                Id = 1,
                Name = "name1",
                Message = "Post1"
            });

            friendship.posts.Add(new Post()
            {
                Id = 2,
                Name = "name2",
                Message = "Post2"
            });

            friendship.posts.Add(new Post()
            {
                Id = 3,
                Name = "name3",
                Message = "Post3"
            });

            friendship.posts.Add(new Post()
            {
                Id = 4,
                Name = "name4",
                Message = "Post4"
            });
            friendship.followers.Add(new Friendship()
            {
                Name = "user2",
                FollowersCount = 20,
                Id = 1
            });

            return friendship;
        }
    }
}