using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace admin.Models
{
    [Table("user_log")]
    public class UserLog
    {
        public long Id { get; set; }
        public string Log_state { get; set; }
        public string Log_name { get; set; }
        public string Log_time { get; set; }
        //public long User_id { get; set; }
    }
}