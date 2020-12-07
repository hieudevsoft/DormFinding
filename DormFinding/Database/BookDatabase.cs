using DormFinding.Models;
using DormFinding.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormFinding.Database
{
    public static class BookDatabase
    {
        //Insert item
        public static Boolean Insert(BookDorm bookDorm)
        {

            Mydatabase.sql = $"insert into {Helpers.tbBookDorm}({Helpers.colEmailOwnerBookDorm},{Helpers.colEmailUserBookDorm},{Helpers.colIdDormBookDorm},{Helpers.colStateBookDorm}) values(@EmailOwner,@EmailUser,@Id,@State);";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@EmailOwner", bookDorm.EmailOwner);
                Mydatabase.cmd.Parameters.AddWithValue("@EmailUser", bookDorm.EmailUser);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", bookDorm.IdDorm);
                Mydatabase.cmd.Parameters.AddWithValue("@State", bookDorm.StateDorm);
                Mydatabase.cmd.ExecuteScalar();
                return true;

            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Insert Book Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Delete item with Id Dorm
        public static void DeleteByIdDorm(int id)
        {

            Mydatabase.sql = $"delete from {Helpers.tbBookDorm} where {Helpers.colIdDormBookDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                Mydatabase.cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Delete tbBookDorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update item
        public static void Update(BookDorm bookDorm)
        {
            Mydatabase.sql = $"update {Helpers.tbBookDorm} SET {Helpers.colEmailOwnerBookDorm}=@EmailOwner" +
                $", {Helpers.colEmailUserBookDorm} = @EmailUser" +
                $", {Helpers.colIdDormBookDorm}=@Id" +
                $", {Helpers.colStateBookDorm}=@State" +
                $" where {Helpers.colEmailOwnerBookDorm}=@EmailOwner and {Helpers.colEmailUserBookDorm} = @EmailUser and  {Helpers.colIdDormBookDorm}=@Id;";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@EmailOwner", bookDorm.EmailOwner);
                Mydatabase.cmd.Parameters.AddWithValue("@EmailUser", bookDorm.EmailUser);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", bookDorm.IdDorm);
                Mydatabase.cmd.Parameters.AddWithValue("@State", bookDorm.StateDorm);
                Mydatabase.cmd.ExecuteScalar();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update Book Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Get item
        public static BookDorm GetItem(BookDorm bookDorm)
        {
            BookDorm dorm = new BookDorm();
            Mydatabase.sql = $"select * from {Helpers.tbBookDorm} where {Helpers.colEmailOwnerBookDorm} = @EmailOwner and {Helpers.colEmailUserBookDorm}=@EmailUser and {Helpers.colIdDormBookDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@EmailOwner", bookDorm.EmailOwner);
                Mydatabase.cmd.Parameters.AddWithValue("@EmailUser", bookDorm.EmailUser);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", bookDorm.IdDorm);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                if (Mydatabase.rd.Read())
                {
                    dorm.EmailOwner = Mydatabase.rd.GetString(0);
                    dorm.EmailUser = Mydatabase.rd.GetString(1);
                    dorm.IdDorm = Mydatabase.rd.GetInt32(2);
                    dorm.StateDorm = Mydatabase.rd.GetInt16(3);    
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Error get infor Owner Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                Mydatabase.CloseConnection();
            }
            return dorm;
        }

        //Get All User booking waiting
        public static List<BookDorm> GetAllWattingBook(string email)
        {
            List<BookDorm> list = new List<BookDorm>();
            Mydatabase.sql = $"select * from {Helpers.tbBookDorm} where {Helpers.colEmailOwnerBookDorm} = @Email and {Helpers.colStateBookDorm} = @State";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@State", 1);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                while (Mydatabase.rd.Read())
                {
                    BookDorm dorm = new BookDorm();
                    dorm.EmailOwner = Mydatabase.rd.GetString(0);
                    dorm.EmailUser = Mydatabase.rd.GetString(1);
                    dorm.IdDorm = Mydatabase.rd.GetInt32(2);
                    dorm.StateDorm = Mydatabase.rd.GetInt16(3);
                    
                    list.Add(dorm);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error get All List Owner Book Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                Mydatabase.CloseConnection();
            }
            return list;
        }

        //Get user Booked Dorm
        public static string GetEmailBookDorm(string email, int id)
        {
            Mydatabase.sql = $"select {Helpers.colEmailUserBookDorm} from {Helpers.tbBookDorm} where {Helpers.colEmailOwnerBookDorm} = @Email and {Helpers.colStateBookDorm} = @State and {Helpers.colIdDormBookDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@State", 2);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                if (Mydatabase.rd.Read())
                {
                    return Mydatabase.rd.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error getUserBookDorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return "No";
            }
            finally
            {
                Mydatabase.CloseConnection();
            }
            return "No";
        }

        //Update Dorm When Booked
        public static bool UpdateDormWhenBook(string email, string emailUser, int id,int state)
        {
            Mydatabase.sql = $"update {Helpers.tbBookDorm} set {Helpers.colStateBookDorm} = @State where {Helpers.colEmailOwnerBookDorm} = @Email and {Helpers.colEmailUserBookDorm} = @EmailUser and {Helpers.colIdDormBookDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@State", state);
                Mydatabase.cmd.Parameters.AddWithValue("@EmailUser", emailUser);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);
                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error updateDormWhenBook " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update Dorm When have user Booked
        public static bool DeleteDormWhenBook(string email, string emailUser, int id)
        {
            Mydatabase.sql = $"delete from {Helpers.tbBookDorm} where {Helpers.colEmailOwnerBookDorm} = @Email and {Helpers.colEmailUserBookDorm} <> @EmailUser and {Helpers.colIdDormBookDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@State", 0);
                Mydatabase.cmd.Parameters.AddWithValue("@EmailUser", emailUser);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);
                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error deleteDormWhenBook " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }
    }
}
