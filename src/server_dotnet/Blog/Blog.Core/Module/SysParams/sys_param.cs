﻿using Sixpence.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Core.Module.SysParams
{
    [Entity("sys_param", "选项", true)]
    public partial class sys_param : BaseEntity
    {
        /// <summary>
        /// 实体id
        /// </summary>
        [DataMember]
        [PrimaryColumn]
        public string id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        [Column]
        public string name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember]
        [Column]
        public string code { get; set; }

        /// <summary>
        /// 选项集
        /// </summary>
        [DataMember]
        [Column]
        public string sys_paramGroupId { get; set; }

        /// <summary>
        /// 选项集名
        /// </summary>
        [DataMember]
        [Column]
        public string sys_paramgroupid_name { get; set; }
    }
}