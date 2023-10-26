using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace netcore_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AmphurController : ControllerBase
{
    private readonly ILogger<AmphurController> _logger;
    private readonly MyDbContext _dbContext;

    public AmphurController(ILogger<AmphurController> logger, MyDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    [HttpGet("mas/amphur")]
    public IEnumerable<AMPHUR> Get()
    {
        return _dbContext.Amphurs.ToList();
    }
    [HttpGet("mas/{province_code}/{amphur_code}")]
    public ActionResult<AMPHUR> GetMas(string province_code, string amphur_code)
    {
        return _dbContext.Amphurs.FirstOrDefault(el => el.PROVINCE_CODE == province_code && el.AMPHUR_CODE == amphur_code)!;
    }
    [HttpGet("mas/query")]
    public ActionResult<AMPHUR> GetMasAmphurQuery([FromQuery] string province_code, [FromQuery] string amphur_code)
    {
        return _dbContext.Amphurs.FirstOrDefault(el => el.PROVINCE_CODE == province_code && el.AMPHUR_CODE == amphur_code)!;
    }

}
