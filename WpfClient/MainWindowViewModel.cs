using D2XCP0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Author> Authors { get; set; }

        private Author selectedAuthor;

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set 
            {
                if (value != null)
                {
                    selectedAuthor = new Author()
                    {
                        AuthorID = value.AuthorID,
                        AuthorName = value.AuthorName,
                    };
                    OnPropertyChanged();
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


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
            UpdateAuthorCommand = new RelayCommand(() =>
            {
                Authors.Update(SelectedAuthor);
            });

            DeleteAuthorCommand = new RelayCommand(() =>
            {
                Authors.Delete(SelectedAuthor.AuthorID);
            },
            () =>
            {
                return SelectedAuthor != null;
            });
            SelectedAuthor = new Author();
        }
    }
}
