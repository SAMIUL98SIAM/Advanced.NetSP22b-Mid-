﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assoc.Models.Database
{
    public class DepartmentCourseModel : DepartmentModel
    {
        public List<CourseModel> Courses { get; set; }

        public DepartmentCourseModel()
        {
            Courses = new List<CourseModel>();
        }
    }
}