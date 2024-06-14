using AutoMapper;
using InventoryControl.API.Entities;
using InventoryControl.API.Exceptions;
using InventoryControl.API.Models;
using InventoryControl.API.Persistence;
using InventoryControl.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.API.Services.Repositories;

public class MedicationRepository : IMedicationInterface
{
    private readonly InventoryControlDbContext _inventoryControlDb;
    private readonly IMapper _mapper;

    public MedicationRepository(InventoryControlDbContext inventoryControlDb, IMapper mapper)
    {
        _inventoryControlDb = inventoryControlDb;
        _mapper = mapper;
    }

    public async Task<List<MedicationViewModel>> GetAll()
    {
        var response = await _inventoryControlDb.Medications.ToListAsync();

        var viewModel = _mapper.Map<List<MedicationViewModel>>(response);

        return viewModel;
    }

    public async Task<Medication> GetByBarcode(string barCode)
    {
        var response = await _inventoryControlDb.Medications.Where(x => x.BarCode == barCode).FirstOrDefaultAsync();

        if (response == null)
        {
            throw new NotFoundException("Nenhum medicamento encontrado com esse código de barra.");
        }

        return response;
    }

    public async Task<Medication> Register(MedicationInputModel medication)
    {
        var response = await _inventoryControlDb.Medications.FirstOrDefaultAsync(x => x.BarCode == medication.BarCode);

        if (response?.BarCode == medication.BarCode)
        {
            throw new ConflictException("Medicamento com esse código de barra já registrado.");
        }

        var inputModel = _mapper.Map<Medication>(medication);

        await _inventoryControlDb.Medications.AddAsync(inputModel);
        await _inventoryControlDb.SaveChangesAsync();

        return inputModel;
    }

    public async Task<Medication> Receipt(string barCode, int quantity)
    {
        var response = await _inventoryControlDb.Medications.Where(x => x.BarCode == barCode).FirstOrDefaultAsync();

        if (response == null)
        {
            throw new NotFoundException("Nenhum medicamento encontrado com esse código de barra.");
        }

        response.Quantity += quantity;

        _inventoryControlDb.Update(response);
        await _inventoryControlDb.SaveChangesAsync();

        return response;
    }

    public async Task<bool> Delete(Guid id)
    {
        var response = await _inventoryControlDb.Medications.FirstOrDefaultAsync(x => x.Id == id);

        if (response == null)
        {
            throw new NotFoundException("Nenhum medicamento com esse ID encontrado.");
        }

        _inventoryControlDb.Medications.Remove(response);
        await _inventoryControlDb.SaveChangesAsync();

        return true;
    }
}
