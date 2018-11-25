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
    
    public enum PageOptions
    {
        linear = 1,
        quadratic = 2,
        cubic = 3,
        quartic = 4
    };
    

    public partial class Window1 : Window
    {

        int[] vals = new int[] { 0, 0, 0, 0, 0 };
        int[] x = new int[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] y = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        PageOptions currentTab;

        public Window1()
        {
            InitializeComponent();
        }

        public void OnTabSelect(object sender, RoutedEventArgs e)
        {
            DependencyObject o = sender as DependencyObject;
            string senderName = o.GetValue(FrameworkElement.NameProperty) as string;
            switch(senderName)
            {
                case "Linear":
                    currentTab = PageOptions.linear;
                    break;
                case "Quadratic":
                    currentTab = PageOptions.quadratic;
                    break;
                case "Cubic":
                    currentTab = PageOptions.cubic;
                    break;
                case "Quartic":
                    currentTab = PageOptions.quartic;
                    break;
            }
        }

        //do process
        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            GetValues();
            CalcValues();
            DispValues();
        }

        //get and store eq vals
        public void GetValues()
        {
            switch (currentTab)
            {
                case PageOptions.linear:
                    vals[0] = Convert.ToInt32(linXSqr.Text);
                    vals[1] = Convert.ToInt32(linXLinear.Text);
                    vals[2] = Convert.ToInt32(linKConst.Text);
                    break;
                case PageOptions.quadratic:
                    break;
                case PageOptions.cubic:
                    break;
                case PageOptions.quartic:
                    break;
            }
        }

        //build eq & do the math
        public void CalcValues()
        {
            switch (currentTab)
            {
                case PageOptions.linear:
                    vals[0] = Convert.ToInt32(linXSqr.Text);
                    vals[1] = Convert.ToInt32(linXLinear.Text);
                    vals[2] = Convert.ToInt32(linKConst.Text);
                    break;
                case PageOptions.quadratic:
                    break;
                case PageOptions.cubic:
                    break;
                case PageOptions.quartic:
                    break;
            }
        }

        //display calculated values
        public void DispValues()
        {

        }
    }


}
