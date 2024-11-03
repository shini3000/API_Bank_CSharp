using UserBankApi.Models.Dto;
using UserBankApi.Models.Entities;

namespace Application.Services.Interfaces
{
    /// <summary>
    /// Interface that defines the services for user management.
    /// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// Saves a new user to the database.
        /// </summary>
        /// <param name="userDto">The object containing the user information to save.</param>
        /// <returns>The saved user entity.</returns>
        public Task<UserEntity> save(UserDto userDto);

        /// <summary>
        /// Updates an existing user's information in the database.
        /// </summary>
        /// <param name="userDto">The object containing the updated user information.</param>
        /// <returns>The updated user entity.</returns>
        public Task<UserEntity> update(UserDto userDto);

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        /// <param name="id">The identifier of the user to delete.</param>
        /// <returns>The deleted user entity.</returns>
        public Task<UserEntity> delete(int id);

        /// <summary>
        /// Finds a user by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the user to find.</param>
        /// <returns>The found user entity.</returns>
        public Task<UserEntity> FindById(int id);
    }
}