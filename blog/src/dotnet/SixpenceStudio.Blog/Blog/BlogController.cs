﻿using SixpenceStudio.BaseSite;
using SixpenceStudio.Platform.Entity;
using SixpenceStudio.Platform.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SixpenceStudio.Blog.Blog
{
    [RequestAuthorize]
    public class BlogController : EntityController<blog, BlogService>
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
        /// 删除博客封面
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        public void DeleteSurface([FromBody]string id)
        {
            new BlogService().DeleteSurface(id);
        }

        /// <summary>
        /// 获取所有博客
        /// </summary>
        /// <param name="searchList"></param>
        /// <param name="orderBy"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public override IList<blog> GetDataList(string searchList = "", string orderBy = "", string viewId = "")
        {
            return base.GetDataList(searchList, orderBy, viewId);
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
        public override DataModel<blog> GetDataList(string searchList, string orderBy, int pageSize, int pageIndex, string viewId = "")
        {
            return base.GetDataList(searchList, orderBy, pageSize, pageIndex, viewId);
        }

        /// <summary>
        /// 获取博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public override blog GetData(string id)
        {
            return base.GetData(id);
        }
    }
}
