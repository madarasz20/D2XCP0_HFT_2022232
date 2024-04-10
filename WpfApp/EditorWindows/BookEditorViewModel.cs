using D2XCP0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfApp.EditorWindows
{
    public class BookEditorViewModel : ObservableRecipient
    {
        public RestCollection<Book> Books { get; set; }

        public Book selectedBook;
        public Book SelectedBook    
        {
            get { return selectedBook; }
            set
            {
                if (value != null)
                {
                    selectedBook = new Book()
                    {
                        Title = value.Title,
                        BookID = value.BookID
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public BookEditorViewModel()
        {
            if (!IsInDesignMode)
            {
                Books = new RestCollection<Book>("http://localhost:20300/", "book");

                CreateBookCommand = new RelayCommand(() =>
                {
                    Books.Add(new Book()
                    {
                        Title = SelectedBook.Title
                    });
                });

                UpdateBookCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Books.Update(SelectedBook);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteBookCommand = new RelayCommand(() =>
                {
                    Books.Delete(SelectedBook.BookID);
                },
                    () =>
                    {
                        return SelectedBook != null;
                    });
                SelectedBook = new Book();
            }
        }
    }
}
