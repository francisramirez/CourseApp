﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAdmin.Serivce.Results
{
    public class CourseResultModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
