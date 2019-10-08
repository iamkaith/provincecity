using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProvinceCity.Models {
    public class City {
        
        [Key]
        public int CityID { get; set; }
        [Required]
        public string CityName { get; set; }

        [DisplayFormat(DataFormatString="")]
        public int Population { get; set; }

        [Required]
        public string ProvinceCode { get; set; }
      
        public virtual Province Province { get; set; }

        public override string ToString() {
            return this.CityName + ", ";
        }
    }
}