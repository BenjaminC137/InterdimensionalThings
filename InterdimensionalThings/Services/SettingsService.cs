using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
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
        public string[] Currencies = { "Earth Dollar $","Blemflarck ❧", "Brapple ¤","Flurbo ❂","Glem ₲","Schmeckle ლ","Smidgen ૱"};
        //public string[] Rates = { "1","3", "5","8","-7","81","-81"};
        public Decimal[] Rates = { 1,3, 5,8,0.7m,81,0.081m};
        public string[] Symbols = { "$","❧", "¤","❂","₲","ლ","૱"};
        

        public string SelectedLanguage { get; set; }
        public string SelectedCurrency { get; set; }
        public Decimal ExchangeRate { 
            get{
                return Rates[Currencies.IndexOf(SelectedCurrency)];
                
            }
        }
        public string CurrencySymbol { 
            get{
                return Symbols[Currencies.IndexOf(SelectedCurrency)];
                
            }
        }        
        
    }
}
