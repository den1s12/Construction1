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
    /// Логика взаимодействия для ConntractorsWindow.xaml
    /// </summary>
    public partial class ConntractorsWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                                Initial Catalog=user84");
        SqlCommand sqlCommand;
        DGClass dGClass;
        public ConntractorsWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ContractorDG);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CompanyDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDg("SELECT * FROM dbo.ContractorView " +
           $"Where LoginUser Like '%{SearchTb.Text}%'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDg("Select * FROM dbo.ContractorView");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
