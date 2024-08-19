using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyContacts
{
    class ContactsRepository : IContactsRepository
    {

        private string connectionString = "Data Source=.;Initial Catalog=Contacts;Integrated Security=true;";
        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "DELETE FROM MyContacts WHERE id=@id;";
                SqlCommand command = new SqlCommand(query,connection);

                command.Parameters.AddWithValue("@id", contactId);
                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string name, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "INSERT INTO MyContacts (name,age,email,mobile,address) VALUES (@name,@age,@email,@mobile,@address)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@address", address);

                connection.Open();
                command.ExecuteNonQuery();


                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SelecteAll()
        {
            string query = "SELECT * FROM MyContacts";
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int contactId)
        {
            string query = "SELECT * FROM MyContacts WHERE id=" + contactId;
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactId, string name, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string query = "UPDATE MyContacts SET name=@name,age=@age, email=@email, mobile=@mobile, address=@address  WHERE id=@id;";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id",contactId);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@address", address);

                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
