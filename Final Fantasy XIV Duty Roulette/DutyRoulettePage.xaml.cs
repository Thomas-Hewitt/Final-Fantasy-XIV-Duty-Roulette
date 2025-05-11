using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DutyRoulettePage.xaml
    /// </summary>
    public partial class DutyRoulettePage : Page
    {
        Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();
        List<List<string>> dungeons = new List<List<string>> { new List<string> { "Sastasha", "The Tam-Tara Deepcroft", "Copperbell Mines", "Halatali"
            , "The Thousand Maws of Toto-Rak", "Haukke Manor", "Brayflox's Longstop", "The Sunken Temple of Qarn", "Cutter's Cry", "The Stone Vigil"
            , "Dzemael Darkhold", "The Aurum Vale" }
        , new List<string> { "Castrum Meridianum (LOL)", "The Praetorium (LMAO)", "The Wanderer's Palace", "Amdapor Keep", "Pharos Sirius"
            , "Copperbell Mines (Hard)", "Haukke Manor (Hard)", "The Lost City of Amdapor", "Halatali (Hard)", "Brayflox's Longstop (Hard)"
            , "Hullbreaker Isle", "The Tam-Tara Deepcroft (Hard)", "The Stone Vigil (Hard)", "Snowcloak", "Sastasha (Hard)", "The Sunken Temple of Qarn (Hard)"
            , "The Keeper of the Lake", "The Wanderer's Palace (Hard)", "Amdapor Keep (Hard)" }
        , new List<string> { "The Dusk Vigil", "Sohm Al", "The Aery", "The Vault", "The Great Gubal Library" } 
        , new List<string> { "The Aetherochemical Research Facility", "Neverreap", "The Fractal Continuum", "Saint Mocianne's Arboretum", "Pharos Sirius (Hard)"
            , "The Antitower", "The Lost City of Amdapor (Hard)", "Sohr Khai", "Hullbreaker Isle (Hard)", "Xelphatol", "The Great Gubal Library (Hard)"
            , "Baelsar's Wall", "Sohm Al (Hard)"} 
        , new List<string> { "The Sirensong Sea", "Shisui of the Violet Tides", "Bardam's Mettle", "Doma Castle", "Castrum Abania" }
        , new List<string> { "Ala Mhigo", "Kugane Castle", "The Temple of the Fist", "The Drowned City of Skalla", "Hells' Lid", "The Fractal Continuum (Hard)"
            , "The Swallow's Compass", "The Burn", "Saint Mocianne's Arboretum (Hard)", "The Ghimylt Dark"}
        , new List<string> { "Holminster Switch", "Dohn Mheg", "The Qitana Ravel", "Malikah's Well", "Mt. Gulg" }
        , new List<string> { "Amaurot", "The Twinning", "Akadaemia Anyder", "The Grand Cosmos", "Anamnesis Anyder", "The Heroes' Gauntlet", "Matoya's Relict", "Paglth'an" }
        , new List<string> { "The Tower of Zot", "The Tower of Babil", "Vanaspati", "Ktisis Hyperboreia", "The Aitiascope" }
        , new List<string> { "The Dead Ends", "Smileton", "The Stigma Dreamscape", "Alzadaal's Legacy", "The Fell Court of Troia", "Lapis Manalis"
            , "The Aetherfont", "The Lunar Subterrane"}
        , new List<string> { "Ihuykatumu", "Worqor Zormor", "The Skydeep Cenote", "Vanguard", "Origenics" }
        , new List<string> { "Alexandria", "Tender Valley", "The Strayborough Deadwalk", "Yuweyawata Field Station", "The Underkeep" } };

        string prevDuty = string.Empty;

        public DutyRoulettePage()
        {
            InitializeComponent();

            // initializing the hash table.
            for(int i = 0; i < dungeons.Count; i++)
            {
                map.Add(i, dungeons[i]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int key = -1;
            bool found = false;
            List<RadioButton> buttons = new List<RadioButton>();
            buttons.Add(Dungeons1to49);
            buttons.Add(Dungeons50);
            buttons.Add(Dungeons51to59);
            buttons.Add(Dungeons60);
            buttons.Add(Dungeons61to69);
            buttons.Add(Dungeons70);
            buttons.Add(Dungeons71to79);
            buttons.Add(Dungeons80);
            buttons.Add(Dungeons81to89);
            buttons.Add(Dungeons90);
            buttons.Add(Dungeons91to99);
            buttons.Add(Dungeons100);
            for(int i = 0; i < dungeons.Count && found == false; i++)
            {
                if (buttons[i].IsChecked == true)
                {
                    key = i;
                    found = true;
                }
            }
            if (key < 0)
            {
                // No dungeon category was selected.
                return;
            }

            Randomize(key);
        }

        private async Task Silly_Animation(Random rng, List<string> duties)
        {
            int randtime = rng.Next(5, 20);
            for (int i = 0; i < randtime; i++)
            {
                Dungeon.Content = duties[rng.Next(0, duties.Count)];
                await Task.Delay(50);
            }
        }

        private async void Randomize(int key)
        {
            Random rng = new Random();
            List<string> duties = map[key];
            int index = rng.Next(0, duties.Count);
            await Silly_Animation(rng, duties);
            // Making sure you never get the same duty twice in a row.
            while (duties[index] == prevDuty)
            {
                index = rng.Next(0, duties.Count);
            }
            Dungeon.Content = duties[index];
            prevDuty = duties[index];
        }
    }
}
