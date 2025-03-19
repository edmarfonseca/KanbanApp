using KanbanApp.UI;
using KanbanApp.UI.Interceptors;
using KanbanApp.UI.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/*
 * Configura��o da biblioteca HTTP CLIENT 
 * para executar os servi�os da API
 */ 
builder.Services.AddScoped(sp => new HttpClient());

/*
 * Configura��o da biblioteca Blazored LocalStorage
 */
builder.Services.AddBlazoredLocalStorage();

/*
 * Configura��o para inje��es de depend�ncia
 */
builder.Services.AddScoped<AuthService>();

/*
 * Configura��o para o Interceptor
 */
builder.Services.AddScoped<AuthInterceptor>();

await builder.Build().RunAsync();
