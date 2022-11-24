using Construction.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Construction.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для DirectorInfoWindow.xaml
    /// </summary>
    public partial class DirectorInfoWindow : Window
    {
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        //SqlCommand sqlCommand;
        DGClass dGClass;
        public DirectorInfoWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(DirectorInfoDG);
        }

        private void DirectorInfoDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DirectorInfoDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.IdDirector = dGClass.SelectId();
                try
                {
                    new EditDirectorInfoWindow().ShowDialog();
                    dGClass.LoadDg("Select * From dbo.Director");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new EditDirectorInfoWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.CompanyView");
            Close();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDg("SELECT * FROM dbo.Director " +
           $"Where LastNameDirector Like '%{SearchTb.Text}%'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDg("Select * FROM dbo.Director");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
