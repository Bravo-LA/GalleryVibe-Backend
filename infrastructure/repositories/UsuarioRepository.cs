using domain.entities;
using domain.repositories;
using infrastructure.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace infrastructure.repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UsuarioRepository(ApplicationDbContext context, IConfiguration Configuration)
        {
            _context = context;
            _configuration = Configuration;
        }

        public async Task<string> Actualizar(Usuario usuario)
        {
            try
            {
                var usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);
                if (usuarioExistente != null)
                {
                    _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
                    await _context.SaveChangesAsync();
                    return "Actualización exitosa";
                }
                return "Usuario no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        public async Task<string> Agregar(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return "Agregado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al agregar: {ex.Message}";
            }
        }

        public async Task<string> Eliminar(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    await _context.SaveChangesAsync();
                    return "Eliminado exitosamente";
                }
                return "Usuario no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }
        public async Task<List<Usuario>> Listar()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Login(Credenciales credenciales)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => 
                        u.Username == credenciales.Username &&
                        u.Password == credenciales.Password);

                if (usuario == null)
                {
                    return "Credenciales incorrectas";
                }
                else
                {
                    return Token(usuario);
                }
            }
            catch (Exception ex)
            {
                return $"Error al iniciar sesión: {ex.Message}";
            }
        }
        private string Token(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombres),
                new Claim(ClaimTypes.Name, usuario.Apellidos),
            };
            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingsToken));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}