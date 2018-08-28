using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPriceHonester.Entity.Table
{
    public class CarModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Avatar { get; set; }

        [Required]
        public string Year { get; set; }

        public CarDetailModel Detail { get; set; }
    }
}
