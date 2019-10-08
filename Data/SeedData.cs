using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProvinceCity.Models;

public static class SeedData {
    // this is an extension method to the ModelBuilder class
    
    public static void Seed(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<City>().HasData(
            GetCities()
        );
        modelBuilder.Entity<Province>().HasData(
            GetProvinces()
        ); 

        modelBuilder.Entity<City>()
            .HasOne<Province>(p => p.Province)
            .WithMany(c => c.Cities)
            .HasForeignKey(k => k.CityID);

    }
    public static List<Province> GetProvinces() {
        List<Province> provinces = new List<Province>() {
            new Province() {    // 1
                ProvinceCode="BC",
                ProvinceName="British Columbia",
            },
            new Province() {    //2
                ProvinceCode="AB",
                ProvinceName="Alberta",
            },
            new Province() {    // 3
                ProvinceCode="SA",
                ProvinceName="Saskachewan",
            },
            new Province() {    // 4
                ProvinceCode="ON",
                ProvinceName="Ontario",
            },
            new Province() {    // 5
                ProvinceCode="NV",
                ProvinceName="Nova Scotia",
            },            
        };

        return provinces;
    }

    public static List<City> GetCities() {
        List<City> cities = new List<City>() {
            new City { // BC
                CityID = 1,
                CityName = "Vancouver",
                Population = 675218,
                ProvinceCode="BC",
            },
            new City {
                CityID = 2,
                CityName = "Burnaby",
                Population = 249197,
                ProvinceCode="BC"
            },
            new City {
                CityID = 3,
                CityName = "Surrey",
                Population = 518467,
                ProvinceCode="BC"
            },
            new City {
                CityID = 4,
                CityName = "Edmonton",
                Population = 981280,
                ProvinceCode="AB"
            },
            new City {
                CityID = 5,
                CityName = "Calgary",
                Population = 1336000,
                ProvinceCode="AB"
            },
            new City {
                CityID = 6,
                CityName = "Red Deer",
                Population = 100418,
                ProvinceCode="AB"
            },
            new City {
                CityID = 7,
                CityName = "Toronto",
                Population = 2731571,
                ProvinceCode="ON"
            },
            new City {
                CityID = 8,
                CityName = "Ottawa",
                Population = 964743,
                ProvinceCode="ON"
            },
            new City {
                CityID = 9,
                CityName = "Mississauga",
                Population = 721599,
                ProvinceCode="ON"
            },
            new City {
                CityID = 10,
                CityName = "Halifax",
                Population = 403131,
                ProvinceCode="NV"
            },
            new City {
                CityID = 11,
                CityName = "Cape Breton",
                Population = 94285,
                ProvinceCode="NV"
            },
            new City {
                CityID = 12,
                CityName = "Truro",
                Population = 12261,
                ProvinceCode="NV"
            },
        };

        return cities;
    }
}
