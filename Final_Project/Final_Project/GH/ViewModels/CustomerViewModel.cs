namespace Final_Project.GH.ViewModels
{
    using System;
    using Final_Project.GH.Models;

    internal class CustomerViewModel
    {
        private CustomerModel _CustomerModel;

        /// <summary>
        /// Initializes a new Customer View Model
        /// </summary>
        public CustomerViewModel()
        {
			_CustomerModel = new CustomerModel("Gwyn");
        }

        /// <summary>
        /// Gets the Customer Model
        /// </summary>
        public CustomerModel CustomerModel
        {
            get
            {
                return _CustomerModel;
            }
        }

		/// <summary>
		/// Push values to datasource
		/// </summary>
		public void SaveChanges()
		{

		}

    }
}
