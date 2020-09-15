using CareManagment.DAL.Interfaces;
using CareManagment.DP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DAL
{
    public class Repository : IRepository
    {
       
        public JsonAddress GetAddressDetails(Address address)
        {
            var addressDetails = address.Street + " " + address.BuildingNumber + " " + address.City;
            var client = new RestSharp.RestClient("https://eu1.locationiq.com/");
            var request = new RestSharp.RestRequest("v1/search.php",RestSharp.Method.GET);
            request.AddParameter("key", "c24325218ea6eb");
            request.AddParameter("accept-language", "he");
            request.AddParameter("q", addressDetails);
            request.AddParameter("format", "json");
            var res = client.Execute(request);
            if(res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = JsonConvert.DeserializeObject<object>(res.Content);
                var parsedJson = JArray.Parse(content.ToString());
                var Jaddress = new JsonAddress();
                Jaddress.Latitude = parsedJson[0]["lat"].ToString();
                Jaddress.Longitude = parsedJson[0]["lon"].ToString();
                Jaddress.DisplayName = parsedJson[0]["display_name"].ToString();
                return Jaddress;
            }
            return null;
        }
    

    public void AddPerson(Person person)
        {
            using (var ctx = new CareManagmentDb())
            {
                ctx.Persons.Add(person);
                ctx.SaveChanges();
            }

        }
        public void AddDistribution(Distribution distribution)
        {
            using (var ctx = new CareManagmentDb())
            {
                ctx.Distributions.Add(distribution);
                ctx.SaveChanges();
            }
        }
        public void UpdatePerson(Person person)
        {
            using (var context = new CareManagmentDb())
            {
                var old = context.Persons.Find(person.PersonId);
                old.FirstName = person.FirstName;
                old.LastName = person.LastName;
                old.PhoneNumber = person.PhoneNumber;
                old.Address = person.Address;
                old.MailAddress = person.MailAddress;
                context.SaveChanges();
            }
        }
        public List<Person> GetAllPersons(Func<Person, bool> predicate = null)
        {
            List<Person> result = new List<Person>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                    result = context.Persons.Include(p => p.Address).ToList();
                else
                {
                    result = context.Persons.Include(p => p.Address).OfType<Person>().Where(predicate).ToList();
                }
            }
            return result;
        }
        public List<Distribution> GetAllDistribution(Func<Distribution, bool> predicate = null)
        {
            List<Distribution> result = new List<Distribution>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                    result = context.Distributions.Include(s => s.Admin).Include(s => s.Volunteer).ToList();
                else
                {
                    result = context.Distributions.Include(s=>s.Admin).Include(s=>s.Volunteer).OfType<Distribution>().Where(predicate).ToList();
                }
            }
            return result;
        }
        public List<User> GetAllUsers(Func<User, bool> predicate = null)
        {
            List<User> result = new List<User>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                {
                    result = (from element in context.Persons.OfType<User>()
                              select element).ToList();
                }
                else
                {
                   result = context.Persons.OfType<User>().Where(predicate).ToList();                   
                }
                
            }
            return result;
           
        }

       public List<Package> GetAllPackages(Func<Package, bool> predicate = null)
        {
            List<Package> result = new List<Package>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                {
                    result = (from element in context.Packages.Include(s => s.Recipient).Include(s => s.Distribution).OfType<Package>()
                              select element).ToList();
                }
                else
                {
                    result = context.Packages.Include(s=>s.Recipient).Include(s => s.Distribution).Where(predicate).ToList();
                }

            }
            return result;
        }

        public void AddPackage(Package package)
        {
            using (var ctx = new CareManagmentDb())
            {
                ctx.Packages.Add(package);
                ctx.SaveChanges();
            }
        }

        public void UpdateDistribution(Distribution distribution)
        {
            using (var context = new CareManagmentDb())
            {
                var old = context.Distributions.Find(distribution.Id);
                old.Admin = distribution.Admin;
                old.Volunteer = distribution.Volunteer;
                old.IsDelivered = distribution.IsDelivered;
                old.Packages = distribution.Packages;
                old.Date = distribution.Date;
                context.SaveChanges();
            }
        }

<<<<<<< HEAD
        public void DeletePerson(Person p)
        {
            var context = new CareManagmentDb();
            context.Entry(p).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeletePackage(Package package)
        {
            throw new NotImplementedException();
=======
        public List<Recipient> GetAllRecipient(Func<Recipient, bool> predicate = null)
        {
            List<Recipient> result = new List<Recipient>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                {
                    result = (from element in context.Persons.OfType<Recipient>()
                              select element).ToList();
                }
                else
                {
                    result = context.Persons.OfType<Recipient>().Where(predicate).ToList();
                }
                sol
            }
            return result;
>>>>>>> 214fb47499082982f893f8909674caf843874854
        }

        public List<Recipient> GetAllRecipient(Func<Recipient, bool> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}


