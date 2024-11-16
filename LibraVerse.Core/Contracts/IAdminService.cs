namespace LibraVerse.Core.Contracts
{
    using LibraVerse.Core.Models.QueryModels.Admin;
    using LibraVerse.Core.Models.ViewModels.Admin;

    public interface IAdminService
    {
        Task<int> AddPublisherAsync(string userId);
        Task<UserServiceModel> RemovePublisherAsync(string userId);
        Task<int> RemovePublisherConfirmedAsync(string userId);


        Task<string> AddAdminAsync(string userId);
        Task<UserServiceModel> RemoveAdminAsync(string userId);
        Task<string> RemoveAdminConfirmedAsync(string userId);
    }
}