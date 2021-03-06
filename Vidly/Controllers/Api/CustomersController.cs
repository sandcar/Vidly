﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {

            _context = new ApplicationDbContext();

        }

        // Get/Aoi/Customers: Nota se quiser utilizar as 2 assinaturas na webapi, tenho que configurar as tabelas de root
        //public IHttpActionResult GetCustomers()
        //{
        //    var customerDtos = _context.Customers
        //        .Include(c => c.MemberShipType).ToList()
        //        .Select(Mapper.Map<Customer, CustomerDto>);

        //    return Ok(customerDtos);
        //}

        // Get/Aoi/Customers&query=
        public IHttpActionResult GetCustomers(string query = null)
        {

            var customersQuery = _context.Customers.Include(c => c.MemberShipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery.ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);

        }

        // Get/Aoi/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST/Aoi/Customers/
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            // atribuir ID;
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT/Aoi/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }


        // DELETE/Aoi/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}
