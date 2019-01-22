using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UIFaces.NET.Models;
using UIFaces.NET.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FaceSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GetPersons();
        }


        public async void GetPersons()
        {
            // LIMIT
            int Limit = (int)LimitSlider.Value;

            // OFFSET
            int Offset = 0;

            // GENDERS
            List<Gender> Genders = new List<Gender>();
            if (MaleBox.IsChecked == true) { Genders.Add(Gender.Male); }
            if (FemaleBox.IsChecked == true) { Genders.Add(Gender.Female); }

            // IS RANDOM
            bool IsRandom = RandomSwitch.IsOn;

            // FROM AGE
            int StartAge = 18;

            // TO AGE
            int FromAge = 40;


            // HAIR COLORS
            List<string> HairColors = new List<string>();
            if (BlondeBox.IsChecked == true) { HairColors.Add("blond"); }
            if (BrownBox.IsChecked == true) { HairColors.Add("brown"); }
            if (BlackBox.IsChecked == true) { HairColors.Add("black"); }

            // EMOTIONS
            List<string> Emotions = new List<string>();
            if (HappyBox.IsChecked == true) { Emotions.Add("happiness"); }
            if (NeutralBox.IsChecked == true) { Emotions.Add("neutral"); }


            UIFacesService Service = new UIFacesService("41ce8f96bade52007646eecac0a0c2");
            List<Person> Persons = await Service.GetFaces(Limit, Offset, Genders, IsRandom, StartAge, FromAge, HairColors, Emotions);
            PersonsGridView.ItemsSource = Persons;

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            GetPersons();
        }
    }
}
