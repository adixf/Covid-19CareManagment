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
            var request = new RestSharp.RestRequest("v1/search.php", RestSharp.Method.GET);
            request.AddParameter("key", "c24325218ea6eb");
            request.AddParameter("accept-language", "he");
            request.AddParameter("q", addressDetails);
            request.AddParameter("format", "json");
            var res = client.Execute(request);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
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


        public void AddVolunteer(Volunteer volunteer)
        {
            using (var ctx = new CareManagmentDb())
            {
                ctx.Volunteers.Add(volunteer);
                ctx.SaveChanges();
            }
        }
        public void AddAdmin(Admin admin)
        {
            using (var ctx = new CareManagmentDb())
            {
                ctx.Admins.Add(admin);
                ctx.SaveChanges();
            }
        }
        public void AddRecipient(Recipient recipient)
        {
            using (var ctx = new CareManagmentDb())
            {
                ctx.Recipients.Add(recipient);
                ctx.SaveChanges();
            }
        }

        public void AddDistribution(Distribution distribution)
        {
            using (var ctx = new CareManagmentDb())
            {
                distribution.Admin = null;
                distribution.Volunteer = null;
                foreach (Package p in distribution.Packages)
                    p.Recipient = null;
                ctx.Distributions.Add(distribution);
                ctx.SaveChanges();
            }
        }
        //public void UpdateUser(Volunteer person)
        //{
        //    using (var context = new CareManagmentDb())
        //    {
        //        var old = context.Users.Find(person.UserId);
        //        old.FirstName = person.FirstName;
        //        old.LastName = person.LastName;
        //        old.PhoneNumber = person.PhoneNumber;
        //        old.Address = person.Address;
        //        old.MailAddress = person.MailAddress;
        //        context.SaveChanges();
        //    }
        //}

        public List<Volunteer> GetAllVolunteers(Func<Volunteer, bool> predicate = null)
        {
            List<Volunteer> result = new List<Volunteer>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                    result = context.Volunteers.ToList();
                else
                {
                    result = context.Volunteers.Where(predicate).ToList();
                }
            }
            return result;
        }

        public List<Admin> GetAllAdmins(Func<Admin, bool> predicate = null)
        {
            List<Admin> result = new List<Admin>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                    result = context.Admins.ToList();
                else
                {
                    result = context.Admins.Where(predicate).ToList();
                }
            }
            return result;
        }

        public List<Recipient> GetAllRecipients(Func<Recipient, bool> predicate = null)
        {
            List<Recipient> result = new List<Recipient>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                    result = context.Recipients.ToList();
                else
                {
                    result = context.Recipients.Where(predicate).ToList();
                }
            }
            return result;
        }


        public List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null)
        {
            List<Distribution> result = new List<Distribution>();
            using (var context = new CareManagmentDb())
            {
                if (predicate == null)
                    result = context.Distributions.Include(d => d.Admin).Include(d => d.Volunteer).ToList();
                else
                {
                    result = context.Distributions.Include(d => d.Admin).Include(d => d.Volunteer).Where(predicate).ToList();
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
                    result = context.Packages.Include(s => s.Recipient).Include(s => s.Distribution).Where(predicate).ToList();
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
                var old = context.Distributions.Find(distribution.DistributionId);
                old.Admin = distribution.Admin;
                old.Volunteer = distribution.Volunteer;
                old.IsDelivered = distribution.IsDelivered;
                old.Packages = distribution.Packages;
                old.Date = distribution.Date;
                context.SaveChanges();
            }
        }


        //public void DeletePerson(Person p)
        //{
        //    var context = new CareManagmentDb();
        //    context.Entry(p).State = EntityState.Deleted;
        //    context.SaveChanges();
        //}

        public void DeletePackage(Package package)
        {
            throw new NotImplementedException();
        }

    


    }
}


