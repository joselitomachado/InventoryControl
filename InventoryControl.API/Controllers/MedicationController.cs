using InventoryControl.API.Models;
using InventoryControl.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControl.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicationController : ControllerBase
{
    private readonly IMedicationInterface _medicationInterface;

    public MedicationController(IMedicationInterface medicationInterface)
    {
        _medicationInterface = medicationInterface;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var medications = await _medicationInterface.GetAll();

        return Ok(medications);
    }

    [HttpGet("{barCode}")]
    public async Task<IActionResult> GetByBarcode(string barCode)
    {
        var medication = await _medicationInterface.GetByBarcode(barCode);

        return Ok(medication);
    }

    [HttpPost]
    public async Task<IActionResult> Register(MedicationInputModel input)
    {
        var medication = await _medicationInterface.Register(input);

        return Ok(medication);
    }

    [HttpPut("{barCode}")]
    public async Task<IActionResult> Receipt(string barCode, int quantity)
    {
        var medication = await _medicationInterface.Receipt(barCode, quantity);

        return Ok(medication);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var medication = await _medicationInterface.Delete(id);

        return NoContent();
    }
}