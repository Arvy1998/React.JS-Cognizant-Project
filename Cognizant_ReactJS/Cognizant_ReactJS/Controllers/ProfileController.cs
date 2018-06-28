using Microsoft.AspNetCore.Mvc;
using Cognizant.Models;
using System.Collections.Generic;
using System.Linq; // dazniausiai naudoti Linq, nes jis geresnis ir sutaupoma laiko/maziau klaidu

namespace Cognizant.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        public List<Profile> Get()
        {
            return ProfileDatabase.Profiles;
        }

        [HttpGet("{id}")]
        public Profile Get(int id)
        {
            return ProfileDatabase.Profiles.Single(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var victim = ProfileDatabase.Profiles.Single(x => x.Id == id);
            return ProfileDatabase.Profiles.Remove(victim); // ieskome butent tokio id, kurio reikia (jis vienintelis ->Single) // trinimas <- delete
        }

        /*[HttpPut("{id}/{name}/{age}")]
        public bool Add(int id, string name, int age)
        {
            // victim = ProfileDatabase.Profiles.Single(x => x.Id == id);
            return ProfileDatabase.Add(id, name, age);
        }*/

        //ADD metodas POST'ui

        [HttpPost]
        public bool Post([FromBody] Profile profile) // frombody reikalingas tam, kad nebutu vien 0 ir NULL
        {
            ProfileDatabase.Profiles.Add(profile);
            return true;
        }

        /* public Profile Get(int id)
        {
            return _profiles.Where(x => x.Id == id); // ieskome butent tokio id, kurio reikia (ju gali but keli ->Where)
            return _profiles.Where(x => x.Id == id).Select(x => new {Name = "xx", Cost = 3000 //... ect.// }); // ieskome butent tokio id, kurio reikia (ju gali but keli ->Where; Select -> mes ju ieskome)
            Find veikia kitaip negu single. Find'ui reikia issiusti visa profili:
            return _profiles.Find(x => x.Id == id);
        } */

        /* bool GetProfile(Profile x, int id)
        {
            return x.Id == id;
        } */
    }
}