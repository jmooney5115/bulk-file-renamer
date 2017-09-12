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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;

namespace BulkFileRenamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Icon from: https://www.iconfinder.com/icons/49255/rename_icon
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loop through each file in the directory with the given extension and replace the given string.
        /// </summary>
        public void RenameFiles()
        {
            var path = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(path);
            var cnt = 0;
            foreach (var file in dir.GetFiles(TextBoxExtension.Text))
            {
                if (file.Name.Contains(TextBoxFind.Text))
                    cnt++;

                var name = file.FullName.Replace(TextBoxFind.Text, TextBoxReplace.Text);
                file.MoveTo(name);
            }

            MessageBox.Show("Renamed " + cnt + " files.");

        }

        /// <summary>
        /// Run rename file function on button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RenameFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail. Ex: " + ex);
            }
        }
    }
}
