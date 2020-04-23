# Timor CMS

Timor CMS 是一款非常轻量级的内容管理系统，它不支持过多花里胡哨的功能，只会支持最基本的文章及分类的管理。

## 构建状态
[![Build Status](https://dev.azure.com/timorcms/Timor.Cms/_apis/build/status/TimorCms.Timor.Cms?branchName=master)](https://dev.azure.com/timorcms/Timor.Cms/_build/latest?definitionId=1&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TimorCms_Timor.Cms&metric=alert_status)](https://sonarcloud.io/dashboard?id=TimorCms_Timor.Cms)

## 技术栈

- 前端页面及API：.NET Core  5.0 Preview (后续会持续升级到最新版的.NET Core)

- 后台管理站点：Vue + Element

- 数据库访问层：EF + SqlSugar

- 数据库：同时支持MySQL，SqlServer，MongoDB，Postgre SQL

- 缓存：支持Redis和进程内缓存 （优先级会比较低）

- 支持Docker和K8S部署

- Autofac作为IOC容器

  

## 功能特性

### 前台站点

- [ ] 官网首页
- [ ] 新闻列表页
- [ ] 专栏页（关于我们，公司简介等）
- [ ] 新闻详情页
- [ ] 站内搜索

### 管理后台

- [ ] 用户登录
- [ ] 新闻分类管理
- [ ] 新闻管理、编辑
- [ ] 专栏管理
- [ ] LOGO管理
- [ ] 页面广告管理（轮播、Banner)
- [ ] 页面静态化支持
- [ ] 网站访问限制（IP黑白名单）
- [ ] 全站备份（手动）
- [ ] 访问统计
- [ ] 管理员新增删除
- [ ] 管理员权限设置
- [ ] 全站备份（定时）
- [ ] 剩下的还没想好，但是功能不会太多...

## 定位

本项目致力于帮助开发人员快速实现一个新闻、企业官网系统。

我们可以想这样一种场景，有客户想构建一个展示型的官网。接到这个任务后，首先，我们需要找一个UX帮助做UI的设计；然后当设计完成后，开发人员需要将UX给的设计稿转换为动态页面，并实现一个后台管理系统，来帮助客户管理内容。如果有做过类似项(si)目(huo) 的伙计都知道，其实大部分时间都是在搞后台管理系统，前端往往是很快速就可以实现的。

那有人想问，难道就没有一个开源项目可以做吗？据我所知，目前市面上大部分的CMS系统，都是比较复杂的，上手的成本比较高，而且花里胡哨的功能也比较多，但是往往来说，根本用不上那么多的功能。比如像织梦这种CMS系统，虽然支持了一堆高端的标签，但是对于一个.NET开发人员来说，远没有Razor来的顺手，对吗？再比如像纸壳这种CMS，虽然他很强大，支持后端可视化编辑，但是真心不如让开发人员自己写Razor来做，毕竟可视化做的再牛，也不可能有自己写代码控制能力强。

所以，在这个项目中，我的重点精力会放在后台文章管理系统，而前端，只会做一些常见的网站有的模块，供开发人员参考。开发人员在下载本项目后，后台模块是几乎不需要做任何改动（除非有一些定制化的需求），而只需要把前台UX给的静态页面变成动态的，而这个转换的过程，大部分只是需要将Razor中的示例HTML替换掉。

## 成功案例

如果您使用本项目成功的交付了项目，并且如果不需要保密的话，可以将您的项目提交到我的邮箱：baiyunchen@vip.qq.com，等有一定数量之后，我会将它展示到这里。

## 捐赠

如果这个项目帮助您的公司节约了成本和时间，或者为您的私活节约了时间，请留下你的Star。钱到账了之后，也可以请我喝杯咖啡。扫码转账或者面基（仅限西安）均可以。

