using Microsoft.AspNetCore.Mvc;

namespace netcore_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvinceController : ControllerBase
{
    private readonly ILogger<ProvinceController> _logger;
    private readonly MyDbContext _dbContext;
    public ProvinceController(ILogger<ProvinceController> logger, MyDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
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

}