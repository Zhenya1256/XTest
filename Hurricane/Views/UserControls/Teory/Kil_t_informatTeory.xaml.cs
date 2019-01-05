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
    /// Логика взаимодействия для Kil_t_informatTeory.xaml
    /// </summary>
    public partial class Kil_t_informatTeory : UserControl
    {
        public Kil_t_informatTeory()
        {
            InitializeComponent();
            this.Loaded += Kil_t_informatTeory_Loaded;
        }

        private void Kil_t_informatTeory_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader($@"Teory\Textovki\Kil-t informat\{LanguageHolder.Lan}.txt"))
            {
                Ter.Text = sr.ReadToEnd();
            }
        }
    }
}
