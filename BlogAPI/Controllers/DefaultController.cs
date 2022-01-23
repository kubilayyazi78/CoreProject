using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.DataAccessLayer;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult List()
        {
            using var context = new Context();
            var values = context.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            using var context = new Context();
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee ==null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            context.Remove(employee);
            context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            using var context = new Context();
            var emp = context.Find<Employee>(employee.Id);
            if (emp==null)
            {
                return NotFound();
            }

            emp.Name = employee.Name;
            context.Update(emp);
            context.SaveChanges();
            return Ok();
        }

    }
}
