using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Final_Project
{
	using GH.Views;

    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        public void LaunchWindow()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Zach_Click(object sender, RoutedEventArgs e)
        {
            ZachSQL form = new ZachSQL();
            form.Show();
        }
        
        private void Button_Seth_Click(object sender, RoutedEventArgs e)
        {
            SethsScraper form = new SethsScraper();
            form.Show();
        }

		private void GwynButton_Click(object sender, RoutedEventArgs e)
		{
			CustomerView form = new CustomerView();
			form.Show();
		}
	}
}
