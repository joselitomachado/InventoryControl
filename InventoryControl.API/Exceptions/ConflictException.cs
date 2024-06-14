namespace InventoryControl.API.Exceptions;

public class ConflictException : MedicationException
{
    public ConflictException(string message) : base(message)
    {
    }
}
