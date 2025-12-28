using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ControleDeDespesas.Infrastructure.Data;

public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}