﻿using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormFinding.Models
{
   class Mydatabase
    {
        public static string GetConnectionString() => ConfigurationManager.ConnectionStrings["strConnect"].ToString();
        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader rd;
        public static DataTable dt;
        public static SqlDataAdapter da;
        

        

        public static void OpenConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionString();
                    con.Open();
                    
                    
                }
            }catch(Exception e)
            {
                MessageBox.Show("Error Connecting Sever.... ", "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void CloseConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    
                    con.Close();

        
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message +"Error Close sever");
            }
        }
    }
}
