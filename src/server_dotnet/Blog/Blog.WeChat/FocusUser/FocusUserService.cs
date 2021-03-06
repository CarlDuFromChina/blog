using Newtonsoft.Json;
using Sixpence.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Sixpence.Common.Logging;
using Sixpence.ORM.EntityManager;

namespace Blog.WeChat.FocusUser
{
    public class FocusUserService
    {
        IEntityManager manager;
        ILog logger;

        public FocusUserService()
        {
            manager = EntityManagerFactory.GetManager();
            logger = LoggerFactory.GetLogger("wechat");
        }

        /// <summary>
        /// 获取所有关注用户（返回OpenId集合）
        /// </summary>
        /// <returns></returns>
        public FocusUserListModel GetFocusUserList()
        {
            var resp = WeChatApi.GetFocusUserList();
            var openIds = JsonConvert.DeserializeObject<FocusUserListModel>(resp);
            return openIds;
        }

        /// <summary>
        /// 获取关注用户信息
        /// </summary>
        /// <param name="userList">OpenId列表</param>
        /// <returns></returns>
        public FocusUsersModel GetFocusUsers(string userList)
        {
            var resp2 = WeChatApi.BatchGetFocusUser(JsonConvert.SerializeObject(userList));
            var focusUsers = JsonConvert.DeserializeObject<FocusUsersModel>(resp2);
            return focusUsers;
        }
    }
}
