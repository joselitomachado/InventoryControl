namespace InventoryControl.API.Exceptions;

public class NotFoundException : MedicationException
{
    public NotFoundException(string message) : base(message)
    {
    }
}
