﻿using Blog.Core.Auth;
using Sixpence.ORM.Entity;
using Blog.Core.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sixpence.ORM.Models;
using Blog.Business.Blog.Sync;
using Sixpence.Common.Utils;
using Blog.Core.Auth.UserInfo;

namespace Blog.Business.Blog
{
    public class BlogController : EntityBaseController<blog, BlogService>
    {
        /// <summary>
        /// 查询所有博客菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> GetBlogRouterNameList()
        {
            return new BlogService().GetBlogRouterNameList();
        }

        /// <summary>
        /// 获取所有博客
        /// </summary>
        /// <param name="searchList"></param>
        /// <param name="orderBy"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public override IList<blog> GetDataList(string searchList = "", string orderBy = "", string viewId = "", string searchValue = "")
        {
            return base.GetDataList(searchList, orderBy, viewId, searchValue);
        }

        /// <summary>
        /// 分页获取博客
        /// </summary>
        /// <param name="searchList"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public override DataModel<blog> GetViewData(string searchList, string orderBy, int pageSize, int pageIndex, string viewId = "", string searchValue = "")
        {
            return base.GetViewData(searchList, orderBy, pageSize, pageIndex, viewId, searchValue);
        }

        /// <summary>
        /// 获取博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public override blog GetData(string id)
        {
            return MemoryCacheUtil.GetOrAddCacheItem(id, () => base.GetData(id), DateTime.Now.AddHours(2));
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="blogId"></param>
        [HttpGet]
        public bool Upvote(string id)
        {
            return new BlogService().Upvote(id);
        }

        [HttpGet]
        public void SyncToWeChat(string id)
        {
            new SyncBlog2WeChat().Execute(id);
        }

        /// <summary>
        /// 获取创作记录日历
        /// </summary>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public IEnumerable<BlogActivityModel> GetActivity()
        {
            return new BlogService().GetActivity();
        }

        /// <summary>
        /// 导出Markdown
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ExportMarkdown(string id)
        {
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            var result = new BlogService().ExportMarkdown(id);
            return File(result.bytes, result.ContentType, result.fileName);
        }

        /// <summary>
        /// 获取主页用户
        /// </summary>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public user_info GetIndexUser()
        {
            return new BlogService().GetIndexUser();
        }
    }
}
