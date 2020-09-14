using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DAL.Interfaces
{
    public interface IRepository
    {
        void AddPerson(Person person);
        void AddDistribution(Distribution distribution);
        void AddPackage(Package package);
        void UpdatePerson(Person person);
        List<Person> GetAllPersons(Func<Person, bool> predicate = null);
        List<Package> GetAllPackages(Func<Package, bool> predicate = null);
        List<User> GetAllUsers(Func<User, bool> predicate = null);
        List<Distribution> GetAllDistribution(Func<Distribution, bool> predicate = null);
        List<Recipient> GetAllRecipient(Func<Recipient, bool> predicate = null);
        void UpdateDistribution(Distribution distribution);

        JsonAddress GetAddressDetails(Address address);
    }
}
