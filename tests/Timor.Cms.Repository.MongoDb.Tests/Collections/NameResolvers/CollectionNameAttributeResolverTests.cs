using FluentAssertions;
using Timor.Cms.Infrastructure.Attributes;
using Timor.Cms.Repository.MongoDb.Collections.NameResolvers;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Collections.NameResolvers
{
    public class CollectionNameAttributeResolverTests
    {
        [MongoCollection("test")]
        public class HasCollectionAttribute
        {

        }

        public class NotHaveCollectionAttribute
        {
            
        }

        [Fact]
        public void ShouldReturnAttributeValueWhenClassApplyAttribute()
        {
            var resolver = new CollectionNameAttributeResolver<HasCollectionAttribute>();

            var collectionName = resolver.ResolveCollectionName();

            collectionName.Should().BeEquivalentTo("test");
        }

        [Fact]
        public void ShouldReturnNullWhenNotApplyAttribute()
        {
            var resolver = new CollectionNameAttributeResolver<NotHaveCollectionAttribute>();

            var collectionName = resolver.ResolveCollectionName();

            collectionName.Should().BeNull();
        }
    }
}
