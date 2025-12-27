namespace ControleDeDespesas.Domain.Models;

public class PaymentMethod
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    protected PaymentMethod(){}

    public PaymentMethod(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}