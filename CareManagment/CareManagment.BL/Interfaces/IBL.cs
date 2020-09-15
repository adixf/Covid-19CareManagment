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
        void AddDistributions(List<Distribution> distributions);
        void AddPerson(Person person);
        void AddPackage(Package package);
        void UpdatePerson(Person person);
        void UpdateDistribution(Distribution distribution);
        void DeletePerson(Person person);
        List<Person> GetAllPersons(Func<Person, bool> predicate = null);
        List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null);
        List<User> GetAllUsers(Func<User, bool> predicate = null);
        List<User> GetAllVolunteers();
        List<Recipient> GetAllRecipients(Func<Recipient, bool> predicate = null);
        JsonAddress GetAddressDetails(Address address);

        List<Package>[] DividePackages(List<Package> Packages, int K);
        User FindClosestVolunteer(Address address);

        
    }
}
