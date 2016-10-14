using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "please insert the name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please insert a description")]
        public string Description { get; set; }

        [Range(0.01 , Double.MaxValue, ErrorMessage = "please insert the price")]
        public Decimal Price{ get; set; }


        [Required(ErrorMessage = "please insert the category")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

    }
}
