using CareManagment.DAL.Interfaces;
using CareManagment.DP;
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
            WebRequest webRequest = new WebRequest();
            Object o = new object();
            var addressRequests = address.Street + " " + address.BuildingNumber + " " + address.City;
            var url = @"https://eu1.locationiq.com/v1/search.php?key=e60fc76d273537&q=" + addressRequests + "&format=json";
            var requests = webRequest.PostCallAPI(url, o);
            var parseJson = JArray.Parse(requests.ToString());
            var Jaddress = new JsonAddress();
            Jaddress.Latitude = parseJson[0]["lat"].ToString();
            Jaddress.Longitude = parseJson[0]["lon"].ToString();
            return Jaddress;
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
                    result = context.Persons.ToList();
                else
                {
                    result = context.Persons.OfType<Person>().Where(predicate).ToList();
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
                    result = context.Distributions.ToList();
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
                    result = (from element in context.Packages.OfType<Package>()
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
    }
}


