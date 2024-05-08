using Datos.Model;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Datos.Services
{
    public class UsuarioService : DataBuff.DataBuffBase
    {
        private readonly DbPruebaContext _dbContext;

        public UsuarioService(DbPruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Usuario> ReadUsuario(ReadUsuarioRequest request, ServerCallContext context)
        {
            var user = await _dbContext.Usuarios.FindAsync(request.Id);

            if (user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Usuario no encontrado"));
            }

            return new Usuario
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Email = user.Email
            };
        }

        public override async Task<GetAllUsersResponse> ListUsusario(GetAllUsersRequest request, ServerCallContext context)
        {
            var response = new GetAllUsersResponse();

            var users = await _dbContext.Usuarios.ToListAsync();

            foreach (var user in users)
            {
                var usuario = new Usuario
                {
                    Id = user.Id,
                    Nombre = user.Nombre,
                    Email = user.Email
                };

                response.Usuarios.Add(usuario);
            }

            return response;
        }
    }
}
