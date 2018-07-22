using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Services.Interface;

namespace WebApi.Services
{
    public class Cavalry: ICavalry
    {
        public string Charge()
        {
            return "騎兵衝鋒";
        }
    }
}