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
                Initial Catalog=user84;
                Integrated Security=True");
        DGClass dGClass;
        public ConntractorsWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ContractorDG);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            new EditConntractorWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.[InfWorkContractor]");
            Close();
        }

        private void CompanyDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ContractorDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.IdWork = dGClass.SelectId();
                try
                {
                    new EditConntractorWindow().ShowDialog();
                    dGClass.LoadDg("Select * From dbo.[InfWorkContractor]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDg("SELECT * FROM dbo.[InfWorkContractor] " +
           $"Where LoginUser Like '%{SearchTb.Text}%'");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDg("Select * FROM dbo.[InfWorkContractor]");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddConntractorWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.[InfWorkContractor]");
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
