using D2XCP0_HFT_2022232.Models;
using MovieDbApp.WpfClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Author> Authors { get; set; }
        public MainWindowViewModel()
        {
            Authors = new RestCollection<Author>("http://localhost:20300/", "author");
        }
    }
}
