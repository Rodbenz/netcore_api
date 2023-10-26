using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace netcore_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvinceController : ControllerBase
{
    private readonly ILogger<ProvinceController> _logger;
    private readonly MyDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public ProvinceController(ILogger<ProvinceController> logger, MyDbContext dbContext, IConfiguration configuration)
    {
        _logger = logger;
        _dbContext = dbContext;
        _configuration = configuration;
    }
    [HttpGet("mas/province")]
    public IEnumerable<PROVINCE> Get()
    {
        return _dbContext.Province.ToList();
    }
    [HttpGet("mas/{provinc_id}")]
    public ActionResult<PROVINCE> GetMas(int provinc_id)
    {
        return _dbContext.Province.FirstOrDefault(province => province.ID == provinc_id)!;
    }

    [HttpPut("{provinc_id}")]
    public IActionResult UpdateProvinceNameEn(int provinc_id, [FromForm] UpdateProvince UpdateProvince)
    {
        var existingProvince = _dbContext.Province.Find(provinc_id);
        if (existingProvince == null)
        {
            return NotFound();
        }

        // Update the existing product with the new values
        existingProvince.NAMEEN = UpdateProvince.NAMENE;

        _dbContext.SaveChanges();

        return Ok(existingProvince);
    }

    public class UpdateProvince
    {
        public string NAMENE { get; set; }
    }


}
