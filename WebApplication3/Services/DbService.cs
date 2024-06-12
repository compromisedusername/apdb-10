using WebApplication3.Data;

namespace WebApplication3.Services;

public class DbService : IDbService
{
    private readonly ApplicationContext _context;

    public DbService(ApplicationContext context)
    {
        _context = context;
    }
}