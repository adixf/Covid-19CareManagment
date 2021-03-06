﻿using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DAL.Interfaces
{
    public interface IRepository
    {
        void AddVolunteer(Volunteer person);
        void AddAdmin(Admin person);
        void AddRecipient(Recipient recipient);
        void AddDistribution(Distribution distribution);
        void AddPackage(Package package);
        void UpdateDistribution(Distribution distribution);

        List<Volunteer> GetAllVolunteers(Func<Volunteer, bool> predicate = null);
        List<Admin> GetAllAdmins(Func<Admin, bool> predicate = null);
        List<Recipient> GetAllRecipients(Func<Recipient, bool> predicate = null);
        List<Package> GetAllPackages(Func<Package, bool> predicate = null);       
        List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null);
       
       JsonAddress GetAddressDetails(Address address);
    }
}
