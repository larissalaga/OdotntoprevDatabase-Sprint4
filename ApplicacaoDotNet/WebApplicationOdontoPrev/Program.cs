using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApplicationOdontoPrev.Configuration;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Mappings;
using WebApplicationOdontoPrev.Repositories.Implementations;
using WebApplicationOdontoPrev.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Inicializar ConfigManager com a configuração da aplicação
ConfigManager.Instance.Initialize(builder.Configuration);
builder.Services.AddSingleton(ConfigManager.Instance);

// Configurar AutoMapper com o perfil de mapeamento
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Registrar o MongoDB context como singleton
builder.Services.AddSingleton<MongoContext>();

// Registrar repositórios específicos para MongoDB
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IDentistaRepository, DentistaRepository>();
builder.Services.AddScoped<IRelatoriosRepository, RelatoriosRepository>();
builder.Services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();

// Adicionar suporte a MVC com sessões
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Adicionar suporte a TempData via cookie
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

var app = builder.Build();

// Configuração do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

// Definir rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
