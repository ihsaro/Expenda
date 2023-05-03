namespace Expenda.Domain.Entities.Derived;

public class UserDataMetrics
{
    public float TotalAmountSpent { get; set; }
    public string LastItemPurchased { get; set; } = null!;
    public int LastItemPurchasedQuantity { get; set; }
    public float LastItemPurchasedTotalPrice { get; set; }
    public float CurrentMonthlyBudget { get; set; }
}
