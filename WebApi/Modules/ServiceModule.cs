using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Services;
using WebApi.Services.Interface;

namespace WebApi.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //當遇到IArcher介面時，以Archer類別注入
            builder.RegisterType<Archer>().As<IArcher>();
            //依此類推
            builder.RegisterType<Infantry>().As<IInfantry>();
            builder.RegisterType<Cavalry>().As<ICavalry>();
        }
    }
}