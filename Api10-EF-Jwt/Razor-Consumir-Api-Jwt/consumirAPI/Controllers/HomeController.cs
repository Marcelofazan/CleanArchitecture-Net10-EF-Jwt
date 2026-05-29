using consumirAPI.DTO;
using consumirAPI.Models;
using consumirAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace consumirAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Faz o login e obtém o token JWT
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            // 1. Transforma o objeto em uma string JSON manualmente
            var json = JsonSerializer.Serialize(new
            {
                email = loginViewModel.username,
                senha = loginViewModel.password
            });

            var client = _clientFactory.CreateClient("APIClient");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                var token = loginResponse?.Token;

                // Armazenar o token JWT em uma sessão ou cookie para ser usado nas requisições subsequentes
                HttpContext.Session.SetString("JWToken", token);

                // Redirecionar para a página de listagem de produtos
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                // Leia o conteúdo para entender o erro
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Erro: {response.StatusCode} - {errorContent}");
                ViewBag.Erro = "Registro não encontrado.";

                ModelState.AddModelError(string.Empty, "Login falhou. Verifique suas credenciais.");
                return View(loginViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {

            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            var json = JsonSerializer.Serialize(new
            {
                idEmpresa = usuario.IdEmpresa,
                email = usuario.Email,
                senha = usuario.Senha,
                nome = usuario.Nome,
                taxaPercentual = usuario.TaxaPercentual,
            });

            var client = _clientFactory.CreateClient("APIClient");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Auth/registro", content);

            if (response.IsSuccessStatusCode)
            {
                // Redirecionar para a página de listagem de produtos
                return RedirectToAction("Index", "Produto");
            }

            return View("Registrar");
        }
    }
}
