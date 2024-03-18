using D2XCP0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.Input;
using MovieDbApp.WpfClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Author> Authors { get; set; }
        public ICommand CreateAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }
        public ICommand UpdateAuthorCommand { get; set; }
        public MainWindowViewModel()
        {
            Authors = new RestCollection<Author>("http://localhost:20300/", "author");
            CreateAuthorCommand = new RelayCommand(() =>
            {
                Authors.Add(new Author()
                {
                    AuthorName = "Kiss Béla",
                    AuthorID = 333
                });
            });
        }
    }
}
