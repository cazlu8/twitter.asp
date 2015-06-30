using Domain.PostDomain;
using Infrastructure;
using System;
using System.Collections.Generic;

namespace Domain.PostDomain
{
    public class Post : IObjectValidation
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public string User_id { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Message))
                throw new Exception("Messagem Inválida");
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Nome Inválido");
            if (string.IsNullOrEmpty(User_id))
                throw new Exception("User Id Invalido");
        }
    }
}