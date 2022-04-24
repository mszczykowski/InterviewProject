using InterviewProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Persistence.Context
{
    internal class ApplicationDbContextSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedCountries(modelBuilder);
            SeedBorders(modelBuilder);
        }

        private static void SeedCountries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        Name = "Canada",
                        Code = "CAN"
                    },
                    new Country
                    {
                        Name = "United States",
                        Code = "USA"
                    },
                    new Country
                    {
                        Name = "Mexico",
                        Code = "MEX"
                    },
                    new Country
                    {
                        Name = "Belize",
                        Code = "BLZ"
                    },
                    new Country
                    {
                        Name = "Guatemala",
                        Code = "GTM"
                    },
                    new Country
                    {
                        Name = "El Salvador",
                        Code = "SLV"
                    },
                    new Country
                    {
                        Name = "Honduras",
                        Code = "HND"
                    },
                    new Country
                    {
                        Name = "Nicaragua",
                        Code = "NIC"
                    },
                    new Country
                    {
                        Name = "Costa Rica",
                        Code = "CRI"
                    },
                    new Country
                    {
                        Name = "Panama",
                        Code = "PAN"
                    }
                );
        }

        private static void SeedBorders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Border>().HasData(
                    new Border
                    {
                        CountryId = "CAN",
                        NeighbourId = "USA"
                    },
                    new Border
                    {
                        CountryId = "USA",
                        NeighbourId = "CAN"
                    },
                    new Border
                    {
                        CountryId = "USA",
                        NeighbourId = "MEX"
                    },
                    new Border
                    {
                        CountryId = "MEX",
                        NeighbourId = "BLZ"
                    }, 
                    new Border
                    {
                        CountryId = "MEX",
                        NeighbourId = "GTM"
                    },
                    new Border
                    {
                        CountryId = "MEX",
                        NeighbourId = "USA"
                    },
                    new Border
                    {
                        CountryId = "BLZ",
                        NeighbourId = "GTM"
                    },
                    new Border
                    {
                        CountryId = "BLZ",
                        NeighbourId = "MEX"
                    },
                    new Border
                    {
                        CountryId = "GTM",
                        NeighbourId = "MEX"
                    },
                    new Border
                    {
                        CountryId = "GTM",
                        NeighbourId = "BLZ"
                    },
                    new Border
                    {
                        CountryId = "GTM",
                        NeighbourId = "SLV"
                    },
                    new Border
                    {
                        CountryId = "GTM",
                        NeighbourId = "HND"
                    },
                    new Border
                    {
                        CountryId = "SLV",
                        NeighbourId = "GTM"
                    },
                    new Border
                    {
                        CountryId = "SLV",
                        NeighbourId = "HND"
                    },
                    new Border
                    {
                        CountryId = "HND",
                        NeighbourId = "NIC"
                    },
                    new Border
                    {
                        CountryId = "HND",
                        NeighbourId = "SLV"
                    },
                    new Border
                    {
                        CountryId = "HND",
                        NeighbourId = "GTM"
                    },
                    new Border
                    {
                        CountryId = "NIC",
                        NeighbourId = "SLV"
                    },
                    new Border
                    {
                        CountryId = "NIC",
                        NeighbourId = "CRI"
                    },
                    new Border
                    {
                        CountryId = "CRI",
                        NeighbourId = "NIC"
                    },
                    new Border
                    {
                        CountryId = "CRI",
                        NeighbourId = "PAN"
                    },
                    new Border
                    {
                        CountryId = "PAN",
                        NeighbourId = "CRI"
                    }
                );     
        }
    }
}
