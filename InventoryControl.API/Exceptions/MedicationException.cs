namespace InventoryControl.API.Exceptions;

public class MedicationException : SystemException
{
    public MedicationException(string message) : base(message)
    {
    }
}
