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
        public List<User> GetAllUsers(Func<User, bool> predicate = null)
        {
            return IRepository.GetAllUsers(predicate);
        }

        

        public List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null)
        {
            return IRepository.GetAllDistribution(predicate);
        }

        public void UpdatePerson(Person person)
        {
            IRepository.UpdatePerson(person);
        }

        public void AddPackage(Package package)
        {
            IRepository.AddPackage(package);
        }

        public void UpdateDistribution(Distribution distribution)
        {
            IRepository.UpdateDistribution(distribution);
        }

        public bool ValidUser(string userName, string password)
        {
            throw new NotImplementedException();
        }


        public Task<JsonAddress> GetAddressDetails(Address address)
        {
            return IRepository.GetAddressDetails(address);
        }
    }
}
