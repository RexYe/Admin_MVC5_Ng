using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace admin.Models
{
    [Table("user")]
    public class UserLogIn2
    {
            public long Id { get; set; }
            public string Login_name { get; set; }

            public string Password { get; set; }

    }
}