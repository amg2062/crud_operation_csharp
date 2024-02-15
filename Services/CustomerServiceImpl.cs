using API_project.Model;
using API_project.Repository;
using API_project.Repository.Interfaces;
using API_project.Services.Interfaces;

namespace API_project.Services
{
    public class CustomerServiceImpl: ICustomerService
    {

        ICustomerRepo _customerRepo;
        public CustomerServiceImpl(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
       public  List<string> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(string id)
        {
            return _customerRepo.GetCustomerById(id);
        }


        //
        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepo.CreateCustomer(customer);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            return _customerRepo.UpdateCustomer(customer);
        }


        public void DeleteCustomer(string id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        





        // Implement joined query for getting products by customer
        // public IEnumerable<ProductCustomerDto> GetProductsByCustomer(string customerId)
        // {
        //     return _customerRepo.GetProductsByCustomer(customerId);
        // }
        //
    }
}
