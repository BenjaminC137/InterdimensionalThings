using System;
namespace InterdimensionalThings.Services
{
    public class SettingsService
    {
        public SettingsService()
        {
            SelectedCurrency = Currencies[0];
            SelectedLanguage = Languages[0];
        }
        public string[] Languages = { "English", "Pig Latin", "gazorpian", "Bird Person", "Gromflamish" };
        public string[] Currencies = { "Earth Dollar","Blemflarck", "Brapple","Flurbo","Glem","Schmeckle","Smidgen"};

        public string SelectedLanguage { get; set; }
        public string SelectedCurrency { get; set; }
    }
}
