﻿using Blog.Business.Post;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using Sixpence.Common;
using Sixpence.Common.Current;
using Sixpence.ORM.EntityManager;
using Sixpence.ORM.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Test
{
    [TestFixture]
    public class BlogTagsTest
    {
        [SetUp]
        public void SetUp()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddServiceContainer(options =>
            {
                options.Assembly.Add("Sixpence.ORM.Test");
            });
            CallContext<CurrentUserModel>.SetData(CallContextType.User, new CurrentUserModel() { Id = "1", Code = "1", Name = "test" });
            SixpenceORMBuilderExtension.UseORM(null);
        }

        [Test]
        public void CheckTagsConvert()
        {
            var manager = EntityManagerFactory.GetManager();
            var post = manager.QueryFirst<post>("select * from post where tags is not null", null);
            var tags = JsonConvert.DeserializeObject<List<string>>(post.tags.ToString());
            Assert.IsTrue(!tags.IsEmpty());
        }
    }
}
