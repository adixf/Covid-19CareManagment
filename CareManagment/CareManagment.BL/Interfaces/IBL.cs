using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.BL.Interfaces
{
    public interface IBL
    {
        void AddDistribution(Distribution distribution);
        void AddPerson(Person person);
        void AddPackage(Package package);
        void UpdatePerson(Person person);
        void UpdateDistribution(Distribution distribution);
        List<Person> GetAllPersons(Func<Person, bool> predicate = null);
        List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null);
        List<User> GetAllUsers(Func<User, bool> predicate = null);
        JsonAddress GetAddressDetails(Address address);
        bool ValidUser(string userName, string password);
    }
}
