namespace MyProductApp.Domain.Entities;

public class MatriculaRole
{
    public Guid Id { get; private set; }
    public string Matricula { get; private set; }
    public string Role { get; private set; }
    public MatriculaRole(string matricula, string role)
    {
        if (string.IsNullOrWhiteSpace(matricula))
            throw new ArgumentException("A matrícula é obrigatória.", nameof(matricula));
        if (string.IsNullOrWhiteSpace(role))
            throw new ArgumentException("A role é obrigatória.", nameof(role));
        Id = Guid.NewGuid();
        Matricula = matricula.Trim().ToUpper();
        Role = role.Trim();
    }
}