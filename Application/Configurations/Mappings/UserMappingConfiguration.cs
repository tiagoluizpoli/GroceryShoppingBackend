using Contracts.Family;
using Contracts.Users;
using Domain.EFSetup.Entities;
using Mapster;

namespace Application.Configurations.Mappings;

public class UserMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.AllowImplicitDestinationInheritance = true;

        config.NewConfig<NewUserContract, UserEntity>()
            .Map(dest => dest.FamilyEntity, src => src.Family);

    }
}