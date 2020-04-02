using FluentAssertions;
using Timor.Cms.Repository.MongoDb.Collections.NameResolvers;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Collections.NameResolvers
{
    public class CollectionNameDefaultResolverTests
    {
        public class Test
        {

        }

        [Fact]
        public void ShouldReturnClassName()
        {
            var resolver = new CollectionNameDefaultResolver<Test>();

            var collectionName = resolver.ResolveCollectionName();

            collectionName.Should().Be(nameof(Test));

        }
    }
}
