using MySql.Data.MySqlClient;

namespace Application.Database
{
public class ProfilesTable
    {
        private readonly DB db;

        public ProfilesTable(DB db) => this.db = db;

        public ProfilesTable(string server, int port, string username, string password, string database)
        {
            db = new DB(server, port, username, password, database);
        }

        public bool CheckExistUser(int userId)
        {
            string query = $"SELECT COUNT(*) FROM profiles WHERE user_id = {userId}";
            int count = Convert.ToInt32(db.ExecuteScalar(query));
            if (count == 0)
            {
                return false;
            }
            else { return true; }
        }
        public void SetFirstName(int userId, string firstName)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, first_name) VALUES ({userId}, '{firstName}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET first_name = '{firstName}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetLastName(int userId, string lastName)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, last_name) VALUES ({userId}, '{lastName}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET last_name = '{lastName}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetPatronymic(int userId, string patronymic)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, patronymic) VALUES ({userId}, '{patronymic}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET patronymic = '{patronymic}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetLocation(int userId, string location)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, location) VALUES ({userId}, '{location}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET location = '{location}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetAge(int userId, int age)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, age) VALUES ({userId}, '{age}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET age = '{age}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetInterests(int userId, string interests)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, interests) VALUES ({userId}, '{interests}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET interests = '{interests}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetPhoto(int userId, byte[] photo)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, photo) VALUES ({userId}, @photo)";
                using var command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@photo", photo);
                db.OpenConnection();
                command.ExecuteNonQuery();
                db.CloseConnection();
            }
            else
            {
                query = $"UPDATE profiles SET photo = @photo WHERE user_id = {userId}";
                using var command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@photo", photo);
                db.OpenConnection();
                command.ExecuteNonQuery();
                db.CloseConnection();
            }
        }

        public void SetGender(int userId, bool gender) //true - мужик ; false - понятно
        {
            int gen = 0;
            if (gender)
            {
                gen = 1;
            }
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, gender) VALUES ({userId}, '{gen}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET gender = '{gen}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public string GetFirstName(int userId)
        {
            string query = $"SELECT first_name FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string firstName = string.Empty;
            if (reader != null && reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("first_name")))
                {
                    firstName = reader.GetString("first_name");
                }
            }
            DB.CloseDataReader(reader);
            return firstName;
        }

        public string GetLastName(int userId)
        {
            string query = $"SELECT last_name FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string lastName = string.Empty;
            if (reader != null && reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("last_name")))
                {
                    lastName = reader.GetString("last_name");
                }
            }
            DB.CloseDataReader(reader);
            return lastName;
        }

        public string GetPatronymic(int userId)
        {
            string query = $"SELECT patronymic FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string patronymic = string.Empty;
            if (reader != null && reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("patronymic")))
                {
                    patronymic = reader.GetString("patronymic");
                }
            }
            DB.CloseDataReader(reader);
            return patronymic;
        }

        public string GetInterests(int userId)
        {
            string query = $"SELECT interests FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string interests = string.Empty;
            if (reader != null && reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("interests")))
                {
                    interests = reader.GetString("interests");
                }
            }
            DB.CloseDataReader(reader);
            return interests;
        }

        public string GetLocation(int userId)
        {
            string query = $"SELECT location FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string location = string.Empty;
            if (reader != null && reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("location")))
                {
                    location = reader.GetString("location");
                }
            }
            DB.CloseDataReader(reader);
            return location;
        }

        public int GetAge(int userId)
        {
            string query = $"SELECT age FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string ageString = string.Empty;
            if (reader != null && reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("age")))
                {
                    ageString = reader.GetString("age");
                }
            }
            DB.CloseDataReader(reader);

            int age = -1;
            if (!string.IsNullOrEmpty(ageString))
            {
                int.TryParse(ageString, out age);
            }

            return age;
        }

        public byte[] GetPhoto(int userId)
        {
            string query = $"SELECT photo FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            byte[] photoData = null;
            if (reader != null && reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("photo")))
                {
                    photoData = (byte[])reader["photo"];
                }
            }
            DB.CloseDataReader(reader);
            return photoData;
        }

        public bool GetGender(int userId)
        {
            string query = $"SELECT gender FROM profiles WHERE user_id = {userId}";
            using var reader = db.ExecuteReader(query);
            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("gender")))
                {
                    return reader.GetBoolean("gender");
                }
                return false;
            }
            return false;
        }
    }
}
