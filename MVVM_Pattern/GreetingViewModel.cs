using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Pattern
{
    public class GreetingViewModel : INotifyPropertyChanged
    {



        private string hello;
        public string Hello
        {
            get { return hello; }
            set { hello = value; NotifyPropertyChanged(); }
        }


        private List<GreetingModel> CountryList_;

        public List<GreetingModel> CountryList
        {
            get { return CountryList_; }
            set { CountryList_ = value; }
        }


        private GreetingModel SelectedCountry_;

        public GreetingModel SelectedCountry
        { 
            get { return SelectedCountry_; }
            set
            {
                SelectedCountry_ = value;
                NotifyPropertyChanged();
                Hello = SelectedCountry_.Greeting;
            }
        }

        public GreetingViewModel ()
        {
            CountryList = new List<GreetingModel>
            { 
                new GreetingModel { CountryId=1,CountryName="India",Greeting="Hi I am from India"},
                new GreetingModel { CountryId=2,CountryName="Australia",Greeting="Hi I am from Australia"},
                new GreetingModel{ CountryId=3,CountryName="Pakistan",Greeting ="Hi I am from Pakistan"}

            };

            SelectedCountry = CountryList[0];
        }



        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
