using Microsoft.Win32;
using System.Windows;

namespace X10_to_A10
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDiag = new OpenFileDialog()
            {
                DefaultExt = ".tms",
                FileName = "File.tms",
                Multiselect = false,
                Filter = "X10 Script File|*.tms"
            };

            if ((bool)fileDiag.ShowDialog())
            {
                InputTextField.Text = fileDiag.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDiag = new SaveFileDialog()
            {
                DefaultExt = ".csv",
                FileName = "File.csv",
                Filter = "CSV File|*.csv"
            };

            if ((bool)fileDiag.ShowDialog())
            {
                OutputTextField.Text = fileDiag.FileName;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FileConverter.ConvertToCSV(InputTextField.Text, OutputTextField.Text);
        }
    }
}