﻿using DormFinding.Utils;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
            }
            catch (Exception e)
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
                MessageBox.Show(e.Message + "Error Close sever");
            }
        }

        // Insert User
        public static Boolean InsertToTableUser(string email, string password, byte isActive)
        {
            String sql = $"insert into {Helpers.tbUser} values(@Email,@Password,@IsRemember);";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@IsRemember", isActive);
                cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Email already exit", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                CloseConnection();
            }
        }

        public static void InsertToTableUserProfile(string email)
        {

            String sql = $"insert into {Helpers.tbUserProfile}({Helpers.colEmailProfile}) values(@Email);";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Information Error", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                CloseConnection();
            }
        }
        public static Boolean CheckAccount(string email, string password)
        {

            sql = $"select count(*) from {Helpers.tbUser} where {Helpers.colEmail}=@Email and {Helpers.colPassword}=@password;";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                if (count != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Email or Password not correct", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting...", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                CloseConnection();
            }



        }
        public static Boolean Update(User user,string email)
        {

            String sql = $"update {Helpers.tbUser} SET {Helpers.colRemember}=@IsRemember , {Helpers.colPassword}=@Password where {Helpers.colEmail}=@Email;";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsRemember", user.isRemember);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Change Remember " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                CloseConnection();
            }
        }

        public static User CheckAccountAreadyInApp()
        {
            string sql = $"select * from {Helpers.tbUser} where {Helpers.colRemember}=@value;";
            User user = null;
            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@value", 1);
                rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    string email = rd.GetValue(0).ToString();
                    string password = rd.GetValue(1).ToString();
                    user = new User(email, password, 1);
                }
               
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading remember" + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            finally
            {
                CloseConnection();
            }
            return user;
        }

        public static UserProfile getProfile(User user)
        {
            string sql = $"select * from {Helpers.tbUserProfile} where {Helpers.colEmailProfile}=@Email";
            UserProfile userProfile=null;
            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", user.Email.Trim());
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string email = rd.GetValue(0).ToString();
                    string name = rd.GetValue(1).ToString();
                    string date = rd.GetValue(2).ToString();
                    string phone = rd.GetValue(3).ToString();
                    string address = rd.GetValue(4).ToString();
                    string hint = rd.GetValue(5).ToString();
                    byte gender = byte.Parse(rd.GetValue(6).ToString());
                    byte[] image;
                    if (rd.GetValue(7).ToString().Equals("")){
                        
                        userProfile = new UserProfile(email, name, date, phone, address, hint, gender, null);
                    }
                    else
                    {
                        image = (byte[])rd.GetValue(7);
                        
                        userProfile = new UserProfile(email, name, date, phone, address, hint, gender, image);
                    }
               
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading Profile" + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                CloseConnection();
            }

            return userProfile;
        }
        public static Boolean UpdateProfileSave(UserProfile user)
        {

            String sql = $"update {Helpers.tbUserProfile} SET {Helpers.colNameProfile}=@Name , {Helpers.colPhoneProfile}=@Phone, {Helpers.colImageProfile}=@Image where {Helpers.colEmailProfile}=@Email;";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Image", user.Avatar);
                cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update User Profile " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                CloseConnection();
            }
        }

        public static Boolean UpdateProfileSubmit(UserProfile user)
        {

            String sql = $"update {Helpers.tbUserProfile} SET {Helpers.colAdressProfile}=@Address , {Helpers.colHintProfile}=@Hint, {Helpers.colDateProfile} = @Date" +
                $", {Helpers.colGenderProfile} = @Gender where {Helpers.colEmailProfile}=@Email;";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Hint", user.Hint);
                cmd.Parameters.AddWithValue("@Date", user.Date);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update User Profile " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                CloseConnection();
            }
        }
    }
}

