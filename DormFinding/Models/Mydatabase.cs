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
                rd.Close();
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
                rd.Close();
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

        public static bool InsertDorm(DormDb dorm)
        {

            String sql = $"insert into {Helpers.tbDorm}(" +
                $"{Helpers.colOwnerDorm}," +
                $"{Helpers.colAdressDorm}," +
                $"{Helpers.colDescriptionDorm}," +
                $"{Helpers.colPriceDorm}," +
                $"{Helpers.colSaleDorm}," +
                $"{Helpers.colImageDorm}," +
                $"{Helpers.colCountDorm}," +
                $"{Helpers.colCountLikeDorm}," +
                $"{Helpers.colWifiDorm}," +
                $"{Helpers.colParkingDorm}," +
                $"{Helpers.colTelevisionDorm}," +
                $"{Helpers.colBathroomDorm}," +
                $"{Helpers.colAirconditionerDorm}," +
                $"{Helpers.colWaterHeaterDorm}," +
                $"{Helpers.colQualityDorm}," +
                $"{Helpers.colSizeDorm})" +
                $"values(" +
                $"@Owner," +
                $"@Address," +
                $"@Description," +
                $"@Price," +
                $"@Sale," +
                $"@Image," +
                $"@Count," +
                $"@CountLike," +
                $"@Wifi," +
                $"@Parking," +
                $"@Television," +
                $"@Bathroom," +
                $"@AirConditioner," +
                $"@WaterHeater," +
                $"@Quality," +
                $"@Size" +
                $");";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Owner", dorm.Owner);
                cmd.Parameters.AddWithValue("@Address", dorm.Address);
                cmd.Parameters.AddWithValue("@Description", dorm.Description);
                cmd.Parameters.AddWithValue("@Price", dorm.Price);
                cmd.Parameters.AddWithValue("@Sale", dorm.Sale);
                cmd.Parameters.AddWithValue("@Image", dorm.Image);
                cmd.Parameters.AddWithValue("@Count", dorm.Count);
                cmd.Parameters.AddWithValue("@CountLike", dorm.CountLike);
                cmd.Parameters.AddWithValue("@Wifi", dorm.IsWifi);
                cmd.Parameters.AddWithValue("@Parking", dorm.IsParking);
                cmd.Parameters.AddWithValue("@Television", dorm.IsTelevision);
                cmd.Parameters.AddWithValue("@Bathroom", dorm.IsBathroom);
                cmd.Parameters.AddWithValue("@AirConditioner", dorm.IsAirCondiditioner);
                cmd.Parameters.AddWithValue("@WaterHeater", dorm.IsWaterHeater);
                cmd.Parameters.AddWithValue("@Quality", dorm.Quality);
                cmd.Parameters.AddWithValue("@Size", dorm.Size);

                cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Insert Dorm Error " +e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void updateLikeDorm(Dorm dorm)
        {
            String sql = $"update {Helpers.tbDorm} SET {Helpers.colCountLikeDorm}=@Count where {Helpers.colIdDorm}=@Id;";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Count", dorm.CountLike);
                cmd.Parameters.AddWithValue("@Id", dorm.Id);

                cmd.ExecuteScalar();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                CloseConnection();
            }
        }
        public static List<Dorm> getAllListDorm()
        {
            string sql = $"select * from {Helpers.tbDorm}";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                rd = cmd.ExecuteReader();
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
        public static void InsertToTableOwnerDorm(string email, int idDorm)
        {

            String sql = $"insert into {Helpers.tbDormOwner}({Helpers.colEmailOwnerDorm},{Helpers.colIdOwnerDorm}) values(@Email,@Id);";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
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

            String sql = $"select {Helpers.colImageProfile},{Helpers.colNameProfile},{Helpers.colPhoneProfile},{Helpers.colEmailProfile}," +
                $"{Helpers.colAdressProfile}, {Helpers.colGenderProfile} " +
                $"from {Helpers.tbUserProfile},{Helpers.tbDormOwner} " +
                $"where {Helpers.colIdOwnerDorm} = @Id and {Helpers.colEmailOwnerDorm} = {Helpers.colEmailProfile};";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", idDorm);
                rd = cmd.ExecuteReader();
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

        public static Boolean InsertToOwnerLikeDorm(string email, int idDorm, byte like)
        {

            String sql = $"insert into {Helpers.tbOwnerLikeDorm}({Helpers.colEmailOwnerLikeDorm},{Helpers.colIdDormOwnerLikeDorm},{Helpers.colLikeOwnerLikeDorm}) values(@Email,@Id,@Like);";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Id", idDorm);
                cmd.Parameters.AddWithValue("@Like", like);
                cmd.ExecuteScalar();
                return true;

            }
            catch (Exception e)
            {
                return false;
                
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void updateOwnerLikeDorm(string email, int id,byte like)
        {
            String sql = $"update {Helpers.tbOwnerLikeDorm} SET {Helpers.colLikeOwnerLikeDorm}=@Like where {Helpers.colEmailOwnerLikeDorm}=@Email and {Helpers.colIdDormOwnerLikeDorm} = @Id;";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Like", like);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteScalar();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update Owner Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                CloseConnection();
            }
        }
        public static Boolean getStateLikeOfOwner(string email, int id)
        {
            String sql = $"select {Helpers.colLikeOwnerLikeDorm} from {Helpers.tbOwnerLikeDorm} where {Helpers.colEmailOwnerLikeDorm}=@Email and {Helpers.colIdDormOwnerLikeDorm} = @Id;";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Id", id);
                rd = cmd.ExecuteReader();
                if (rd.Read()) return rd.GetBoolean(0);


            }
            catch (Exception e)
            {
                MessageBox.Show("Error get State Owner Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                CloseConnection();
            }
            return false;
        }
        public static List<Dorm> getAllListDormOwnerLike(string email)
        {
            string sql = $"select * from {Helpers.tbOwnerLikeDorm},{Helpers.tbDorm} where {Helpers.colIdDormOwnerLikeDorm} = {Helpers.colIdDorm} and {Helpers.colLikeOwnerLikeDorm} = 1 and {Helpers.colEmailOwnerLikeDorm}=@Email;";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                OpenConnection();
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    
                    Dorm dorm = new Dorm();
                    int id = rd.GetInt32(3);
                    string owner = rd.GetString(4);
                    string address = rd.GetString(5);
                    string description = rd.GetString(6);
                    double price = rd.GetDouble(7);
                    double sale = rd.GetDouble(8);
                    
                    byte[] image;
                    if (rd.GetValue(9).ToString().Equals(""))
                    {
                        
                        dorm.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri($"../../images/icon_app.ico", UriKind.RelativeOrAbsolute));

                    }
                    else
                    {
                       
                        image = (byte[])rd.GetValue(9);
                       
                        dorm.Image = Helpers.ConvertByteToImageBitmap(image);
                    }
                    
                    int count = rd.GetInt32(10);
                    int countLike = rd.GetInt32(11);

                    byte wifi = Helpers.ConverBoolToByte(rd.GetBoolean(12));
                    
                    byte parking = Helpers.ConverBoolToByte(rd.GetBoolean(13));
                    
                    byte television = Helpers.ConverBoolToByte(rd.GetBoolean(14));
                    byte bathroom = Helpers.ConverBoolToByte(rd.GetBoolean(15));
                    byte aircon = Helpers.ConverBoolToByte(rd.GetBoolean(16));
                    byte waterheater = Helpers.ConverBoolToByte(rd.GetBoolean(17));

                    int quality = rd.GetInt16(18);
                    double size = rd.GetDouble(19);

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
                MessageBox.Show("Error loading List Dorm Owner " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                rd.Close();
                CloseConnection();
            }

            return listDorm;
        }
        public static Boolean InsertDataToBookDorm(BookDorm bookDorm)
        {

            String sql = $"insert into {Helpers.tbBookDorm}({Helpers.colEmailOwnerBookDorm},{Helpers.colEmailUserBookDorm},{Helpers.colIdDormBookDorm},{Helpers.colStateBookDorm}) values(@EmailOwner,@EmailUser,@Id,@State);";
            try
            {
                OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmailOwner", bookDorm.EmailOwner);
                cmd.Parameters.AddWithValue("@EmailUser", bookDorm.EmailUser);
                cmd.Parameters.AddWithValue("@Id", bookDorm.IdDorm);
                cmd.Parameters.AddWithValue("@State", bookDorm.StateDorm);
                cmd.ExecuteScalar();
                return true;

            }
            catch (Exception e)
            {
                //MessageBox.Show("Error Insert Book Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                CloseConnection();
            }
        }
        public static void updateBookDorm(BookDorm bookDorm)
        {
            String sql = $"update {Helpers.tbBookDorm} SET {Helpers.colEmailOwnerBookDorm}=@EmailOwner" +
                $", {Helpers.colEmailUserBookDorm} = @EmailUser" +
                $", {Helpers.colIdDormBookDorm}=@Id" +
                $", {Helpers.colStateBookDorm}=@State" +
                $", {Helpers.colCommentBookDorm}=@Comment" +
                $", {Helpers.colRatingBookDorm}=@Rating" +
                $" where {Helpers.colEmailOwnerBookDorm}=@EmailOwner and {Helpers.colEmailUserBookDorm} = @EmailUser and  {Helpers.colIdDormBookDorm}=@Id;";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmailOwner", bookDorm.EmailOwner);
                cmd.Parameters.AddWithValue("@EmailUser", bookDorm.EmailUser);
                cmd.Parameters.AddWithValue("@Id", bookDorm.IdDorm);
                cmd.Parameters.AddWithValue("@State", bookDorm.StateDorm);
                cmd.Parameters.AddWithValue("@Comment", bookDorm.CommentDorm);
                cmd.Parameters.AddWithValue("@Rating", bookDorm.RatingDorm);
                cmd.ExecuteScalar();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update Book Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                CloseConnection();
            }
        }
        public static BookDorm getInforBookDorm(BookDorm bookDorm)
        {
            BookDorm dorm = new BookDorm();
            String sql = $"select * from {Helpers.tbBookDorm} where {Helpers.colEmailOwnerBookDorm} = @EmailOwner and {Helpers.colEmailUserBookDorm}=@EmailUser and {Helpers.colIdDormBookDorm} = @Id";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmailOwner",bookDorm.EmailOwner);
                cmd.Parameters.AddWithValue("@EmailUser", bookDorm.EmailUser);
                cmd.Parameters.AddWithValue("@Id", bookDorm.IdDorm);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    dorm.EmailOwner = rd.GetString(0);
                    dorm.EmailUser = rd.GetString(1);
                    dorm.IdDorm = rd.GetInt32(2);
                    dorm.StateDorm = rd.GetInt16(3);
                    dorm.CommentDorm = rd.GetString(4);
                    dorm.RatingDorm = rd.GetInt16(5);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Error get infor Owner Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                CloseConnection();
            }
            return dorm;
        }

        public static List<BookDorm> getAllWattingBookDorm(string email)
        {
            List<BookDorm> list = new List<BookDorm>();
            String sql = $"select * from {Helpers.tbBookDorm} where {Helpers.colEmailOwnerBookDorm} = @Email and {Helpers.colStateBookDorm} = @State";

            try
            {
                OpenConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@State", 1);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    BookDorm dorm = new BookDorm();
                    dorm.EmailOwner = rd.GetString(0);
                    dorm.EmailUser = rd.GetString(1);
                    dorm.IdDorm = rd.GetInt32(2);
                    dorm.StateDorm = rd.GetInt16(3);
                    dorm.CommentDorm = rd.GetString(4);
                    dorm.RatingDorm = rd.GetInt16(5);
                    list.Add(dorm);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Error get All List Owner Book Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                CloseConnection();
            }
            return list;
        }
    }
}


       
