using MyProductApp.Domain.Entities;

namespace MyProductApp.Application.Interfaces.Repositories;

public interface IMatriculaRoleRepository
{
    Task<MatriculaRole?> GetByMatriculaAsync(string matricula, CancellationToken ct);
}