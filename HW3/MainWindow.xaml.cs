using HW2DLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataContractJsonSerializer Serializer;
        DataContractJsonSerializer inputSerializer;
        //ObservableCollection<Publisher> p1;
        Publisher p1;
        Book b1;

        public MainWindow()
        {           
            InitializeComponent();
            p1 = new Publisher();
            b1 = new Book();
            DataContext = p1;

        }



        private void buttonOpenPubFile_Click(object sender, RoutedEventArgs e)
        {

            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ""; // Default file extension
            dlg.Filter = "JSON files (.json)|*.json"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
              //  Publisher pT = new Publisher();
                //ObservableCollection<Book> bCount = new ObservableCollection<Book>();
                // Open document
                string filename = dlg.FileName;
                textBoxPublisherFileName.Text = filename;
                FileStream pReader = new FileStream(filename, FileMode.Open, FileAccess.Read);
                inputSerializer = new DataContractJsonSerializer(typeof(Publisher));
                p1 = (Publisher)inputSerializer.ReadObject(pReader);
                pReader.Dispose();
                //string pubName = p1.Name;
                //textBoxPublisherNameDisplay.Text = pubName;
                //p1.Name = textBoxPublisherNameDisplay.Text;
                //textBoxPublisherNameDisplay.Text = p1.Name;
                //string z = textBoxPublisherNameDisplay.Text;
                //int bCount = p1.BookList.Count;
                
                DataContext = p1;
                //pT.Books=p1.Books;
                //textBoxBookCountDisplay.DataContext = p1.BookList;
               // Binding b = new Binding();
                //textBoxBookCountDisplay.SetBinding(TextBox.TextProperty, b);
            }

        }

        private void FindBook_Click(object sender, RoutedEventArgs e)
        {
            string filename = textBoxPublisherFileName.Text;
            FileStream pReader = new FileStream(filename, FileMode.Open, FileAccess.Read);
            inputSerializer = new DataContractJsonSerializer(typeof(Publisher));
            p1 = (Publisher)inputSerializer.ReadObject(pReader);
            pReader.Dispose();

            b1 = p1.findBook(textBoxTargetBookTitle.Text);
            /*
            foreach (Book bk in p1.Books)
            {
                
            }
            */
            textBoxBookTitle.DataContext = b1;
            textBoxBookPrice.DataContext = b1;
            listViewAuthors.DataContext = b1;
            

            //  p1.findBook();
        }
        /*
        private void listViewBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string filename = textBoxPublisherFileName.Text;
            textBoxPublisherFileName.Text = filename;
            FileStream pReader = new FileStream(filename, FileMode.Open, FileAccess.Read);
            inputSerializer = new DataContractJsonSerializer(typeof(Publisher));
            p1 = (Publisher)inputSerializer.ReadObject(pReader);
            pReader.Dispose();
        }*/
    }
}
