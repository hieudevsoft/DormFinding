using DormFinding.Classess;
using DormFinding.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
  
        

       

       
        public static void deleteDormOwnerDorm(int id)
        {

             Mydatabase.sql = $"delete from {Helpers.tbDormOwner} where {Helpers.colIdOwnerDorm} = @Id";

            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Mydatabase.sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Delete tbOwnerDorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                CloseConnection();
            }
        }
        public static void InsertToTableOwnerDorm(string email, int idDorm)
        {

            Mydatabase.sql = $"insert into {Helpers.tbDormOwner}({Helpers.colEmailOwnerDorm},{Helpers.colIdOwnerDorm}) values(@Email,@Id);";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Mydatabase.sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Id", idDorm);
                cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error Insert to table owner dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                CloseConnection();
            }
        }
        public static UserProfile getOwnerProfileWithDorm(int idDorm)
        {
            UserProfile owner = new UserProfile();

            Mydatabase.sql = $"select {Helpers.colImageProfile},{Helpers.colNameProfile},{Helpers.colPhoneProfile},{Helpers.colEmailProfile}," +
                $"{Helpers.colAdressProfile}, {Helpers.colGenderProfile} " +
                $"from {Helpers.tbUserProfile},{Helpers.tbDormOwner} " +
                $"where {Helpers.colIdOwnerDorm} = @Id and {Helpers.colEmailOwnerDorm} = {Helpers.colEmailProfile};";
            try
            {
                OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
                rd = Mydatabase.cmd.ExecuteReader();
                while (rd.Read())
                {
                    string email = rd.GetValue(3).ToString();
                    string name = rd.GetValue(1).ToString();
                    string phone = rd.GetValue(2).ToString();
                    string address = rd.GetValue(4).ToString();
                    byte gender = byte.Parse(rd.GetValue(5).ToString());
                    byte[] image;
                    image = (byte[])rd.GetValue(0);
                    owner = new UserProfile(email, name, "", phone, address, "", gender, image);

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error getOwnerProfileWithDorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                rd.Close();
                CloseConnection();
            }

            return owner;
        }

        public static bool insertDormComment(string emailOwner,int idDorm,string emailUser,string comment,int rating)
        {
            Mydatabase.sql = $"insert into {Helpers.tbBookComment} values(@EmailOwner,@Id,@EmailUser,@Comment,@Rating) ;";
            try
            {
                OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@EmailOwner", emailOwner);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
                Mydatabase.cmd.Parameters.AddWithValue("@EmailUser", emailUser);
                Mydatabase.cmd.Parameters.AddWithValue("@Comment", comment);
                Mydatabase.cmd.Parameters.AddWithValue("@Rating", rating);
                Mydatabase.cmd.ExecuteScalar();
                return true;

            }catch(Exception e)
            {
                //MessageBox.Show("Error insertDormComment " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                CloseConnection();
            }

        }
        public static void deleteDormComment(int idDorm)
        {
            Mydatabase.sql = $"delete from {Helpers.tbBookComment} where {Helpers.tbBookComment} = @Id ;";
            try
            {
                OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
               
                Mydatabase.cmd.ExecuteScalar();
               

            }
            catch (Exception e)
            {
                //MessageBox.Show("Error insertDormComment " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            finally
            {
                CloseConnection();
            }

        }
        public static int getAVGRating(string emailOwner, int idDorm)
        {
            Mydatabase.sql = $"select avg({Helpers.colRatingDormComment}) from {Helpers.tbBookComment} where {Helpers.tbBookComment}.{Helpers.colEmailOwnerDormComment} = @Email and {Helpers.tbBookComment}.{Helpers.colIdDormDormComment} = @Id ;";
            try
            {
                OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", emailOwner);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
               
                int a = Convert.ToInt32(Mydatabase.cmd.ExecuteScalar().ToString());
                return a;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error getAVGRatig " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
            finally
            {
                CloseConnection();
            }

        }
        public static List<BookComment> getAllCommentBookDorm(string email,int id)
        {
            List<BookComment> list = new List<BookComment>();
            Mydatabase.sql = $"select {Helpers.tbUserProfile}.{Helpers.colEmailProfile},{Helpers.tbUserProfile}.{Helpers.colImageProfile},{Helpers.tbBookComment}.{Helpers.colCommentDormComment},{Helpers.tbBookComment}.{Helpers.colRatingDormComment} " +
                $"from {Helpers.tbUserProfile},{Helpers.tbBookComment} where {Helpers.tbUserProfile}.{Helpers.colEmailProfile} = {Helpers.tbBookComment}.{Helpers.colEmailUserDormComment} " +
                $"and {Helpers.tbBookComment}.{Helpers.colEmailOwnerDormComment} = @Email and {Helpers.tbBookComment}.{Helpers.colIdDormDormComment} = @Id;";
            try
            {
                OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);
             
                rd = Mydatabase.cmd.ExecuteReader();
                while (rd.Read())
                {
                    BookComment bookDorm = new BookComment();
                    bookDorm.Owner = email;
                    bookDorm.Id = id;
                    bookDorm.User = rd.GetString(0);
                    bookDorm.Image = Helpers.ConvertByteToImageBitmap((byte[])rd.GetValue(1));
                    bookDorm.Comment = rd.GetString(2)
;                   bookDorm.Rating = rd.GetInt32(3);
                    list.Add(bookDorm);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error getAllCommentBookDorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            finally
            {
                CloseConnection();
            }

            return list;
        }
        public static List<Dorm> getAllListDormOwner(string email)
        {
           Mydatabase.sql = $"select * from {Helpers.tbDorm},{Helpers.tbDormOwner} where {Helpers.colIdDorm} = {Helpers.colIdOwnerDorm} and {Helpers.colEmailOwnerDorm} = @Email";
            List<Dorm> listDorm = new List<Dorm>();
            
            try
            {
                OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                rd = Mydatabase.cmd.ExecuteReader();
                while (rd.Read())
                {
                    Dorm dorm = new Dorm();
                    int id = rd.GetInt32(0);
                    string owner = rd.GetString(1);
                    string address = rd.GetString(2);
                    string description = rd.GetString(3);
                    double price = rd.GetDouble(4);
                    double sale = rd.GetDouble(5);

                    byte[] image;
                    if (rd.GetValue(6).ToString().Equals(""))
                    {
                        dorm.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri($"../../images/icon_app.ico", UriKind.RelativeOrAbsolute));

                    }
                    else
                    {
                        image = (byte[])rd.GetValue(6);

                        dorm.Image = Helpers.ConvertByteToImageBitmap(image);
                    }

                    int count = rd.GetInt32(7);
                    int countLike = rd.GetInt32(8);

                    byte wifi = Helpers.ConverBoolToByte(rd.GetBoolean(9));

                    byte parking = Helpers.ConverBoolToByte(rd.GetBoolean(10));
                    byte television = Helpers.ConverBoolToByte(rd.GetBoolean(11));
                    byte bathroom = Helpers.ConverBoolToByte(rd.GetBoolean(12));
                    byte aircon = Helpers.ConverBoolToByte(rd.GetBoolean(13));
                    byte waterheater = Helpers.ConverBoolToByte(rd.GetBoolean(14));
                    int quality = rd.GetInt16(15);
                    double size = rd.GetDouble(16);

                    dorm.Id = id;
                    dorm.Owner = owner;
                    dorm.Address = address;
                    dorm.Description = description;
                    dorm.Price = price;
                    dorm.Sale = sale;
                    dorm.Count = count;
                    dorm.CountLike = countLike;
                    dorm.IsWifi = Helpers.ConvertByteToVisibility(wifi);
                    dorm.IsParking = Helpers.ConvertByteToVisibility(parking);
                    dorm.IsTelevision = Helpers.ConvertByteToVisibility(television);
                    dorm.IsBathroom = Helpers.ConvertByteToVisibility(bathroom);
                    dorm.IsAirCondiditioner = Helpers.ConvertByteToVisibility(aircon);
                    dorm.IsWaterHeater = Helpers.ConvertByteToVisibility(waterheater);
                    dorm.Quality = quality;
                    dorm.Size = size;

                    listDorm.Add(dorm);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading List Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                rd.Close();
                CloseConnection();
            }

            return listDorm;
        }
    }
}


       
