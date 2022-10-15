using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOWELS.Models;

namespace TOWELS.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Towels.Any())
            {
                var list = new List<Towel>
                {
                    new Towel{ Name="Towel Blue", Color="blue", size="medium", tissue="cotton", review=5},
                    new Towel{ Name="Towel Orange", Color="organge", size="small", tissue="cotton",review=4},
                    new Towel{ Name="Towel red", Color="red", size="medium", tissue="wool",review=5},
                    new Towel{ Name="Towel green", Color="green", size="big", tissue="cotton",review=3},
                    new Towel{ Name="Towel black", Color="black", size="medium", tissue="cotton",review=5},
                    new Towel{ Name="Towel pink", Color="pink", size="small", tissue="wool",review=5},
                    new Towel{ Name="Towel brown", Color="brown", size="medium", tissue="cotton",review=4},
                    new Towel{ Name="Towel gold", Color="gold", size="small", tissue="wool",review=4},
                    new Towel{ Name="Towel yellow", Color="yellow", size="medium", tissue="cotton",review=5},
                    new Towel{ Name="Towel silver", Color="silver", size="big", tissue="wool",review=3}
                };

                context.Towels.AddRange(list);
                context.SaveChanges();
            }
        }
    }
}
