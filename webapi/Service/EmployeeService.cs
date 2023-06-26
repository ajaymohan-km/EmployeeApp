using webapi.Model;
using webapi.Repository;

namespace webapi.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepository) {

            _employeeRepository= employeeRepository;

        }

        public Response InsertEmployee(EmployeeModel model)
        {
            Response response = new Response();
            int result = _employeeRepository.InsertEmployee(model);
            if(result == 0)
            {
                response.Status = false;
                response.Message = "Insertion failed";
                response.Data = null;
            }
            else
            {
                response.Status = true;
                response.Message = "Insertion Success";
                response.Data = result;
            }
            return response;
        }
    }
}
