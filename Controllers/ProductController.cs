using Microsoft.AspNetCore.Mvc;
using RabitMqProductAPI.Models;
using RabitMqProductAPI.RabitMQ;
using RabitMqProductAPI.Services;
namespace RabitMqProductAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase{
        private readonly IProductService _productService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public ProductController(IProductService productService, IRabitMQProducer rabitMQProducer)
        {
            this._productService=productService;
            this._rabitMQProducer=rabitMQProducer;
        }
        [HttpGet("productlist")]
        public IEnumerable<Product> ProductList(){
            var productList = _productService.GetProductList();
            return productList;
        }

        [HttpGet("getproductbyid")]
        public Product GetProductById(int Id){
            return _productService.GetProductById(Id);
        }

        [HttpPost("addproduct")]
        public Product AddProduct(Product product){
            var productData = _productService.AddProduct(product);
            _rabitMQProducer.SendProductMessage(productData);
            return productData;
        }

        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product){
            return _productService.UpdateProduct(product);
        }

        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id){
            return _productService.DeleteProduct(Id);
        }
    }
}