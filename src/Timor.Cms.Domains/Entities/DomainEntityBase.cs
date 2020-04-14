namespace Timor.Cms.Domains.Entities
{
    public abstract class DomainEntityBase : DomainEntityBase<string>
    {
    }

    public abstract class DomainEntityBase<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}