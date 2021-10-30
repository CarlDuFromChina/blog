﻿using Blog.Core.Auth.Privilege;
using Sixpence.EntityFramework.Entity;
using Blog.Core.Module.Role;
using Blog.Core.Module.SysEntity;
using Blog.Core.Module.SysMenu;
using Sixpence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Auth.Role.BasicRole
{
    [ServiceRegister]
    public interface IRole
    {
        /// <summary>
        /// 获取唯一键
        /// </summary>
        string GetRoleKey { get; }

        /// <summary>
        /// 角色名
        /// </summary>
        Role Role { get; }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        sys_role GetSysRole();

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        IEnumerable<sys_role_privilege> GetRolePrivilege();

        /// <summary>
        /// 清除缓存
        /// </summary>
        void ClearCache();

        /// <summary>
        /// 获取初始化权限
        /// </summary>
        /// <returns></returns>
        IDictionary<string, IEnumerable<sys_role_privilege>> GetMissingPrivilege();
    }

    public enum RoleType
    {
        Entity,
        Menu
    }
}