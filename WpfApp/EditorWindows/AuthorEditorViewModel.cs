using D2XCP0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.EditorWindows
{
    public class AuthorEditorViewModel : ObservableRecipient
    {
        public RestCollection<Author> Authors { get; set; }

        public Author selectedAuthor;
        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                if (value != null)
                {
                    selectedAuthor = new Author()
                    {
                        AuthorName = value.AuthorName,
                        AuthorID = value.AuthorID
                    };
                    OnPropertyChanged();
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public ICommand CreateAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }
        public ICommand UpdateAuthorCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public AuthorEditorViewModel()
        {
            if (!IsInDesignMode)
            {
                Authors = new RestCollection<Author>("http://localhost:20300/", "author");

                CreateAuthorCommand = new RelayCommand(() =>
                {
                    Authors.Add(new Author()
                    {
                        AuthorName = selectedAuthor.AuthorName
                    });
                });

                UpdateAuthorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Authors.Update(SelectedAuthor);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteAuthorCommand = new RelayCommand(() =>
                {
                    Authors.Delete(selectedAuthor.AuthorID);
                },
                    () =>
                    {
                        return SelectedAuthor != null;
                    });
                SelectedAuthor = new Author();
            }
        }
    }
}
