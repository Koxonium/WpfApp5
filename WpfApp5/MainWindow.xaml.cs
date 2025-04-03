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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager manager;
        List<Cars> all;
        public MainWindow()
        {
            InitializeComponent();
            manager = new FileManager("data.txt");
            Start();
            masik();
        }

        void Start()
        {
            all = manager.ReadFile();
            everything.Children.Clear();
            foreach (Cars item in all)
            {
                Label oneLabel = new Label() { Content = item.Model, FontSize = 20, Tag = item };
                oneLabel.MouseLeftButtonUp += CarClick;
                oneLabel.MouseRightButtonUp += LoadInto;
                everything.Children.Add(oneLabel);
            }
        }

        void masik()
        {
            List<object> asd = new List<object>();

            asd.Add(10);
            asd.Add("kolbasz");
            asd.Add(true);
            asd.Add('c');
            asd.Add(66.66);
            asd.Add(new TextBox());
            asd.Add(new Label() { Content="asd"});


            /*asd.Add(new Fa { nev="Fa", faanyag="Tölgy", kemenyseg=4132.4, suly=500.5, ar=12000 });

            asd.Add(new Vas { nev="Acél", ar=25000, suly=20, femtipus="Rozsdamentes acél", suruseg=321.32});

            asd.Add(new Tegla { nev="Piros tégla", ar = 5500, suly=50, szin="Piros", teglatipus="Tört"});*/


            /*foreach (epitoanyag item in asd)
            {
                if (item is Tegla)
                {
                    MessageBox.Show($"Név: {(item as Tegla).nev }, tipus: {(item as Tegla).teglatipus}");
                }
                else if (item is Fa)
                {
                    MessageBox.Show($"Név: {(item as Fa).nev }, tipus: {(item as Fa).faanyag}");
                }
                else if (item is Vas)
                {
                    MessageBox.Show($"Név: {(item as Vas).nev }, tipus: {(item as Vas).femtipus}");
                }
                item.ar += 50;
            }*/

            
        }

        void CarClick(object sender, EventArgs e)
        {
            Label oneLabel = sender as Label;
            Cars oneCar = oneLabel.Tag as Cars;
            MessageBox.Show($"Gyártó: {oneCar.Manufacturer}, Modell: {oneCar.Model}, Teljesítmény: {oneCar.Power}, Súly: {oneCar.Weight}");
        }

        void CreateEvent(object s, EventArgs e)
        {
            if (EditButton.IsEnabled)
            {
                EditButton.IsEnabled = false;
                ManufacturerInput.Clear();
                ModelInput.Clear();
                PowerInput.Clear();
                WInput.Clear();
                return;
            }

            string manufacturer = ManufacturerInput.Text;
            string model = ModelInput.Text;
            int power = -1;
            int weight = -1;

            if (!CheckEverything(manufacturer, model, ref power, ref weight)) return;

            Cars oneCar = new Cars(manufacturer, model, power, weight);
            manager.WriteOneLine(oneCar);
            Start();
        }

        void LoadInto(object s, EventArgs e)
        {
            Label oneLabel = s as Label;
            Cars oneCar = oneLabel.Tag as Cars;
            index = everything.Children.IndexOf(oneLabel);
            ManufacturerInput.Text = oneCar.Manufacturer;
            ModelInput.Text = oneCar.Model;
            PowerInput.Text = oneCar.Power.ToString(); ;
            WInput.Text = oneCar.Weight.ToString();
            EditButton.IsEnabled = true;
        }
        
        bool CheckEverything(string manufacturer, string model, ref int power, ref int weight)
        {
            string powerString = PowerInput.Text;
            string weightString = WInput.Text;

            if (manufacturer.Length < 2)
            {
                MessageBox.Show("Kérlek érvényes gyártót adj meg!");
                return false;
            }
            if (model.Length < 2)
            {
                MessageBox.Show("Kérlek érvényes modelt adj meg!");
                return false;
            }
            if (powerString.Length < 1)
            {
                MessageBox.Show("Kérlek érvényes teljesítményt adj meg!");
                return false;
            }
            if (!int.TryParse(powerString, out power))
            {
                MessageBox.Show("A teljesítménynek számnak kell lennie!");
                return false;
            }
            if (weightString.Length < 3)
            {
                MessageBox.Show("Kérlek érvényes súlyt adj meg!");
                return false;
            }
            if (!int.TryParse(weightString, out weight))
            {
                MessageBox.Show("A teljesítménynek számnak kell lennie!");
                return false;
            }
            return true;
        }

        public int index;

        void EditEvent(object s, EventArgs e)
        {
            manager.all[index].Manufacturer = ManufacturerInput.Text;
            manager.all[index].Model = ManufacturerInput.Text;
            manager.all[index].Power = int.Parse(PowerInput.Text);
            manager.all[index].Weight = int.Parse(WInput.Text);
            manager.Edit(manager.all);

            Start();
        }
    }
}
