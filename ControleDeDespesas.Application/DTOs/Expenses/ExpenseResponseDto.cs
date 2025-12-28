namespace ControleDeDespesas.Application.DTOs.Expense;

public class ExpenseResponseDto
{
    public Guid Id { get; set; }
    public string Description { get; private set; } = string.Empty;
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid PaymentMethodId { get; private set; }
    public bool IsRecurring { get; private set; }
    public bool IsPaid { get; private set; }

}