using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Domains.Articles;

namespace Timor.Cms.Repository.MongoDb.Articles
{
    public class CategoryRepository : MongoDbRepository<Category>
    {
        public CategoryRepository() : base(new MongoCollectionProvider(), "category")
        {
        }
    }
}
