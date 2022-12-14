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
    class CBClass
    {
        SqlConnection sqlConnection =
         new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlDataAdapter sqlData;
        DataSet dataSet;

        public void StatusCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select IdStatus, NameStatus " +
                    "From dbo.[Status]",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Status]");
                comboBox.ItemsSource = dataSet.Tables["[Status]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Status]"].Columns["NameStatus"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Status]"].Columns["IdStatus"].ToString();
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

        public void DirectorCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select IdDirector, LastNameDirector " +
                    "From dbo.[Director]",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Director]");
                comboBox.ItemsSource = dataSet.Tables["[Director]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Director]"].Columns["LastNameDirector"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Director]"].Columns["IdDirector"].ToString();
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

        public void ResponsibleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select IdResponsible, LastNameResponsible " +
                    "From dbo.[Responsible]",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Responsible]");
                comboBox.ItemsSource = dataSet.Tables["[Responsible]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Responsible]"].Columns["LastNameResponsible"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Responsible]"].Columns["IdResponsible"].ToString();
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

        //public void ResourceNameCBLoad(ComboBox comboBox)
        //{
        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlData = new SqlDataAdapter("Select NameResource " +
        //            "From dbo.[SuppliedRecources]",
        //            sqlConnection);
        //        dataSet = new DataSet();
        //        sqlData.Fill(dataSet, "[SuppliedRecources]");
        //        comboBox.ItemsSource = dataSet.Tables["[SuppliedRecources]"].DefaultView;
        //        comboBox.DisplayMemberPath = dataSet.
        //            Tables["[SuppliedRecources]"].Columns["NameResource"].ToString();
        //        comboBox.SelectedValuePath = dataSet.
        //           Tables["[SuppliedRecources]"].Columns["NameResource"].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MBClass.ErrorMB(ex);
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}

        public void RoleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select IdRole, NameRole " +
                    "From dbo.[Role]",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Role]"].Columns["NameRole"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Role]"].Columns["IdRole"].ToString();
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

        public void CompanyCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select IdCompany, FullNameCompany " +
                    "From dbo.[Companies]",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Companies]");
                comboBox.ItemsSource = dataSet.Tables["[Companies]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Companies]"].Columns["FullNameCompany"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Companies]"].Columns["IdCompany"].ToString();
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
    }
}
