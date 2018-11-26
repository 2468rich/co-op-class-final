namespace Final_Project.GH.Models
{
    using System;
    using System.ComponentModel;

    public class CustomerModel : INotifyPropertyChanged
    {
        //Private variables
        private string _Name;

        /// <summary>
        /// Initializes a new customer with a name
        /// </summary>
        /// <param name="customerName"></param>
        public CustomerModel(String customerName)
        {
            Name = customerName;
        }

        /// <summary>
        /// Gets and sets the name of the customer
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
