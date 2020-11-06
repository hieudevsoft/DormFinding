using DormFinding.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DormFinding
{
    public class RegistrationVM : ObservableObject,IDataErrorInfo
    {
        
        private String _email;
       
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email)) result = "Email must be not null";
                        else if (Email.Length<10) {
                            result = "Email must be a minimum of 5 characters";
                        }
                        break;
                        
                }
              
                OnPropertyChanged("Error Collection");
                return result;
            }
            
        }
        

        public String Email
        {
            get { return _email; }
            set
            {
                OnPropertyChanged(ref _email, value);
            }
        }

        public string Error { get { 
                return null; 
            } 
        }
    }
}
