using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject_MVVM.Model
{
    public class DICOM_Model : IDataErrorInfo, INotifyPropertyChanged
    {
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public string Name { get; set; }
        public string Status { get; set; }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        #region Validation

        static readonly string[] ValidatedProperties =
        {
            "Password"
        };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        string GetValidationError(String propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Password":
                    error = ValidatePassword();
                    break;
            }
            return error;
        }
        private string ValidatePassword()
        {
            if (Password == null)
            {
                return null;
            }
            if (Password!= "1234")
            {
                return "Incorrect Password.";
            }
            return null;
        }
        #endregion
    }
}
