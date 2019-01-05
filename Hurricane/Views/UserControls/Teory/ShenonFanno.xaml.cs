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
    /// Логика взаимодействия для ShenonFanno.xaml
    /// </summary>
    public partial class ShenonFanno : UserControl
    {
        public ShenonFanno()
        {
            InitializeComponent();
            this.Loaded += ShenonFanno_Loaded;
        }

        private void ShenonFanno_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader($@"Teory\Textovki\Shenon-Fanno\{LanguageHolder.Lan}.txt"))
            {
                Ter.Text = sr.ReadToEnd();
            }
        }
    }
}
