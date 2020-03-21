using System;

namespace Timor.Cms.Domains.Entities
{
    public abstract class Entity : Entity<int>
    {

    }

    public abstract class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
