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
        void AddVolunteer(Volunteer volunteer);
        void AddDistribution(Distribution distribution);
        void AddRecipient(Recipient recipient);
        void AddAdmin(Admin admin);

        void UpdateUser(User user);
        void UpdateRecipient(Recipient recipient);

        List<Recipient> GetRecipients(Func<Recipient, bool> predicate = null);
        List<Distribution> GetDistribution(Func<Distribution, bool> predicate = null);
        List<Volunteer> GetVolunteers(Func<Volunteer, bool> predicate = null);
        List<Admin> GetAdmins(Func<Volunteer, bool> predicate = null);

        JsonAddress GetAddressDetails(Address address);
        bool ValidUser(string userName, string password);
    }
}
