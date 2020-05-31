using System;
using System.Linq;
using System.Web.Http;
using ApiServices.Models;

namespace ApiServices.Controllers
{
    [RoutePrefix("Api/Employee")]
    public class EmployeeAPIController : ApiController
    {

        ApiEntities apiEntities = new ApiEntities();

        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IQueryable<EmployeeDetails> GetEmployeeDetails()
        {
            try
            {
                return apiEntities.EmployeeDetails;
            }

            catch(Exception e)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("GetEmployeeDetailsById")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            try 
            {

                employeeDetails = apiEntities.EmployeeDetails.Find(id);
                if (employeeDetails == null) return NotFound();

            }

            catch(Exception)
            {
                throw;
            }

            return Ok(employeeDetails);
        }

        [HttpPost]
        [Route("InsertEmployeeDetails")]
        public IHttpActionResult PostEmaployee(EmployeeDetails data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                apiEntities.EmployeeDetails.Add(data);
                apiEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(data);
        }


        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IHttpActionResult PutEmaployeeMaster(EmployeeDetails employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                EmployeeDetails objEmp = new EmployeeDetails();
                objEmp = apiEntities.EmployeeDetails.Find(employee.EmployeeId);
                if (objEmp != null)
                {
                    objEmp.EmployeeName = employee.EmployeeName;
                    objEmp.Adresse = employee.Adresse;
                    objEmp.EmailId = employee.EmailId;
                    objEmp.DateOfBirth = employee.DateOfBirth;
                    objEmp.Gender = employee.Gender;
                    objEmp.PinCode = employee.PinCode;

                }
                int i = this.apiEntities.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            EmployeeDetails emaployee = apiEntities.EmployeeDetails.Find(id);
            if (emaployee == null)
            {
                return NotFound();
            }

            apiEntities.EmployeeDetails.Remove(emaployee);
            apiEntities.SaveChanges();

            return Ok(emaployee);
        }


    }
}
