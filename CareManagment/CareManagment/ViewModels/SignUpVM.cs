using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    public class SignUpVM : BaseViewModel
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
            get { return personId; }
            set
            {

                if (new Tools.VerifyString().IsValidPhoneNumber(value)) phoneNumber = value;
                else throw new ArgumentException("נא הכנס מספר טלפון תקין");
                OnPropertyRaised("PhoneNumber");
            }
        }
        private string password;
        public string Password
        {
            get { if (password == null) return password; else return "********"; }
            set
            {
                if (new Tools.VerifyString().IsValidPassword(value)) password = value;
                else throw new ArgumentException("בחר סיסמה בת 8 תווים");
                OnPropertyRaised("Password");
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

        public bool IsAdmin { get; set; }
        public bool IsVolunteer { get; set; }

        #endregion

        public SignUpM SignUpModel { get; set; }

        public ICommand SignUpCommand { get { return new SignUpCommand(this); } }

        public SignUpVM()
        {
            SignUpModel = new SignUpM();
        }

        public void SignUp()
        {
            UserType userType;
            if (IsAdmin) userType = UserType.Admin; else userType = UserType.Volunteer;
            SignUpModel.SignUp(new User(personId,FirstName,LastName,PhoneNumber,MailAddress,new Address(City,StreetName, int.Parse(BuildingNumber)),Password,userType));
        }
    }
}
