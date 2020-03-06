using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OurDestination.Data
{
    public class RptConnectionClass
    {
        private string dbDatabase = "";
        private string strConnection = "";

        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommandBuilder scb = new SqlCommandBuilder();

        public RptConnectionClass(Boolean IsWeb = false)
        {
            CreateConnectionString(dbDatabase, IsWeb);
        }

        public RptConnectionClass(string strDatabaseName, Boolean IsWeb = false)
        {
            CreateConnectionString(strDatabaseName, IsWeb);
        }

        private void CreateConnectionString(string strDatabaseName, Boolean isWeb = false)
        {
            strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void ConnectionOpen()
        {
            con = new SqlConnection(strConnection);
            con.Open();
        }
         private void ConnectionClose()
        {
            if(this.con.State != System.Data.ConnectionState.Closed)
            {
                this.con.Close();
            }
        }

        public void FillDatasetThroughDataAdapter(ref DataSet ds, string sqlQuery)
        {
            try
            {
                ConnectionOpen();
                com = new SqlCommand(sqlQuery, con);
                com.CommandTimeout = 1200;
                sda.SelectCommand = com;
                sda.Fill(ds);
                scb.DataAdapter = sda;

                sda.InsertCommand = scb.GetInsertCommand();
                sda.UpdateCommand = scb.GetUpdateCommand();
                sda.DeleteCommand = scb.GetDeleteCommand();

            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public void FillDataSetWithSqlCommand(ref DataSet ds, string sqlQuery)
        {
            try
            {
                ConnectionOpen();
                com = con.CreateCommand();
                com.CommandTimeout = 1200;

                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
                da.Fill(ds);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public IDataReader GetReader(String sql)
        {
            try
            {
                ConnectionOpen();
                var command = con.CreateCommand();
                command.CommandText = sql;
                IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void SaveDataThroughDataAdapter(ref DataSet ds)
        {

            sda.Update(ds);
        }

        public int SaveDataWithSqlCommand(string sqlQuary)
        {
            int Result = 0;
            if(sqlQuary.Length ==0 || sqlQuary == string.Empty)
            {
                return Result;
            }

            try
            {
                ConnectionOpen();
                com = new SqlCommand(sqlQuary, con);
                com.CommandTimeout = 1200;
                Result = (Int32)com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                ConnectionClose();
            }
            return Result;
        }

        public void SaveDataWithSqlCommand(ArrayList sqlQuary)
        {
            if(sqlQuary.Count == 0)
            {
                throw new Exception("Empty Sql Query.");
            }

            ConnectionOpen();
            com = con.CreateCommand();
            com.CommandTimeout = 1200;

            SqlTransaction tran = con.BeginTransaction();
            com.Connection = con;
            com.Transaction = tran;

            try
            {
                for (int i = 0; i < sqlQuary.Count; i++)
                {
                    com.CommandText = sqlQuary[i].ToString();
                    com.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception sqlex)
                {
                    if (tran.Connection != null)
                    {
                        Console.WriteLine("An exception of type" + sqlex.GetType() + "was encounterd while attempting to roll back the transaction.");
                    }
                      
                }
                throw (ex);
            }
            finally
            {
                ConnectionClose();
            }
        }
    }
}