using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework01_Form.Models
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Object Data  { get; set; }
    }
}
