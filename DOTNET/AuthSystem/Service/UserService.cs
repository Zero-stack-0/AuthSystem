using AuthSystem.Dto.Request;
using AuthSystem.Dto.Response;
using AuthSystem.Repository.Interface;
using AuthSystem.Service.Interface;
using AutoMapper;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponse> GetUserById(int id)
    {
        var user = await _userRepository.GetById(id);
        return _mapper.Map<UserResponse>(user);
    }
}