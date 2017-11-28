using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using admin.Models;
using admin.Extension;
using System.Web.Http.Results;

namespace admin.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpPost]
        public long AddInfo(UserLogIn model)
        {
            using (var db = new Db())
            {
                var entity = new UserLogIn
                {
                    Name = model.Name
                };  
                db.UserLogIns.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
            
        }

        //登录接口
        [HttpPost]
        public string UserLogin2(UserLogIn2 model)
        {
            using (var db = new Db())
            {
                var userAllRight = db.Database.SqlQuery<UserLogIn2>($"select * from user where login_name = '{model.Login_name}' and password = '{model.Password.Md5String()}'").FirstOrDefault();
                if (userAllRight == null)
                {
                    var loginNameExist = db.Database.SqlQuery<UserLogIn2>($"select * from user where login_name = '{model.Login_name}'").FirstOrDefault();
                    if (loginNameExist != null) {
                        var entity = new UserLog
                        {
                            Log_name = model.Login_name,
                            Log_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            Log_state = "fail"
                        };
                        db.UserLogs.Add(entity);
                        db.SaveChanges();
                    }
                    return "fail";
                }
                else
                {
                    var entity = new UserLog
                    {
                        Log_name = model.Login_name,
                        Log_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Log_state = "success"
                    };
                    db.UserLogs.Add(entity);
                    db.SaveChanges();
                    return "success";
                }          
            }
        }
        //注册接口
        [HttpPost]
        public string UserSignUp (UserLogIn2 model)
        {
            using (var db = new Db())
            {
                var userState = db.Database.SqlQuery<UserLogIn2>($"select * from user where login_name = '{model.Login_name}'").FirstOrDefault();
                if (userState == null)
                {
                    var entity = new UserLogIn2
                    {
                        Login_name = model.Login_name,
                        Password = model.Password.Md5String()
                    };
                    db.UserLogIn2s.Add(entity);
                    db.SaveChanges();
                    return "account add success";
                }
                else
                {
                    return "username exist";
                }
            }
        } 
       /* [HttpPost]
        public JsonResult Login(UserLogIn2 model)
        {
            
            return Json(new {
                    success = "success",

            },JsonRequestBehavior.AllowGet);
        }
        */

        // GET api/values/5
        [HttpGet]
        public List<UserLogIn2> GetInfo()   
        {
            using(var db = new Db())
            {
                var queryAlluser = from UserLogIn2 in db.UserLogIn2s
                                   select UserLogIn2;
                return queryAlluser.ToList();
                //return db.Database.SqlQuery<UserLogIn>("select * from test").ToList();
            }
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
