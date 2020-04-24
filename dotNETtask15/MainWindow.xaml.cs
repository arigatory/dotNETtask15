using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNETtask15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Do you want to save file?";
            MessageBoxResult result = MessageBox.Show(msg, "Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                SaveCommandBinding_Executed(sender, null);
            }
            if (result == MessageBoxResult.No)
            {
               
            }
            e.Cancel = (result == MessageBoxResult.Cancel);
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chbSpelling_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void chbSpelling_Click(object sender, RoutedEventArgs e)
        { 
            if (chbSpelling.IsChecked == true)
            {
               
                txtData.SpellCheck.IsEnabled = true;
            }
            else
            {
                txtData.SpellCheck.IsEnabled = false;
            }
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog { Filter = "Text Files |*.txt" };
            if (true == openDlg.ShowDialog())
            {
                string dataFromFile = File.ReadAllText(openDlg.FileName);

                txtData.Text = dataFromFile;
            }
        }

        private void OpenCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog { Filter = "Text Files |*.txt" };

            if (true== saveDlg.ShowDialog())
            {
                File.WriteAllText(saveDlg.FileName, txtData.Text);
            }
        }

        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();  
        }

        private void ExitCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
