using FluentAssertions;
using Timor.Cms.Repository.MongoDb.Collections.NameResolvers;
using Timor.Cms.Repository.MongoDb.EntityMappings;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Collections.NameResolvers
{
    public class CollectionNameClassMapResolverTests
    {
        public class Test
        {

        }

        public class TestMap : MongoClassMap<Test>
        {
            public TestMap()
            {
                MapCollectionName("test");
            }
        }

        [Fact]
        public void ShouldGetCollectionNameFromMap()
        {
            var resolver = new CollectionNameClassMapResolver<Test>(new TestMap());

            var collectionName = resolver.ResolveCollectionName();

            collectionName.Should().BeEquivalentTo("test");
        }
    }
}
