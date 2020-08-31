using CareManagment.DAL.Interfaces;
using CareManagment.DP;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        public List<Distribution> GetDistribution(Func<Distribution, bool> predicate = null)
        {
            var result = new List<Distribution>();
            using (var ctx = new CareManagmentDbContext())
            {
                if (predicate == null)
                    result = ctx.Distributions.ToList();
                else
                {
                    result = (from element in ctx.Distributions
                              where predicate(element)
                              select element).ToList();
                }

            }
            return result;
        }
        public List<Volunteer> GetVolunteers(Func<Volunteer, bool> predicate = null)
        {
            var result = new List<Volunteer>();
            using (var ctx = new CareManagmentDbContext())
            {
                if (predicate == null)
                    result = ctx.Volunteers.ToList();
                else
                {
                    result = (from element in ctx.Volunteers
                              where predicate(element)
                              select element).ToList();
                }

            }
            return result;
        }
        public List<Recipient> GetRecipients(Func<Recipient, bool> predicate = null)
        {
            var result = new List<Recipient>();
            using (var ctx = new CareManagmentDbContext())
            {
                if (predicate == null)
                    result = ctx.Recipients.ToList();
                else
                {
                    result = (from element in ctx.Recipients
                              where predicate(element)
                              select element).ToList();
                }

            }
            return result;
        }
        public List<Admin> GetAdmins(Func<Admin, bool> predicate = null)
        {
            var result = new List<Admin>();
            using (var ctx = new CareManagmentDbContext())
            {
                if (predicate == null)
                    result = ctx.Admins.ToList();
                else
                {
                    result = (from element in ctx.Admins
                              where predicate(element)
                              select element).ToList();
                }

            }
            return result;
        }
        public void AddVolunteer(Volunteer volunteer)
        {
            using (var ctx = new CareManagmentDbContext())
            {
                ctx.Volunteers.Add(volunteer);
                ctx.SaveChanges();
            }
        }
        public void AddDistribution(Distribution distribution)
        {
            using (var ctx = new CareManagmentDbContext())
            {
                ctx.Distributions.Add(distribution);
                ctx.SaveChanges();
            }
        }
        public void AddRecipient(Recipient recipient)
        {
            using (var ctx = new CareManagmentDbContext())
            {
                ctx.Recipients.Add(recipient);
                ctx.SaveChanges();
            }
        }
        public void AddAdmin(Admin admin)
        {
            using (var ctx = new CareManagmentDbContext())
            {
                ctx.Admins.Add(admin);
                ctx.SaveChanges();
            }
        }
        public void UpdateUser(User user)
        {
            using (var ctx = new CareManagmentDbContext())
            {
                User oldElement;
                if (user is Volunteer)
                    oldElement = ctx.Volunteers.Find(user.PersonId);
                else
                    oldElement = ctx.Admins.Find(user.PersonId);

                oldElement.FisrtName = user.FisrtName;
                oldElement.LastName = user.LastName;
                oldElement.PhoneNumber = user.PhoneNumber;
                oldElement.MailAddress = user.MailAddress;
                oldElement.Password = user.Password;
                oldElement.Address = user.Address;
                ctx.SaveChanges();

            }
        }
        public void UpdateRecipient(Recipient recipient)
        {

            using (var ctx = new CareManagmentDbContext())
            {
                var oldElement = ctx.Recipients.Find(recipient.PersonId);
                oldElement.FisrtName = recipient.FisrtName;
                oldElement.LastName = recipient.LastName;
                oldElement.PhoneNumber = recipient.PhoneNumber;
                oldElement.MailAddress = recipient.MailAddress;
                oldElement.Address = recipient.Address;
                ctx.SaveChanges();
            }
        }
       
    }
}


