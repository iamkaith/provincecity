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
        public int Population { get; set; }

        
        [Required]
        public string ProvinceCode { get; set; }

        [ForeignKey("ProvinceCode")]        
        public virtual Province Province { get; set; }
    }
}