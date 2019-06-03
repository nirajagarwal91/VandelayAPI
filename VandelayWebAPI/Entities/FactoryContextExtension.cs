using System.Collections.Generic;

namespace VandelayWebAPI.Entities
{
    public static class FactoryContextExtension
    {
        //clearing the database after each run. This is just for testing purposes

        public static void SeedDataForFactoryContext(this FactoryContext context)
        {
            context.Factories.RemoveRange(context.Factories);
            context.SaveChanges();

            //initialize seed data

            var factories = new List<Factory>()
            {
                new Factory()
                {
                    FactoryId = 1,
                    FactoryName = "Newark Latex Mfg.",
                    FactoryDescription = "Key East Coast facility for raw latex material to be processed into final products for the medical industry.",
                    //FactoryAddress = new Address()
                    //{
                    //    BuildingName = "31 Stone Creek",
                    //    StreetLine1 = "Syracuse Road",
                    //    StreetLine2 = "",
                    //    City = "Columbus",
                    //    StateProvince = "Ohio",
                    //    ZipPostalCode = "46085",
                    //    Country = "United States"
                    //},
                    Machines = new List<Machine>()
                    {
                        new Machine()
                        {
                            MachineId = 11,
                            MachineName = "Extruder AB-100",
                            MachineDescription = "Extruder with 1,000fpm output capacity"
                        },
                        new Machine()
                        {
                            MachineId = 12,
                            MachineName = "ICKJ 5600",
                            MachineDescription = "Construction Machines"
                        },
                        new Machine()
                        {
                            MachineId = 13,
                            MachineName = "JCB 200",
                            MachineDescription = "JCB 200 rpm drill machine"
                        }
                    }
                },
                new Factory()
                {
                    FactoryId = 2,
                    FactoryName = "Ohio Steel Mfg.",
                    FactoryDescription = "Raw industrial plant.",
                    //FactoryAddress = new Address()
                    //{
                    //    BuildingName = "Sugar Creek Avenue",
                    //    StreetLine1 = "21 Worthington Road",
                    //    StreetLine2 = "Street 4",
                    //    City = "Columbus",
                    //    StateProvince = "Ohio",
                    //    ZipPostalCode = "46085",
                    //    Country = "United States"
                    //},
                    Machines = new List<Machine>()
                    {
                        new Machine()
                        {
                            MachineId = 21,
                            MachineName = "AB-100",
                            MachineDescription = "Test2 M1"
                        },
                        new Machine()
                        {
                            MachineId = 22,
                            MachineName = "IF 5600",
                            MachineDescription = "Test2 M2"
                        },
                        new Machine()
                        {
                            MachineId = 23,
                            MachineName = "CB 200",
                            MachineDescription = "Test2 M3"
                        }
                    }
                }
            };
            context.Factories.AddRange(factories);
            context.SaveChanges();
        }
    }
}
