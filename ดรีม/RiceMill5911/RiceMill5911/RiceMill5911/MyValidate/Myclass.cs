using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RiceMill5911.Models
{
    public class Myclass
    {
        [Required(ErrorMessage = "กรุณาป้อนวันที่")]
        public DateTime MyDate { get; set; }
        public DateTime MyDate1 { get; set; }
        public DateTime MyDate2{ get; set; }
        public HttpPostedFileBase MyPic { get; set; }
    }
}