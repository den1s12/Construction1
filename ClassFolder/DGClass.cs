using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Construction.ClassFolder
{
    class DGClass
    {
        SqlConnection sqlConnection =
              new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlDataAdapter SqlDataAdapter;
        DataGrid dataGrid;
        DataTable dataTable;

        public DGClass(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        public void LoadDg(string sqlCommand)
        {
            try
            {
                sqlConnection.Open();
                SqlDataAdapter =
                    new SqlDataAdapter(sqlCommand, sqlConnection);
                dataTable = new DataTable();
                SqlDataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public string SelectId()
        {
            object[] mass = null;
            string id = "";
            try
            {
                if (dataGrid != null)
                {
                    DataRowView dataRowView = dataGrid.SelectedItem
                        as DataRowView;
                    if (dataRowView != null)
                    {
                        DataRow dataRow = (DataRow)dataRowView.Row;
                        mass = dataRow.ItemArray;
                    }
                }
                id = mass[0].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            return id;
        }
    }
}
