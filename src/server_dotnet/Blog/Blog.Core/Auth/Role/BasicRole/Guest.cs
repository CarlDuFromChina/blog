﻿using Blog.Core.Auth.Privilege;
using Blog.Core.Data;
using Blog.Core.Module.SysEntity;
using Blog.Core.Module.SysMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Auth.Role.BasicRole
{
    /// <summary>
    /// 访客
    /// </summary>
    public class Guest : BasicRole
    {
        public override Role Role => Role.Guest;

        public override IDictionary<string, IEnumerable<sys_role_privilege>> GetMissingPrivilege()
        {
            var dic = new Dictionary<string, IEnumerable<sys_role_privilege>>();

            dic.Add(RoleType.Entity.ToString(), GetMissingEntityPrivileges().Select(item => GenerateRolePrivilege(item, this.GetSysRole(), (int)OperationType.Read)));
            dic.Add(RoleType.Menu.ToString(), GetMissingMenuPrivileges().Select(item => GenerateRolePrivilege(item, this.GetSysRole(), 0)));

            return dic;
        }
    }
}
