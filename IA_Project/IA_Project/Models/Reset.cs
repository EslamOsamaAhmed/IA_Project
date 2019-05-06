using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA_Project.Models
{
    public class Reset
    {
        private string rescode;

        public void setCode(string code) {
            rescode = code;
        }

        public string getCode() {
            return rescode;
        }
    }
}