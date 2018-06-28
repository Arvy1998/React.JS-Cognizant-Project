using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cognizant.Models
{
    public class ProfileDatabase
    {
        public static List<Profile> Profiles = new List<Profile>(
        new[]
        {
            new Profile { Id = 1, Name = "Arvydas", Age = 19 },
            new Profile { Id = 2, Name = "Tomas", Age = 99 }
            }
        );

        /*public static bool Add(int id, string name, int age) {
            Profiles.Add(new Profile { Id = id, Name = name, Age = age });
            return true;
        }*/
    }
}