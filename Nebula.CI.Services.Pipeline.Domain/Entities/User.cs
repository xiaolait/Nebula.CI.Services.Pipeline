using System;
using Volo.Abp.Domain.Entities;

namespace Nebula.CI.Services.Pipeline
{
    public class User : AggregateRoot<int>
    {
        public string IdentityId { get; protected set; }

        protected User()
        {

        }

        public User(string identityId)
        {
            IdentityId = identityId;
        }
    }
}