using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Services.Interface;

namespace WebApi.Services
{
    /// <summary>
    /// 步兵
    /// </summary>
    public class Infantry: IInfantry
    {
        public string Guard()
        {
            return "增加自身格檔能力";
        }
    }
}