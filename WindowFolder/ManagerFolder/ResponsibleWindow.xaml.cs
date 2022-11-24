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
    /// Логика взаимодействия для ResponsibleWindow.xaml
    /// </summary>
    public partial class ResponsibleWindow : Window
    {
        SqlConnection sqlConnection =
         new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                                Initial Catalog=user84");
        SqlCommand sqlCommand;
        DGClass dGClass;
        public ResponsibleWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ResponsibleDG);
        }

        private void ResponsibleDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ResponsibleDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.IdResponsible = dGClass.SelectId();
                try
                {
                    new EditResponsibleWindow().ShowDialog();
                    dGClass.LoadDg("Select * From dbo.Responsible");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new EditResponsibleWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.Responsible");
            Close();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDg("SELECT * FROM dbo.Responsible " +
         $"Where LastNameResponsible Like '%{SearchTb.Text}%'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDg("Select * FROM dbo.Responsible");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
