using AutoMapper;
using MongoDB.Bson;
using Domain= Timor.Cms.Domains;
using Po = Timor.Cms.PersistModels.MongoDb;

namespace Timor.Cms.Repository.MongoDb
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<ObjectId, string>()
                .ForMember(dest => dest, option => { option.MapFrom(source => source.ToString()); });

            CreateMap<string, ObjectId>()
                .ForMember(dest => dest, option => { option.MapFrom(source => ObjectId.Parse(source)); });

            CreateMap<Domain.Articles.Article, Po.Articles.Article>().ReverseMap();
        }
    }
}