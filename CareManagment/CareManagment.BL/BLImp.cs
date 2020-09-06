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

        public bool ValidUser(string userName, string password)
        {
           /* if (IRepository.GetAdmins(x => x.MailAddress == userName && x.Password == password).Count != 0)
                return true;

            if (IRepository.GetVolunteers(x => x.MailAddress == userName && x.Password == password).Count != 0)
                return true;*/
            return false;
            
        }

        public void AddPerson(Person person)
        {
            IRepository.AddPerson(person);
        }

        public void AddDistribution(Distribution distribution)
        {
            IRepository.AddDistribution(distribution);
        }

       

        public List<Person> GetAllPersons(Func<Person, bool> predicate = null)
        {
           return IRepository.GetAllPersons(predicate);
        }

        public JsonAddress GetAddressDetails(Address address)
        {
            throw new NotImplementedException();
        }

        public List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null)
        {
            return IRepository.GetAllDistribution(predicate);
        }

        public void UpdatePerson(Person person)
        {
            IRepository.UpdatePerson(person);
        }
    }
}
