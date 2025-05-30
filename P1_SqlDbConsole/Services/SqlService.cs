
using Microsoft.Data.SqlClient;
using SqlDbConsole.Interfaces;
using SqlDbConsole.Structs;

namespace SqlDbConsole.Services;



// class tempeltae hai object ka 

// object hamesha inheritance leta hai class se
// base class 
public class SqlService : ISqlService
{
    private readonly string _connectionString;     // feild   // encapsulation // class ki state ko store kertay hai 

    // constructorr
    public SqlService(string connectionStringParam)
    {
        _connectionString = connectionStringParam;
    }

    public void CreateUser(string username, string email, string password)
    {
        try
        {
            Console.WriteLine("Trying to connect Db !");

            using SqlConnection connection = new(_connectionString);  // intiliazing a connection  and creatimng a new instance of Sql Connection 

            connection.Open();

            string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";

            using SqlCommand command = new(query, connection);

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("User Saved Succesfully !");
            }
            else
            {
                Console.WriteLine("Query Not Executed");
            }



        }
        catch (Exception error)
        {

            Console.WriteLine(error.Message);
        }
    }

    public void FindUser(string email)
    {

        try
        {
            // string mewooo = $"meowowo ${connectionString}";

            // string query = $"SELECT FROM Users WHERE Email = ${email}";

            string query = "SELECT * FROM Users WHERE Email = @Email";

            using SqlConnection connection = new(_connectionString);

            connection.Open();

            using SqlCommand command = new(query, connection);

            command.Parameters.AddWithValue("@Email", email);

            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                Console.WriteLine("User Found! Below are the Details of User");
                Console.WriteLine(reader["Username"].ToString());
                Console.WriteLine(reader["Email"].ToString());
                Console.WriteLine(reader["Password"].ToString());

            }
            else
            {
                Console.WriteLine("No User Found With this Email!");
            }



        }
        catch (Exception error)
        {

            Console.WriteLine(error.Message);
        }


    }
    // create a void function in which we are finding user by its email and then delete if found otherwise say "no user Found!
    public void DeleteUser(string email)
    {

        try
        {
            // connect to db 
            SqlConnection connection = new(_connectionString);
            var query = "DELETE FROM Users WHERE Email = @Email";  // we dont take email directly from params because to prevent sql injection 


            connection.Open();

            SqlCommand command = new(query, connection);

            command.Parameters.AddWithValue("@Email", email);   // malicious query ka security check

            int rowsDeleted = command.ExecuteNonQuery();    // return rows deleted

            if (rowsDeleted > 0)
            {
                Console.WriteLine("User Deleted Succesfully!");
            }
            else
            {
                Console.WriteLine("User Not Found!");
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

    }

    public void EditUserAccount(string email, string username, string password)
    {

        try
        {
            /// find user and update username and password


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public void EditUsername (string Email , string Username){
            Console.WriteLine($"{Email + Username }");
    }

    public void ForgotPassword(string Email)
    {
        throw new NotImplementedException();
    }

    public void ForgotPassword(string Email, string newPass)
    {
        throw new NotImplementedException();
    }
}
