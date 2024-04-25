using D2XCP0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp.EditorWindows
{
    /// <summary>
    /// Interaction logic for NcEditorWindow.xaml
    /// </summary>
    public partial class NcEditorWindow : Window
    {
        public NcEditorWindow()
        {
            InitializeComponent();
        }

        
    }
    public class MyItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AuthorTemplate { get; set; }
        public DataTemplate BookTemplate { get; set; }
        public DataTemplate IEnumerabelBookTemplate { get; set; }
        //public DataTemplate IntTemplate { get; set; }

        // Author
        //public List<DataTemplate> AuthorTemplates 
        //{
        //    get { return AuthorTemplates; }
        //    set
        //    {
        //        AuthorTemplates = new List<DataTemplate>
        //        {
        //            YoungestAuthorTemplate,
        //            OldestAuthorTemplate,
        //            NumOfAuthorsTemplate
        //        };
        //    }
        //}
        //public DataTemplate YoungestAuthorTemplate { get; set; }    //rtw Author
        //public DataTemplate OldestAuthorTemplate { get; set; }      //rtw Author
        //public DataTemplate NumOfAuthorsTemplate { get; set; }      //rtw int

        // Book
        //public List<DataTemplate> BookTemplates
        //{
        //    get { return BookTemplates; }
        //    set
        //    {
        //        BookTemplates = new List<DataTemplate>
        //        {
        //            BestRatedBookInfoTemplate,
        //            LongestTitleBookInfoTemplate,
        //            MostExpensiveBookInfoTemplate,
        //            MostPagesInABookInfoTemplate,
        //            MostFreqGenreTemplate
        //        };
        //    }
        //}
        //public DataTemplate BestRatedBookInfoTemplate { get; set; }         // rtw Book
        //public DataTemplate LongestTitleBookInfoTemplate { get; set; }          // rtw Book
        //public DataTemplate MostExpensiveBookInfoTemplate { get; set; }         // rtw Book
        //public DataTemplate MostPagesInABookInfoTemplate { get; set; }          // rtw Book
        //public DataTemplate MostFreqGenreTemplate { get; set; }                 // rtw NameAndCount

        // IEnumerable<Book>
        //public List<DataTemplate> IEnumerableBookTemplates
        //{
        //    get { return IEnumerableBookTemplates; }
        //    set
        //    {
        //        IEnumerableBookTemplates = new List<DataTemplate>
        //        {
        //            BooksInGenreTemplate,
        //            BooksbyAuthorTemplate,
        //            BooksWithAuthorsTemplate,
        //            BgaTemplate,
        //            BooksandAuthorsFilteredByGenreTemplate
        //        };
        //    }
        //}
        //public DataTemplate BooksInGenreTemplate { get; set; }      // rtw IEnumerabel<Book>,   par int genre id
        //public DataTemplate BooksbyAuthorTemplate { get; set; }     // rtw IEnumerabel<Book>,    int authorID
        //public DataTemplate BooksWithAuthorsTemplate { get; set; }      //rtw IEnumerabel<Book>,
        //public DataTemplate BgaTemplate { get; set; }               //rtw IEnumerabel<Book>,
        //public DataTemplate BooksandAuthorsFilteredByGenreTemplate { get; set; }        // rtw IEnumerabel<Book>,  desiredGenreId

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //NameandCount datatemplate needed

            if (item is Author )
            {
                return AuthorTemplate;
            }
            else if (item is Book)
            {
                return BookTemplate;
            }
            //else if (item is int)
            //{
            //    return IntTemplate;
            //}
            else
            {
                return IEnumerabelBookTemplate;
            }

        }
    }
}
