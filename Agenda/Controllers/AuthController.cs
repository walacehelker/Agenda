using Context;
using Dados.Cadastro;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string senha)
        {
            // Encontrar o usuário no banco de dados
            var usuarioLogin = _dbContext.UsuariosLogins.SingleOrDefault(u => u.Usuario == usuario);

            if (usuarioLogin != null && PasswordHelper.VerifyPassword(usuarioLogin.Senha, senha))
            {
                // Criando os claims de autenticação
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioLogin.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuarioLogin.Usuario),
                    new Claim(ClaimTypes.Email, usuarioLogin.Email)
                };

                // Criando a identidade do usuário
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Configurando as propriedades do cookie de autenticação
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Mantém o usuário logado após fechar o navegador
                    ExpiresUtc = DateTime.UtcNow.AddHours(8) // Expiração do cookie
                };

                // Realizando a autenticação e criação do cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                return RedirectToAction("Index", "Home");  // Redireciona para a página inicial
            }

            // Se não for possível autenticar, adiciona erro e retorna a página
            ModelState.AddModelError("", "Usuário ou senha inválidos");
            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string usuario, string email, string senha)
        {
            if (ModelState.IsValid)
            {
                // Verificando se o usuário já existe
                var usuarioExistente = _dbContext.UsuariosLogins.SingleOrDefault(u => u.Usuario == usuario);
                if (usuarioExistente != null)
                {
                    ModelState.AddModelError("", "Usuário já existe.");
                    return View();
                }

                var novoUsuario = new UsuarioLogin
                {
                    Usuario = usuario,
                    Email = email,
                    Senha = PasswordHelper.HashPassword(senha),
                    DataCadastro = DateTime.Now
                };

                _dbContext.UsuariosLogins.Add(novoUsuario);
                _dbContext.SaveChanges();

                return RedirectToAction("Login");  // Redireciona para a tela de login após o registro
            }

            return View();
        }

    }

    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<UsuarioLogin>();
            var usuarioDummy = new UsuarioLogin();  // Simula um "dummy", mas não é necessário para hash
            return hasher.HashPassword(usuarioDummy, password);
        }

        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var hasher = new PasswordHasher<UsuarioLogin>();
            var usuarioDummy = new UsuarioLogin();  // Simula um "dummy", mas não é necessário para verificar
            return hasher.VerifyHashedPassword(usuarioDummy, hashedPassword, providedPassword) == PasswordVerificationResult.Success;
        }
    }




}
