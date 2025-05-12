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

namespace Final_Fantasy_XIV_Duty_Roulette
{
    /// <summary>
    /// Interaction logic for ClassRoulettePage.xaml
    /// </summary>
    public partial class ClassRoulettePage : Page
    {
        List<string> classes = new List<string> { "Paladin", "Warrior", "Dark Knight", "Gunbreaker", "White Mage", "Scholar", "Astrologian", "Sage"
        , "Monk", "Dragoon", "Ninja", "Samurai", "Reaper", "Viper", "Bard", "Machinist", "Dancer", "Black Mage", "Summoner", "Red Mage", "Pictomancer", "Blue Mage" };
        int prevClass = -1;
        public ClassRoulettePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<int> keys = new List<int>();
            List<CheckBox> buttons = new List<CheckBox> { Paladin, Warrior, DarkKnight, Gunbreaker, WhiteMage, Scholar, Astrologian, Sage
            , Monk, Dragoon, Ninja, Samurai, Reaper, Viper, Bard, Machinist, Dancer, BlackMage, Summoner, RedMage, Pictomancer, BlueMage };
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].IsChecked == true)
                {
                    keys.Add(i);
                }
            }
            if (keys.Count < 1)
            {
                // No classes were selected.
                return;
            }

            Randomize(keys);
        }

        private async Task Silly_Animation(Random rng, List<int> keys)
        {
            int randtime = rng.Next(2, (2 * keys.Count));
            for (int i = 0; i < randtime; i++)
            {
                Class.Content = classes[keys[rng.Next(0, keys.Count)]];
                await Task.Delay(50);
            }
        }

        private async void Randomize(List<int> keys)
        {
            Random rng = new Random();
            int index = rng.Next(0, keys.Count);
            await Silly_Animation(rng, keys);
            // Making sure you never get the same duty twice in a row.
            while (index == prevClass && keys.Count != 1)
            {
                index = rng.Next(0, keys.Count);
            }
            Class.Content = classes[keys[index]];
            prevClass = index;
        }
    }
}
