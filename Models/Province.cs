using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinceCity.Models {
    public class Province {
        
        public Province () {}

        [Key, Required, MaxLength(2)]
        public string ProvinceCode { get; set; }
        [Required]
        public string ProvinceName { get; set; }
        public virtual ICollection<City> Cities { get; set; }

    }
}