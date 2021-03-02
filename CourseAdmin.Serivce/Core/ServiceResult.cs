using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAdmin.Serivce.Core
{
    public abstract class ServiceResult
    {
        public ServiceResult()
        {
            this.success = true;
        }
        public bool success { get; set; }
        public string message { get; set; }
        public dynamic Data { get; set; }

    }
}
