public class UserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Role> _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public UserService(IRepository<User> userRepository, IRepository<Role> roleRepository, IUserRoleRepository userRoleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<bool> ChangeUserRole(int userId, int newRoleId)
    {
        var userRole = (await _userRoleRepository.GetAll()).FirstOrDefault(ur => ur.UserId == userId);
        if (userRole == null)
        {
            return false; // User or UserRole not found
        }

        var newRole = await _roleRepository.GetById(newRoleId);
        if (newRole == null)
        {
            return false; // Role not found
        }
        // RoleId is key
        // Delete old role
        await _userRoleRepository.DeleteCompositeKey(userRole.UserId, userRole.RoleId);
        // Create new UserRole
        var newUserRole = new UserRole
        {
            UserId = userId,
            RoleId = newRoleId
        };
        await _userRoleRepository.Add(newUserRole);

        return true; //Success
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task CreateUser(User user)
    {
        await _userRepository.Add(user);
    }

    public async Task UpdateUser(User user)
    {
        await _userRepository.Update(user);
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.Delete(id);
    }
}
