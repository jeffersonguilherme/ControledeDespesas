namespace ControleDeDespesas.Domain.Models;

public class Expense
{
    public Guid Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid PaymentMethodId { get; private set; }
    public bool IsRecurring { get; private set; }
    public bool IsPaid { get; private set; }

    protected Expense(){}

    public Expense(
        string description,
        decimal amount,
        DateTime date,
        Guid categoryId,
        Guid paymentMethodId,
        bool isRecurring
    )
    {
        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        Date = date;
        CategoryId = categoryId;
        PaymentMethodId = paymentMethodId;
        IsRecurring = isRecurring;
        IsPaid = false;
    }

    public void MarkAsPaid()
    {
        IsPaid = true;
    }
}