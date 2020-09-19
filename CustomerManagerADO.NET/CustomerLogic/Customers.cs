using ConsoleTables;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CustomerManagerADO.NET.CustomerLogic
{
    class Customers
    {
        private SQLConnect connect;

        // Create new Customer
        public void Create(Customer customer)
        {
            // Check Email is valid
            bool validateEmailAddress = ValidateEmail(customer.Email);

            if (validateEmailAddress == false)
            {
                Console.WriteLine("Email address is invalid");
            }

            // Check if customer already exists
            connect = new SQLConnect();
            string customerExitsQuery = "SELECT FirstName FROM CustomerDetails WHERE FirstName =" + "'" + customer.FirstName + "'";
            SqlDataAdapter da = new SqlDataAdapter(customerExitsQuery, connect.OpenConnection());
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count >= 1)
            {
                Console.WriteLine("Customer already exists");
            }


            // Add new customer to database
            if (table.Rows.Count == 0 && validateEmailAddress == true)
            {
                string query = "INSERT INTO CustomerDetails " +
                        "(FirstName, MiddleName, LastName, PhoneNumber, Address, Email, CreationDate)" +
                        "VALUES (@FirstName, @MiddleName, @LastName, @PhoneNumber, @Address, @Email, @CreationDate)";

                SqlCommand cmd = new SqlCommand(query, connect.OpenConnection());

                cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = customer.FirstName;
                cmd.Parameters.Add("@Middlename", SqlDbType.VarChar).Value = customer.MiddleName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = customer.LastName;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = customer.PhoneNumber;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = customer.Address;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customer.Email;
                cmd.Parameters.Add("@CreationDate", SqlDbType.NVarChar).Value = customer.DateCreated;

                cmd.ExecuteNonQuery();
                connect.CloseConnection();
            }
        }

        // Delete Customer
        public void Delete(string firstName)
        {
           

            connect = new SQLConnect();
            string query = "DELETE FROM CustomerDetails WHERE FirstName =" + "'" + firstName + "'";
            SqlCommand cmd = new SqlCommand(query, connect.OpenConnection());
            cmd.ExecuteNonQuery();
            connect.CloseConnection();
        }

        // Update Customer Details
        public void Edit(Customer customer)
        {
            connect = new SQLConnect();
            string query = "UPDATE CustomerDetails SET " +
                "FirstName =" + "'" + customer.FirstName + "'," +
                "MiddleName =" + "'" + customer.MiddleName + "'," +
                "LastName =" + "'" + customer.LastName + "'," +
                "PhoneNumber =" + "'" + customer.PhoneNumber + "'," +
                "Address =" + "'" + customer.Address + "'," +
                "Email =" + "'" + customer.Email + "'," +
                "CreationDate =" + "'" + customer.DateCreated + "'" +
                "WHERE FirstName =" + "'" + customer.FirstName + "'"
                ;

            SqlCommand cmd = new SqlCommand(query, connect.OpenConnection());
            cmd.ExecuteNonQuery();
            
            connect.CloseConnection();

        }

        // Validate Email Address
        public bool ValidateEmail(string customerEmail)
        {
            return Regex.IsMatch(customerEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        // Print Customer table
        public void PrintCustomers()
        {
            connect = new SQLConnect();

            string query = "SELECT * FROM CustomerDetails";
            SqlCommand cmd = new SqlCommand(query, connect.OpenConnection());

            DataTable dataTable = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(dataTable);

            var table = new ConsoleTable("Id", "Firstname", "Middlename", "Lastname", "PhoneNumber", "Address", "Email", "DateCreated");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                table.AddRow(dataRow[0], dataRow[1], dataRow[2], dataRow[3], dataRow[4], dataRow[5], dataRow[6], dataRow[7]);
            }
            Console.WriteLine(table);
            connect.CloseConnection();
        }
    }
}
