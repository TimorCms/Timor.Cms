using FluentAssertions;
using Timor.Cms.Infrastructure.Attributes;
using Timor.Cms.Repository.MongoDb.Collections;
using Timor.Cms.Repository.MongoDb.EntityMappings;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Collections
{
    public class CollectionNameProviderTests
    {
        [MongoCollection("attr")]
        public class Test
        {

        }

        public class TestMap : MongoClassMap<Test>
        {
            public TestMap()
            {
                MapCollectionName("map");
            }
        }

        [Fact]
        public void ShouldReturnAttributeNameAsCollectionName()
        {
            var provider = new CollectionNameProvider<Test> {ClassMap = new TestMap()};

            var collectionName = provider.GetCollectionName();

            collectionName.Should().Be("attr");
        }
    }
}
