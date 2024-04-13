using D2XCP0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WpfApp.EditorWindows
{
    public class NcEditorViewModel : ObservableRecipient
    {
        public ObservableCollection<Author> youngestAuthor { get; set; }
        public ObservableCollection<Author> YoungestAuthor
        {
            get
            {
                return youngestAuthor;
            }
            set
            {
                youngestAuthor = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Author> oldestAuthor { get; set; }
        public ObservableCollection<Author> OldestAuthor
        {
            get
            {
                return oldestAuthor;
            }
            set
            {
                oldestAuthor = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Author> numOfAuthors { get; set; }
        public ObservableCollection<Author> NumOfAuthors
        {
            get
            {
                return numOfAuthors;
            }
            set
            {
                numOfAuthors = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Book> bestRatedBookInfo { get; set; }
        public ObservableCollection<Book> BestRatedBookInfo
        {
            get
            {
                return bestRatedBookInfo;
            }
            set
            {
                bestRatedBookInfo = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Book> longestTitleBookInfo { get; set; }
        public ObservableCollection<Book> LongestTitleBookInfo
        {
            get
            {
                return longestTitleBookInfo;
            }
            set
            {
                longestTitleBookInfo = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Book> mostExpensiveBookInfo { get; set; }
        public ObservableCollection<Book> MostExpensiveBookInfo
        {
            get
            {
                return MostExpensiveBookInfo;
            }
            set
            {
                MostExpensiveBookInfo = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Book> mostPagesInABookInfo { get; set; }
        public ObservableCollection<Book> MostPagesInABookInfo
        {
            get
            {
                return mostPagesInABookInfo;
            }
            set
            {
                mostPagesInABookInfo = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Book> mostFreqGenre { get; set; }
        public ObservableCollection<Book> MostFreqGenre
        {
            get
            {
                return mostFreqGenre;
            }
            set
            {
                mostFreqGenre = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IEnumerable<Book>> booksInGenre { get; set; }
        public ObservableCollection<IEnumerable<Book>> BooksInGenre
        {
            get
            {
                return booksInGenre;
            }
            set
            {
                booksInGenre = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IEnumerable<Book>> booksbyAuthor { get; set; }
        public ObservableCollection<IEnumerable<Book>> BooksbyAuthor
        {
            get
            {
                return booksbyAuthor;
            }
            set
            {
                booksbyAuthor = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IEnumerable<Book>> booksWithAuthors { get; set; }
        public ObservableCollection<IEnumerable<Book>> BooksWithAuthors
        {
            get
            {
                return booksWithAuthors;
            }
            set
            {
                booksWithAuthors = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IEnumerable<Book>> bga { get; set; }
        public ObservableCollection<IEnumerable<Book>> Bga
        {
            get
            {
                return bga;
            }
            set
            {
                bga = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IEnumerable<Book>> booksandAuthorsFilteredByGenre { get; set; }
        public ObservableCollection<IEnumerable<Book>> BooksandAuthorsFilteredByGenre
        {
            get
            {
                return booksandAuthorsFilteredByGenre;
            }
            set
            {
                booksandAuthorsFilteredByGenre = value;
                OnPropertyChanged();
            }
        }

        public RestService rest { get; set; }
        private string tb_input;

        public string Tb_input
        {
            get 
            { 
                return tb_input; 
            }
            set 
            { 
                tb_input = value; 
                OnPropertyChanged();
                (YoungestAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                (OldestAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                (NumOfAuthorsCommand as RelayCommand).NotifyCanExecuteChanged();
                (BestRatedBookInfoCommand as RelayCommand).NotifyCanExecuteChanged();
                (LongestTitleBookInfoCommand as RelayCommand).NotifyCanExecuteChanged();
                (MostExpensiveBookInfoCommand as RelayCommand).NotifyCanExecuteChanged();
                (MostPagesInABookInfoCommand as RelayCommand).NotifyCanExecuteChanged();
                (MostFreqGenreCommand as RelayCommand).NotifyCanExecuteChanged();
                (BooksInGenreCommand as RelayCommand).NotifyCanExecuteChanged();
                (BooksbyAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                (BooksWithAuthorsCommand as RelayCommand).NotifyCanExecuteChanged();
                (BgaCommand as RelayCommand).NotifyCanExecuteChanged();
                (BooksandAuthorsFilteredByGenreCommand as RelayCommand).NotifyCanExecuteChanged();


            }

        }

        private string selectedMethod;
        public string SelectedMethod
        {
            get { return selectedMethod; }
            set
            {
                selectedMethod = value;
                OnPropertyChanged(nameof(SelectedMethod));
                OnPropertyChanged(nameof(SelectedObservableCollection));
            }
        }

        public IEnumerable SelectedObservableCollection
        {
            get
            {
                switch (SelectedMethod)
                {
                    case "YoungestAuthor":
                        return YoungestAuthor;
                    case "OldestAuthor":
                        return OldestAuthor;
                    case "NumOfAuthors":
                        return NumOfAuthors;
                    case "BestRatedBookInfo":
                        return BestRatedBookInfo;
                    case "LongestTitleBookInfo":
                        return LongestTitleBookInfo;
                    case "MostExpensiveBookInfo":
                        return MostExpensiveBookInfo;
                    case "MostPagesInABookInfo":
                        return MostPagesInABookInfo;
                    case "MostFreqGenre":
                        return MostFreqGenre;
                    case "BooksInGenre":
                        return BooksInGenre;
                    case "BooksbyAuthor":
                        return BooksbyAuthor;
                    case "BooksWithAuthors":
                        return BooksWithAuthors;
                    case "Bga":
                        return Bga;
                    case "BooksandAuthorsFilteredByGenre":
                        return BooksandAuthorsFilteredByGenre;

                    default:
                        return null;
                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand YoungestAuthorCommand { get; set; }
        public ICommand OldestAuthorCommand { get; set; }
        public ICommand NumOfAuthorsCommand { get; set; }
        public ICommand BestRatedBookInfoCommand { get; set; }
        public ICommand LongestTitleBookInfoCommand { get; set; }
        public ICommand MostExpensiveBookInfoCommand { get; set; }
        public ICommand MostPagesInABookInfoCommand { get; set; }
        public ICommand MostFreqGenreCommand { get; set; }
        public ICommand BooksInGenreCommand { get; set; }
        public ICommand BooksbyAuthorCommand { get; set; }
        public ICommand BooksWithAuthorsCommand { get; set; }
        public ICommand BgaCommand { get; set; }
        public ICommand BooksandAuthorsFilteredByGenreCommand { get; set; }

    }
}
