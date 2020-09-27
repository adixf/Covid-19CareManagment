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
        void AddVolunteer(Volunteer volunteer);
        void AddAdmin(Admin admin);
        void AddRecipient(Recipient recipient);
        void AddPackage(Package package);
        void UpdateDistribution(Distribution distribution);

        List<Volunteer> GetAllVolunteers(Func<Volunteer, bool> predicate = null);
        List<Admin> GetAllAdmins(Func<Admin, bool> predicate = null);
        List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null);
        List<Recipient> GetAllRecipients(Func<Recipient, bool> predicate = null);
        List<Package> GetAllPackages(Func<Package, bool> predicate = null);

        JsonAddress GetAddressDetails(Address address);

        List<Package>[] DividePackages(List<Package> Packages, int K);
        Volunteer FindClosestVolunteer(List<Volunteer> Volunteers, Address Address);
        
    }
}
