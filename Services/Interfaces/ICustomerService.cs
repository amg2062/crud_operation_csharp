using API_project.Model;
namespace API_project.Services.Interfaces
{
    public interface ICustomerService
    {

        List<string> GetCustomers();


        Customer GetCustomerById(string id);

        //
        // Added CRUD methods signatures
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
        







        // Joined query for getting products by customer
        // IEnumerable<ProductCustomerDto> GetProductsByCustomer(string customerId);
    }
    //

}

