public interface IUserRoleRepository : IRepository<UserRole>
{
    Task DeleteCompositeKey(int userId, int roleId);
}
