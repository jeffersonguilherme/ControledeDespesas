namespace ControleDeDespesas.Application.DTOs.Expense;

public class ExpenseCreateDto
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid CategoryId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public bool IsRecurring { get; set; }
    public bool IsPaid { get; set; }

}