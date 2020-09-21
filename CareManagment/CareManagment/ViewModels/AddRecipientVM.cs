using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.DP.Types;
using CareManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    class AddRecipientVM : BaseViewModel
    {
        #region user properties
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (new Tools.VerifyString().IsValidName(value)) firstName = value;
                else throw new ArgumentException("נא הכנס שם הכולל אותיות בלבד");
                OnPropertyRaised("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (new Tools.VerifyString().IsValidName(value)) lastName = value;
                else throw new ArgumentException("נא הכנס שם הכולל אותיות בלבד");
                OnPropertyRaised("LastName");
            }
        }
        private string personId;
        public string PersonId
        {
            get { return personId; }
            set
            {

                if (new Tools.VerifyString().IsValidPersonId(value)) personId = value;
                else throw new ArgumentException("נא הכנס מספר זהות תקין");
                OnPropertyRaised("PersonId");
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {

                if (new Tools.VerifyString().IsValidPhoneNumber(value)) phoneNumber = value;
                else throw new ArgumentException("נא הכנס מספר טלפון תקין");
                OnPropertyRaised("PhoneNumber");
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                if (new Tools.VerifyString().IsValidName(value)) city = value;
                else throw new ArgumentException("נא הכנס שם עיר תקין");
                OnPropertyRaised("City");
            }
        }

        private string streetName;
        public string StreetName
        {
            get { return streetName; }
            set
            {
                if (new Tools.VerifyString().IsValidName(value)) streetName = value;
                else throw new ArgumentException("נא הכנס שם רחוב תקין");
                OnPropertyRaised("StreetName");
            }
        }

        private string buildingNumber;
        public string BuildingNumber
        {
            get { return buildingNumber; }
            set
            {
                if (int.TryParse(value, out int x)) buildingNumber = value;
                else throw new ArgumentException("נא הכנס מספר בניין תקין");
                OnPropertyRaised("BuildingNumber");
            }

        }
        private string mailAddress;
        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                if (new Tools.VerifyString().IsVaildEmail(value)) mailAddress = value;
                else throw new ArgumentException("נא הכנס כתובת מייל תקינה");
                OnPropertyRaised("MailAddress");
            }
        }
        #endregion

        public AddRecipientM AddRecipientM { get; set; }
        public ICommand AddRecipientCommand
        {
            get
            {
                return new BaseCommand(delegate () { SignUp(); });
            }
        }

        public AddRecipientVM()
        {
            AddRecipientM = new AddRecipientM(); 
        }

        public void SignUp()
        {
            try
            {
                if (PersonId == null || FirstName == null || LastName == null || PhoneNumber == null || MailAddress == null || City == null || StreetName == null || buildingNumber == null)
                    throw new Exception("אנא מלא את כל השדות");

                Recipient recipient = new Recipient(personId, FirstName, LastName, PhoneNumber, MailAddress, new Address(City, StreetName, int.Parse(BuildingNumber)));
                AddRecipientM.SignUp(recipient);

                Message = new Message("איזה כיף!", "הנמען נוסף בהצלחה", true, false);
            }
            catch (Exception e)
            {
                Message = new Message("משהו השתבש.", e.Message, false, true);
            }

        }
    }





}
