using System;
using System.Collections.Generic;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Entities;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles
{
    public static class ArticleBuilder
    {
        public static Article Build(Action<Article> modifier = null)
        {
            var article = new Article
            {
                Title = "Timor CMS 简介",
                SubTitle = "Timor Cms",
                ShortDescription = "Timor CMS 是一款非常轻量级的内容管理系统，它不支持过多花里胡哨的功能，只会支持最基本的文章及分类的管理。",
                Content = @"本项目致力于帮助开发人员快速实现一个新闻、企业官网系统。
                我们可以想这样一种场景，有客户想构建一个展示型的官网。接到这个任务后，首先，我们需要找一个UX帮助做UI的设计；然后当设计完成后，开发人员需要将UX给的设计稿转换为动态页面，并实现一个后台管理系统，来帮助客户管理内容。如果有做过类似项(si)目(huo) 的伙计都知道，其实大部分时间都是在搞后台管理系统，前端往往是很快速就可以实现的。
                那有人想问，难道就没有一个开源项目可以做吗？据我所知，目前市面上大部分的CMS系统，都是比较复杂的，上手的成本比较高，而且花里胡哨的功能也比较多，但是往往来说，根本用不上那么多的功能。比如像织梦这种CMS系统，虽然支持了一堆高端的标签，但是对于一个.NET开发人员来说，远没有Razor来的顺手，对吗？再比如像纸壳这种CMS，虽然他很强大，支持后端可视化编辑，但是真心不如让开发人员自己写Razor来做，毕竟可视化做的再牛，也不可能有自己写代码控制能力强。
                所以，在这个项目中，我的重点精力会放在后台文章管理系统，而前端，只会做一些常见的网站有的模块，供开发人员参考。开发人员在下载本项目后，后台模块是几乎不需要做任何改动（除非有一些定制化的需求），而只需要把前台UX给的静态页面变成动态的，而这个转换的过程，大部分只是需要将Razor中的示例HTML替换掉。",
                Author = "白云晨",
                PublishDate = DateTime.Now,
                ReferenceUrl = "http://timorcms.com/timor-cms.html",
                VisitCount = new Random(100).Next(10, 100000),
                CoverImage = AttachmentBuilder.Build(),
                Attachments = new List<Attachment>
                {
                    AttachmentBuilder.Build()
                },
                Seo = SeoBuilder.BuildForArticle(),
                Categories = new List<Category>
                {
                    CategoryBuilder.Build()
                }
            };

            AuditingEntityBuilder.PopulateAuditingInfo(article);

            modifier?.Invoke(article);

            return article;
        }
    }
}
