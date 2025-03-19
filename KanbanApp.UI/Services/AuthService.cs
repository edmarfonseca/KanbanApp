using KanbanApp.UI.Dtos;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace KanbanApp.UI.Services
{
    public class AuthService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        public AuthService(ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        public async Task SignIn(AutenticarPessoaResponseDto dto)
        {
            await _localStorageService.SetItemAsync("usuario", dto);
            _navigationManager.NavigateTo("/consultar-tarefas", true);
        }

        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync("usuario");
            _navigationManager.NavigateTo("/", true);
        }

        public async Task<AutenticarPessoaResponseDto?> GetData()
        {
            return await _localStorageService.GetItemAsync
                <AutenticarPessoaResponseDto>("usuario");
        }

        public async Task<bool> IsLoggedIn()
        {
            var data = await GetData();
            return data != null && data.DataHoraExpiracao >= DateTime.Now;
        }

        public async Task<string> GetAccessToken()
        {
            var data = await GetData();
            return data.Token;
        }
    }
}