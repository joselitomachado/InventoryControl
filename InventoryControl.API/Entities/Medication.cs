namespace InventoryControl.API.Entities;

public class Medication
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ActiveIngredient { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string BarCode { get; set; } = string.Empty;
    public string InternalCode { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
