using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.ViewModels
{
    class AddDistributionVM : BaseViewModel
    {
        public bool IsDistributionReady { get; set; }

        public AddDistributionVM()
        {
            IsDistributionReady = false;
        }

        // אחרי שלחץ על בקש ביצוע חלוקה
//        var CheckedRecipients = new List<Recipients>();
//        foreach (var item in listViewChapter.SelectedItems)
//    users.Add((Chapter) item);
    }
}
