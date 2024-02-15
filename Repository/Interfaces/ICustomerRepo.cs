using API_project.Model;

namespace API_project.Repository.Interfaces
{
    public interface ICustomerRepo
    {
        List<string> GetCustomer();

        Customer GetCustomerById(string id);

        //

        // List<int> DeleteCustomer(string id);

        // List <int> UpdateCustomer(Customer customer);

        //List <int> CreateCustomer(Customer customer);

        //

        Customer CreateCustomer(Customer customer);
        
        bool DeleteCustomer(string id);
        Customer UpdateCustomer(Customer customer);

        // Joined query for getting products by customer
        //X  IEnumerable<ProductCustomerDto> GetProductsByCustomer(string customerId);

    }
}
