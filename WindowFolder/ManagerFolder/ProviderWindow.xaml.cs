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
    /// Логика взаимодействия для ProviderWindow.xaml
    /// </summary>
    public partial class ProviderWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        //SqlCommand sqlCommand;
        DGClass dGClass;
        public ProviderWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ProviderDG);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditProviderWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.CompanyView");
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddProviderWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.CompanyView");
            Close();
        }

        private void CompanyDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProviderDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.IdCompany = dGClass.SelectId();
                try
                {
                    new EditProviderWindow().ShowDialog();
                    dGClass.LoadDg("Select * From dbo.CompanyView");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDg("SELECT * FROM dbo.CompanyView " +
            $"Where NameResource Like '%{SearchTb.Text}%'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDg("Select * FROM dbo.CompanyView");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
