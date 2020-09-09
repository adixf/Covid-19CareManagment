﻿using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CareManagment.Models
{
    class AdminDistributionsM
    {
        public IBL BL { get; set; }
        public List<Distribution> OldDistributions { get; set; }
        public List<Distribution> NewDistributions { get; set; }

        public AdminDistributionsM()
        {
            BL = new BLImp();
            OldDistributions = new List<Distribution>(BL.GetAllDistributions
                (x => (x.Admin.MailAddress == ((App)Application.Current).Currents.LoggedUser.MailAddress) && x.IsDelivered));
            NewDistributions = new List<Distribution>(BL.GetAllDistributions
                (x => (x.Admin.MailAddress == ((App)Application.Current).Currents.LoggedUser.MailAddress) && !x.IsDelivered));
        }   
       
    }
}