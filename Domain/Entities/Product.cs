﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Product
    {
	    [HiddenInput(DisplayValue= false)]
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Decimal Price{ get; set; }

        public string Category { get; set; }

    }
}