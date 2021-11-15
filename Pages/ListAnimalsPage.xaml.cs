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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace database2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListAnimalsPage.xaml
    /// </summary>
    public partial class ListAnimalsPage : Page
    {
        public ListAnimalsPage()
        {
            InitializeComponent();
            LVAnimals.ItemsSource = BaseClass.Base.PetPass.ToList(); 

        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<PetCharacter> TC = BaseClass.Base.PetCharacter.Where(x => x.petID == index).ToList();
            string str = "";
            foreach (PetCharacter item in TC)
            {
                str += item.PetTraits.charname + ", ";
            }
            tb.Text = str.Substring(0, str.Length - 2);
        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<PetFood> TC = BaseClass.Base.PetFood.Where(x => x.petID == index).ToList();
            int sum = 0;
            foreach (PetFood item in TC)
            {
                sum+= item.kolMonth*item.FoodFirm.priceFood;
            }
            tb.Text = sum +" руб. уйдёт на пропитание в среднем в месяц";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new AdminNavigatePage());
        }
    }
}
