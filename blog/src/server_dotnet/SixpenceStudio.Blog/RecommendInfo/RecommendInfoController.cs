﻿using SixpenceStudio.Core;
using SixpenceStudio.Core.Entity;
using SixpenceStudio.Core.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SixpenceStudio.Blog.RecommendInfo
{
    public class RecommendInfoController : EntityBaseController<recommend_info, RecommendInfoService>
    {
        [HttpGet, AllowAnonymous]
        public override recommend_info GetData(string id)
        {
            return base.GetData(id);
        }

        [HttpGet, AllowAnonymous]
        public IList<recommend_info> GetRecommendList(string type = "url")
        {
            return new RecommendInfoService().GetRecommendList(type);
        }

        /// <summary>
        /// 记录阅读次数
        /// </summary>
        /// <param name="blogId"></param>
        [HttpGet, AllowAnonymous]
        public void RecordReadingTimes(string id)
        {
            new RecommendInfoService().RecordReadingTimes(id);
        }
    }
}