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
    public class GenreEditorViewModel : ObservableRecipient
    {
        public RestCollection<Genre> Genres { get; set; }

        public Genre selectedGenre;
        public Genre SelectedGenre
        {
            get { return selectedGenre; }
            set
            {
                if (value != null)
                {
                    selectedGenre = new Genre()
                    {
                        GenreName = value.GenreName,
                        GenreID = value.GenreID
                    };
                    OnPropertyChanged();
                    (DeleteGenreCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public ICommand CreateGenreCommand { get; set; }
        public ICommand DeleteGenreCommand { get; set; }
        public ICommand UpdateGenreCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public GenreEditorViewModel()
        {
            if (!IsInDesignMode)
            {
                Genres = new RestCollection<Genre>("http://localhost:20300/", "genre");

                CreateGenreCommand = new RelayCommand(() =>
                {
                    Genres.Add(new Genre()
                    {
                        GenreName = SelectedGenre.GenreName
                    });
                });

                UpdateGenreCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Genres.Update(SelectedGenre);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteGenreCommand = new RelayCommand(() =>
                {
                    Genres.Delete(SelectedGenre.GenreID);
                },
                    () =>
                    {
                        return SelectedGenre != null;
                    });
                SelectedGenre = new Genre();
            }
        }
    }
}
