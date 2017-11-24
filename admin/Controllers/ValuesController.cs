using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using admin.Models;

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

        [HttpPost]
        public List<UserLogIn> UserLogin(UserLogIn model)
        {
            using (var db= new Db())
            {
                var queryUserPsw = db.Database.SqlQuery<UserLogIn>($"select * from test where Id = {model.Id}").ToList();
               
                return queryUserPsw;
              //  var id =  db.Database.SqlQuery<UserLogIn>($"select * from test where name = {model.Name}");
                
            }
        }

        [HttpPost]
        public List<UserLogIn2> UserLogin2(UserLogIn2 model)
        {

            using (var db = new Db())
            {

                // List<string> temList = new List<string>(temArr);
                return db.Database.SqlQuery<UserLogIn2>($"select * from user where login_name = '{model.Login_name}' and password = '{model.Password}'").ToList();
                //return QueryLoginState;
                
            }
        }

        // GET api/values/5
        [HttpGet]
        public List<UserLogIn> GetInfo()
        {
            using(var db=new Db())
            {
                return db.Database.SqlQuery<UserLogIn>("select * from test").ToList();
            }
            
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
