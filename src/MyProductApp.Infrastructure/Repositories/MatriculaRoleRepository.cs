using Microsoft.EntityFrameworkCore;
using MyProductApp.Application.Interfaces.Repositories;
using MyProductApp.Domain.Entities;
using MyProductApp.Infrastructure.Persistence;

namespace MyProductApp.Infrastructure.Repositories;

public class MatriculaRoleRepository : IMatriculaRoleRepository
{
    private readonly AppDbContext _db;

    public MatriculaRoleRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<MatriculaRole?> GetByMatriculaAsync(string matricula, CancellationToken ct)
    {
       return await _db.MatriculaRoles.FirstOrDefaultAsync(m => m.Matricula == matricula, ct);
    }
}