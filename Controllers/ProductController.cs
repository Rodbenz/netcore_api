using Microsoft.AspNetCore.Mvc;

namespace netcore_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<string>>GetProduct(){
        var product = new List<string>();
        product.Add("NextJs");
        product.Add("ReactJs");
        product.Add("VueJs");

        return Ok(product);
    }
    [HttpGet("{id}")]
    public ActionResult GetProductById(int id)
    {
        return Ok(new {productid = id, name = "react"});
    }
    
    [HttpGet("search/{id}/{category}")]
    public ActionResult GetSearchProdoctById(int id, string category)
    {
        return Ok(new {productid = id, name = "react", category = category});;
    }
    [HttpGet("query/product")]// .../?id=11&category=web
    public ActionResult QueryProductById([FromQuery] int id, [FromQuery] string category)
    {
        return Ok(new {productid = id, name = "react", category = category});;
    }
    [HttpGet("queryv2/product/{user}")]// Product/queryv2/product/rod?id=111&category=web
    public ActionResult QueryV2ProductById([FromQuery] int id, [FromQuery] string category, string user)
    {
        return Ok(new {productid = id, name = "react", category = category, user = user});
    }
    [HttpPost]
    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        return Ok(product);
    }
    [HttpPost("add")]
    public ActionResult<Product> AddProductV2([FromForm] Product product)
    {
        return Ok(product);
    }
    public class Product {
        public int id {get; set;}
        public string name {get; set;}
        public int price {get; set;}
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, [FromBody] Product product)
    {
        if(id != product.id){
            return BadRequest();
        }

        if(id != 222){
            return NotFound();
        }
        
        return Ok(product);
    }
    [HttpPut("updateProduct/{id}")]
    public ActionResult UpdateProductV2(int id, [FromForm] Product product)
    {
        if(id != product.id){
            return BadRequest();
        }

        if(id != 222){
            return NotFound();
        }
        
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProductById(int id)
    {
        if(id != 1111){
            return NotFound();
        }
        return NoContent();
    }
    

}
