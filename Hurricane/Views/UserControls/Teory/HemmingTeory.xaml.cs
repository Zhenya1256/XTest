using Hurricane.XTest.Core.Holders;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hurricane.Views.UserControls.Teory
{
    /// <summary>
    /// Логика взаимодействия для HemmingTeory.xaml
    /// </summary>
    public partial class HemmingTeory : UserControl
    {
        public HemmingTeory()
        {
            InitializeComponent();
            this.Loaded += HemmingTeory_Loaded;
        }

        private void HemmingTeory_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader($@"Teory\Textovki\Hemming\{LanguageHolder.Lan}.txt"))
            {
                Ter.Text = sr.ReadToEnd();
            }
        }
    }
}
