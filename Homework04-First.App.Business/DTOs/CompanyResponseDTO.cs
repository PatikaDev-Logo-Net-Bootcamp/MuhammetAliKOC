using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework04_First.App.Business.DTOs
{
    public  class CompanyResponseDTO
    {
        public CompanyResponseDTO()
        {
            Success = false;
        }
        public object Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
