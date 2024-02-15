using API_project.Model;
using API_project.Repository.Interfaces;
using System.Data.SqlClient;

namespace API_project.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        readonly string connectionString = "";
        public CustomerRepo() {
            connectionString = "Data Source=APINP-ELPTXZHFJ\\SQLEXPRESS02;Initial Catalog=northwind;User ID=tap2023;Password=tap2023;Encrypt=False";
        }


        public Customer GetCustomerById(string id)
        {
            Customer c = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"Select * from Customers where CustomerID='{id}'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    c = new Customer();
                    c.CustomerId = dr["CustomerID"].ToString();
                    c.CompanyName = dr["CompanyName"].ToString();
                    c.ContactName = dr["ContactName"].ToString();

                }


            }
            return c;
        }

        //
        public Customer CreateCustomer(Customer customer)
        {
            Customer createdCustomer = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (CustomerID, CompanyName, ContactName) VALUES (@CustomerID, @CompanyName, @ContactName); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
                    cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        customer.CustomerId = result.ToString();
                        createdCustomer = customer;
                    }
                }
            }
            return createdCustomer;
        }

        // Method to update an existing customer
        public Customer UpdateCustomer(Customer customer)
        {
            Customer updatedCustomer = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName WHERE CustomerID = @CustomerID;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
                    cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        updatedCustomer = GetCustomerById(customer.CustomerId);
                    }
                }
            }
            return updatedCustomer;
        }

        // Method to delete a customer by ID
        public bool DeleteCustomer(string id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Update the CustomerID column in Orders table to null
                string updateOrdersQuery = "UPDATE Orders SET CustomerID = NULL WHERE CustomerID = @CustomerId";
                using (SqlCommand updateOrdersCmd = new SqlCommand(updateOrdersQuery, conn))
                {
                    updateOrdersCmd.Parameters.AddWithValue("@CustomerId", id);
                    updateOrdersCmd.ExecuteNonQuery();
                }

                // Delete the customer
                string deleteCustomerQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerId";
                using (SqlCommand deleteCustomerCmd = new SqlCommand(deleteCustomerQuery, conn))
                {
                    deleteCustomerCmd.Parameters.AddWithValue("@CustomerId", id);
                    int rowsAffected = deleteCustomerCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }



        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString()
                            });
                        }
                    }
                }
            }
            return customers;
        }

        public List<string> GetCustomer()
        {
            throw new NotImplementedException();
        }

   



        //


    }
}
