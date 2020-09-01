using CareManagment.BL.Interfaces;
using CareManagment.DAL;
using CareManagment.DAL.Interfaces;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.BL
{
    public class BLImp : IBL
    {
        public IRepository IRepository { get; set; }

        public BLImp()
        {
            IRepository = new Repository();
        }

        public void AddAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AddDistribution(Distribution distribution)
        {
            throw new NotImplementedException();
        }

        public void AddRecipient(Recipient recipient)
        {
            throw new NotImplementedException();
        }

        public void AddVolunteer(Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        public JsonAddress GetAddressDetails(Address address)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAdmins(Func<Volunteer, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<Distribution> GetDistribution(Func<Distribution, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<Recipient> GetRecipients(Func<Recipient, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<Volunteer> GetVolunteers(Func<Volunteer, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipient(Recipient recipient)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool ValidUser(string userName, string password)
        {
           /* if (IRepository.GetAdmins(x => x.MailAddress == userName && x.Password == password).Count != 0)
                return true;

            if (IRepository.GetVolunteers(x => x.MailAddress == userName && x.Password == password).Count != 0)
                return true;*/
            return false;
            
        }
    }
}
