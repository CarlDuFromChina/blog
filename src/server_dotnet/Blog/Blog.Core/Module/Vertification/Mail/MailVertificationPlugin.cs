﻿using Sixpence.EntityFramework.Entity;
using Blog.Core.Utils;
using Sixpence.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Sixpence.EntityFramework.Broker;

namespace Blog.Core.Module.Vertification.Mail
{
    public class MailVertificationPlugin : IPersistBrokerPlugin
    {
        public void Execute(PersistBrokerPluginContext context)
        {
            var entity = context.Entity;
            switch (context.Action)
            {
                case EntityAction.PreCreate:
                    {
                        var reciver = entity["mail_address"].ToString();
                        var title = entity["name"].ToString();
                        var content = entity["content"].ToString();
                        MailUtil.SendMail(reciver, title, content);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}