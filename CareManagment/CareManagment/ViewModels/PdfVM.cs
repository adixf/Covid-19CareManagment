using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.ViewModels
{
    public class PdfVM: BaseViewModel
    {
        public string name;
       
        public PdfVM()
        {
            name = "racheli";
        }
        
    }
}
