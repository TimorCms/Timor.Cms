using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Infrastructure.Extensions;
using Domain= Timor.Cms.Domains;
using Po = Timor.Cms.PersistModels.MongoDb;

namespace Timor.Cms.Repository.MongoDb
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<ObjectId, string>()
                .ConstructUsing(source=>source.ToString());

            CreateMap<string, ObjectId>()
                .ConvertUsing(source=>source.IsNullOrEmpty()? ObjectId.Empty: ObjectId.Parse(source));

            CreateMap<Domain.Articles.Article, Po.Articles.Article>().ReverseMap();
            CreateMap<Domain.Articles.Attachment, Po.Articles.Attachment>().ReverseMap();
            CreateMap<Domain.Articles.Seo, Po.Articles.Seo>().ReverseMap();
            CreateMap<Domain.Articles.Category, Po.Articles.Category>().ReverseMap();
        }
    }
}