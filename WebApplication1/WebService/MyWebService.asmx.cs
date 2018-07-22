using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace MyWebApplication.WebService
{
    /// <summary>
    ///MyWebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    //[System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {
        [WebMethod(enableSession: true)]
        public void HelloWorld()
        {
            //設定輸出格式為json格式
            this.Context.Response.ContentType = "application/json";
 
            //post
            String data = this.Context.Request.Form["ret"];
            //get
            String data1 = this.Context.Request.QueryString["val"];
 
            Dictionary<String, Object> dic = new Dictionary<string, object>();
            dic["data"] = "Post取得的值為:"+data;
            dic["data1"] = "Get取得的值為:"+data1;
 
            //新版的可以用
            //System.Runtime.Serialization.Json.DataContractJsonSerializer
 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
       
            //輸出json格式
            this.Context.Response.Write(serializer.Serialize(dic));
 
 
        }



        //以下Session的使用
        [WebMethod(enableSession: true)]
        public string removeSession()
        {

            Session.Remove("test");
            return "移除Session : 測試Session裡的值為: " + Session["test"];
        }
        [WebMethod(enableSession: true)]
        public string showSession()
        {
            String data = (String)Session["test"];
            if (data == null)
                data = "Session內無值";
            return "Session['test']值為:" + data;
        }
        [WebMethod(enableSession: true)]
        public string setSession()
        {

            Session["test"] = "helloworld";
            return "設定Session成功!";
        }
    }
}
