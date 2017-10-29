using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VegetableWebSite.Models;


namespace VegetableWebSite.Controllers
{

    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        ApplicationDbContext myDataBase = new ApplicationDbContext();
        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrWhiteSpace(some_string);
        }
        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateProduct(Products newOne)
        {
            if (!validationIsOk(newOne.productPic) ||
                !validationIsOk(newOne.productName) ||
                !validationIsOk(newOne.customerPrice.ToString()) ||
                !validationIsOk(newOne.marketPrice.ToString()) ||
                !validationIsOk(newOne.amount.ToString()))
            { return BadRequest(); }
            myDataBase.Products.Add(newOne);
            myDataBase.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = newOne.Id }, newOne);
        }
        [Authorize]
        [HttpPatch]
        public IHttpActionResult Update_Product(long Id, Products Product)
        {
            if (!validationIsOk(Product.productPic) ||
                !validationIsOk(Product.productName) ||
                !validationIsOk(Product.customerPrice.ToString()) ||
                !validationIsOk(Product.marketPrice.ToString()) ||
                !validationIsOk(Product.amount.ToString()))
            {
                return BadRequest();
            }
            Products ProductObj = myDataBase.Products.Find(Id);
            if (ProductObj == null) { return NotFound(); }
            ProductObj.marketPrice = Product.marketPrice;
            ProductObj.productName = Product.productName;
            ProductObj.customerPrice = Product.customerPrice;
            ProductObj.amount = Product.amount;
            ProductObj.productPic = Product.productPic;
            myDataBase.SaveChanges();
            return Ok("Product updeted sucssesfully");
        }
        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteProduct(long id)
        {
            Products ProductObj = myDataBase.Products.Find(id);
            if (ProductObj == null)
            {
                return NotFound();
            }
            myDataBase.Products.Remove(ProductObj);
            myDataBase.SaveChanges();
            return Ok(ProductObj);
        }
        [Authorize]
        [HttpPut]
        public IHttpActionResult Update_Order(long id, Orders newOne)
        {
            if (!validationIsOk(newOne.OrderPrice.ToString()) || !validationIsOk(newOne.ProductId.ToString()) || !validationIsOk(newOne.UserEmail.ToString())) { return BadRequest(); }
            Orders OrdersObj = myDataBase.Orders.Find(id);
            if (OrdersObj == null) { return NotFound(); }
            OrdersObj.OrderPrice = newOne.OrderPrice;
            myDataBase.SaveChanges();
            return Ok(HttpStatusCode.Created);
        }
    }
}
