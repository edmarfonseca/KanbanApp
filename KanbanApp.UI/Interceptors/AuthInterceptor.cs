using KanbanApp.UI.Services;

namespace KanbanApp.UI.Interceptors
{
    public class AuthInterceptor : DelegatingHandler
    {
        private readonly AuthService _authService;

        public AuthInterceptor(AuthService authService)
        {
            _authService = authService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _authService.GetAccessToken();

            request.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}