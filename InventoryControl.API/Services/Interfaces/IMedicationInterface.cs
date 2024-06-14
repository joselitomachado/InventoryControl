using InventoryControl.API.Entities;
using InventoryControl.API.Models;

namespace InventoryControl.API.Services.Interfaces;

public interface IMedicationInterface
{
    Task<List<MedicationViewModel>> GetAll();
    Task<Medication> GetByBarcode(string barCode);
    Task<Medication> Register(MedicationInputModel medication);
    Task<Medication> Receipt(string barCode, int quantity);
    Task<bool> Delete(Guid id);
}
