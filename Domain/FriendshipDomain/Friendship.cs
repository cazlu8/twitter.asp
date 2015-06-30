using Domain.PostDomain;
using Infrastructure;
using System;
using System.Collections.Generic;

namespace Domain.FriendshipDomain
{
    public class Friendship : IObjectValidation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FollowersCount { get; set; }

        public List<Post> posts = new List<Post>();
        public List<Friendship> followers = new List<Friendship>();

        public void Follow(Friendship friendship)
        {
            this.FollowersCount += 1;
            followers.Add(friendship);
            foreach (var postsOfFriend in friendship.posts)
            {
                posts.Add(postsOfFriend);
            }
        }

        public void UnFollow(Friendship friendship)
        {
            this.FollowersCount -= 1;
            posts.RemoveAll(x => this.Id != friendship.Id);
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("nome Inválido");

            if (Id > 0)
                throw new Exception("Id Inválido");
        }
    }
}