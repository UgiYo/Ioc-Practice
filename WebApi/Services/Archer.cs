using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Services.Interface;

namespace WebApi.Services
{
    public class Archer: IArcher
    {
        public string MultiShot()
        {
            return "多重射擊";
        }
    }
}