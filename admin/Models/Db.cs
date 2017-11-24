using admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace admin.Models
{
    public class Db:DbContext
    {
        public Db(): base("name=database") { }

        public DbSet<UserLogIn> UserLogIns { get; set; }

        public DbSet<UserLogIn2> UserLogIn2s { get; set; }
     }
}