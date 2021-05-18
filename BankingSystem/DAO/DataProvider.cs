﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem.DAO
{
    public class DataProvider

    {
        private static DataProvider instance;
        private string connectionstr = "Data Source=desktop-qen4lji\\mssqlserver01;Initial Catalog=BANKMANAGEMENTSYSTEM;Integrated Security=True";

        public static DataProvider Instance 
        {
            get {
                if (instance == null)
                 instance=new DataProvider();
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; } 
        }
        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionstr)) {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(data);
                connection.Close();
            }
            return data;    
        }
    }
}
