namespace ControleDeDespesas.Domain.Models;

public class User
{
     public Guid Id { get; private set; }
    public string NomeCompleto { get; private set; }
    protected User(){}

    public User(string nomeCompleto)
    {
        Id = Guid.NewGuid();
        NomeCompleto = nomeCompleto;
    }
}