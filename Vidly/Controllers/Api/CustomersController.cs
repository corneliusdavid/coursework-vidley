using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            else
                return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDTO.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customerDTO.Id), customerDTO);
            }
        }

        // POST /api/customers/1
        [HttpPost]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            else
            {
                var OrigCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (OrigCustomer == null)
                    return NotFound();
                else
                {
                    Mapper.Map(customerDTO, OrigCustomer);

                    _context.SaveChanges();

                    return Ok(customerDTO);
                }
            }
        }

        // DELETE /api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var OrigCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (OrigCustomer == null)
                return NotFound();
            else
            {
                _context.Customers.Remove(OrigCustomer);
                _context.SaveChanges();

                return Ok(Mapper.Map<Customer, CustomerDTO>(OrigCustomer));
            }
        }
    }
}
