using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace netcore_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreProvinceController : ControllerBase
{
    private readonly MyDbContext _dbContext;

    public StoreProvinceController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoreProvince>>> GetStoreProvince()
    {
        string storedprocedure = "exec common.dbo.SEL_PROVINCE";
        return await _dbContext.StoreProvinces.FromSqlRaw(storedprocedure).ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<IEnumerable<StoreProvince>>> PostStoreProvince([FromForm] StoreProvinceInput storeProvinceInput)
    {
        string storedprocedure = "exec common.dbo.SEL_PROVINCE";
        var data = await _dbContext.StoreProvinces.FromSqlRaw(storedprocedure).ToListAsync();
        return Ok(data.FirstOrDefault(el => el.ID == storeProvinceInput.ID));
    }


}
