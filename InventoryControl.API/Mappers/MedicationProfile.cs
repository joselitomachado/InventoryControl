using AutoMapper;
using InventoryControl.API.Entities;
using InventoryControl.API.Models;

namespace InventoryControl.API.Mappers;

public class MedicationProfile : Profile
{
    public MedicationProfile()
    {
        CreateMap<Medication, MedicationViewModel>();

        CreateMap<MedicationInputModel, Medication>();
    }
}
