using Application.Dto;
using Domain.Interfaces.Dtos;
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
        /// Saves a new user or updates an existing one.
        /// </summary>
        /// <param name="userDto">The user data to be saved.</param>
        /// <returns>A task that represents the asynchronous operation, containing the saved user entity.</returns>
        Task<UserEntity> save(UserDto userDto);

        /// <summary>
        /// Verifies the password of a user.
        /// </summary>
        /// <param name="loginDto">The login data containing the user's email and password.</param>
        /// <returns>A task that represents the asynchronous operation, containing a boolean indicating whether the password is valid.</returns>
        Task<LoginResponse> VerifyPassword(LoginDto loginDto);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="userDto">The updated user data.</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated user entity.</returns>
        Task<UserEntity> update(UserDto userDto);

        /// <summary>
        /// Deletes a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deleted user entity.</returns>
        Task<UserEntity> delete(int id);

        /// <summary>
        /// Finds a user by its email address.
        /// </summary>
        /// <param name="email">The email address of the user to be found.</param>
        /// <returns>A task that represents the asynchronous operation, containing the found user entity.</returns>
        Task<UserEntity> FindByEmail(string email);

        /// <summary>
        /// Finds a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to be found.</param>
        /// <returns>A task that represents the asynchronous operation, containing the found user entity.</returns>
        Task<UserEntity> FindById(int id);
    }
}