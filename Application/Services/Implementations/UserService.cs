using Application.Repositories.Database;
using Application.Services.Interfaces;
using Contracts.Users;
using Domain.EFSetup.Entities;
using ErrorOr;
using MapsterMapper;

namespace Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly IBaseRepository<UserEntity> _userRepository;
    private readonly IBaseRepository<FamilyEntity> _familyRepository;

    private readonly IMapper _mapper;

    public UserService(IBaseRepository<UserEntity> userRepository, IMapper mapper,
        IBaseRepository<FamilyEntity> familyRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _familyRepository = familyRepository;
    }

    public async Task<ErrorOr<UserResponseContract>> AddUser(NewUserContract request)
    {
        UserEntity User = _mapper.Map<UserEntity>(request);

        if (request.FamilyId != null)
        {
            var Family = await _familyRepository.GetById(request.FamilyId.Value);
            if (Family.IsError)
            {
                return Family.Errors;
            }
            User.FamilyEntity = Family.Value;
        }
        if (request.Family is not null)
        {
            FamilyEntity NewFamily = new FamilyEntity()
            {
                Name = request.Family.Name,
                Description = request.Family.Description,
                Owner = User
            };
            // _familyRepository.Add(NewFamily); 
            User.FamilyEntity = NewFamily;
            // _userRepository.Update(User);
        }
        ErrorOr<Created> AddUserResponse = await _userRepository.Add(User);

        if (AddUserResponse.IsError)
        {
            return AddUserResponse.Errors;
        }
        
        return _mapper.Map<UserResponseContract>(User);
    }

    public Task<ErrorOr<List<UserResponseContract>>> GetUsers()
    {
        throw new NotImplementedException();
    }
}