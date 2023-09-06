using MVCModelSending_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCModelSending_0.ViewModels
{
    public class CategoryVM
    {
        public List<Category> Categories { get; set; }
        public List<Employee> Employees { get; set; }
        public Category Category { get; set; }
    }
}