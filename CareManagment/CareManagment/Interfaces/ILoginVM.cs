﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.Interfaces
{
    interface ILoginVM
    {
        bool ValidUser(string userName, string password);
    }
}
