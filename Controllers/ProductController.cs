using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VegetableWebSite.Models;

namespace VegetableWebSite.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        ApplicationDbContext myDataBase = new ApplicationDbContext();

        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrEmpty(some_string);
        }

        [Authorize]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get_Product()
        {
            return Ok(myDataBase.Products);
        }
        [Authorize]

        [HttpGet]//הצגת 
        public IHttpActionResult Get_Product(long id)
        {
            Products Product_tem = myDataBase.Products.Find(id);
            if (Product_tem == null)
            {
                return NotFound();
            }
            return Ok(Product_tem);
        }
        [Authorize]

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateProduct(Products newOne)
        {
            if (!validationIsOk(newOne.productName) || !validationIsOk(newOne.marketPrice.ToString()) || !validationIsOk(newOne.customerPrice.ToString())) { return BadRequest(); }
            myDataBase.Products.Add(newOne);
            myDataBase.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = newOne.Id }, newOne);
        }
        [Authorize]
        [HttpPut]
        public IHttpActionResult Update_Product(long id, Products Product)
        {
            if (!validationIsOk(Product.amount.ToString())) { return BadRequest(); }

            //if (!validationIsOk(Product.) || !validationIsOk(Product.Customer_Price.ToString()) || !validationIsOk(Product.Market_Price.ToString())) { return BadRequest(); }
            Products ProductObj = myDataBase.Products.Find(id);
            if (ProductObj == null) { return NotFound(); }
          /*  ProductObj.marketPrice = Product.marketPrice;
            ProductObj.productName = Product.productName;
            ProductObj.customerPrice = Product.customerPrice;*/
            ProductObj.amount = ProductObj.amount - Product.amount;
            myDataBase.SaveChanges();
            return Ok("Product updeted sucssesfully");
        }
        /* [HttpPut]//עריכה
         public IHttpActionResult Update_Product(long id, Products Product)
         {
             if (!validationIsOk(Product.productName) || !validationIsOk(Product.marketPrice.ToString()) || !validationIsOk(Product.customerPrice.ToString())) { return BadRequest(); }

             //if (!validationIsOk(Product.) || !validationIsOk(Product.Customer_Price.ToString()) || !validationIsOk(Product.Market_Price.ToString())) { return BadRequest(); }
             Products ProductObj = myDataBase.Products.Find(id);
             if (ProductObj == null) { return NotFound(); }
             ProductObj.marketPrice = Product.marketPrice;
             ProductObj.productName = Product.productName;
             ProductObj.customerPrice = Product.customerPrice;
             ProductObj.amount = Product.amount;
             myDataBase.SaveChanges();
             return Ok("Product updeted sucssesfully");
         }

         /*[HttpDelete]//מחיקה
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
         }*/
    }
}
