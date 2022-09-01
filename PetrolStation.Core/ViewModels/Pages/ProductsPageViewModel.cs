using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PetrolStation.Core
{
    public class ProductsPageViewModel //: IReckoningInMIniliters
    {
        // public double Miniliter { get; set; }
    //    ProductViewModel productVIewModel { get; set; }
        public string[] productDetailsFromTextFile { get; set; }
        private ObservableCollection<ProductViewModel> _finalList= new ObservableCollection<ProductViewModel>();
        public ObservableCollection<ProductViewModel> FinalLIst// ObservableCollection<ProductViewModel> FinalLIst
        {
            get => _finalList;
            set
            {
                _finalList = value;
                OnPropertyChanged("FinalLIst");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string name { get; set; }
        public double price { get; set; }
        public ICommand AddNewProductCommand { get; set; }

        public ProductsPageViewModel()
        {
            GetProductInformationFromFile("FuelType.txt");
            AddNewProductCommand = new RelayCommand(ProductAndPriceAssign);
        }
      
        public void GetProductInformationFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            productDetailsFromTextFile = lines;
            ProductAndPriceAssign();
        }
        public void ProductAndPriceAssign()
        {
            AddNewProductCommand = new RelayCommand(ProductAndPriceAssign);
            string[] uu = productDetailsFromTextFile;
            int counter = 0;
            foreach (var line in uu)
            {
                if (counter == 1)
                {
                    price = Convert.ToDouble(line);
                    var product = new ProductViewModel
                    {
                        ProductName = name,
                        ProductPrice = price
                    };
                    FinalLIst.Add(product);
                    counter++;
                }
                if (counter == 0)
                {
                    counter++;
                    name = line;
                }
                if (counter == 2)
                    counter = 0;
            }
        }


    }
}
