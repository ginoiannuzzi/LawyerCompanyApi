using Afte.Database;
using Afte.Models;
using Afte.Models.Enums;
using Afte.Models.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Afte.Services
{
    public class UserService
    {
        private readonly AfteDbContext _context;

        public UserService(AfteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetUsers()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task CreateUser(CreateUserViewModel userDto)
        {
            var user = new Usuario()
            {
                AuthorizationState = AuthorizationState.AUTHORIZATION_PENDING,
                CredentialId = userDto.CredentialId
            };

            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetUserById(long id)
        {
            return await _context.Usuarios.SingleAsync(x => x.Id == id);
        }

        public async Task RegisterUserData(UpdateUserViewModel user, long userId)
        {
            var existingUser = _context.Usuarios.Single(x => x.Id == userId);

            if (user.AuthorizationState == AuthorizationState.AUTHORIZATION_APPROVED)
            {
                existingUser.AuthorizationState = AuthorizationState.AUTHORIZATION_APPROVED;
                existingUser.College = user.College;
                existingUser.Email = user.Email;
                existingUser.DisplayName = user.DisplayName;
                existingUser.Folio = user.Folio;
                existingUser.Tomo = user.Tomo;
                existingUser.AssociateNr = user.AssociateNr;
                existingUser.Role = user.Role;
                existingUser.CreatedAt = DateTime.Now;
                existingUser.Role = user.Role;
            }
            else
            {
                existingUser.AuthorizationState = user.AuthorizationState;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(long userId)
        {
            var usuario = await _context.Usuarios.SingleAsync(x => x.Id == userId);

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
