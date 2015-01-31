using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerManagement.Models
{
    public class League
    {
        public String name { get; set; }
        public String logoLink { get; set; }
        public League(){}
        public League(String name, String logoLink){
            this.name = name;
            this.logoLink = logoLink;
        }
    }    
}