using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SIS.Tech.App;
using SIS.Tech.IApp;
using SIS.Tech.IDomain;
using SIS.Tech.Domain;
using SIS.Tech.IRepository;
using SIS.Tech.IServices;
using SIS.Tech.Models;
using SIS.Tech.Repository;
using SIS.Tech.Services;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromHours(8);
});

// Add services to the container.

// APP
builder.Services.AddScoped<ILoginApp, LoginApp>();
builder.Services.AddScoped<IUsuarioApp, UsuarioApp>();
builder.Services.AddScoped<IMailApp, MailApp>();
builder.Services.AddScoped<ITipoCCTApp, TipoCCTApp>();
builder.Services.AddScoped<IStatusCCTApp, StatusCCTApp>();
builder.Services.AddScoped<IConvencaoApp, ConvencaoApp>();
builder.Services.AddScoped<IAccessApp, AccessApp>();
builder.Services.AddScoped<IEmpresaApp, EmpresaApp>();
builder.Services.AddScoped<IContatoApp, ContatoApp>();
builder.Services.AddScoped<IEnderecoApp, EnderecoApp>();
builder.Services.AddScoped<IRamoAtividadeApp, RamoAtividadeApp>();
builder.Services.AddScoped<ITipoPessoaApp, TipoPessoaApp>();
builder.Services.AddScoped<ISocioApp, SocioApp>();
builder.Services.AddScoped<IFuncionarioApp, FuncionarioApp>();


//DOMAIN
builder.Services.AddScoped<ILoginBo, LoginBo>();
builder.Services.AddScoped<IUsuarioBo, UsuarioBo>();
builder.Services.AddScoped<ITipoCCTBo, TipoCCTBo>();
builder.Services.AddScoped<IStatusCCTBo, StatusCCTBo>();
builder.Services.AddScoped<IConvencaoBo, ConvencaoBo>();
builder.Services.AddScoped<IAccessBo, AccessBo>();
builder.Services.AddScoped<IEmpresaBo, EmpresaBo>();
builder.Services.AddScoped<IContatoBo, ContatoBo>();
builder.Services.AddScoped<IEnderecoBo, EnderecoBo>();
builder.Services.AddScoped<IRamoAtividadeBo, RamoAtividadeBo>();
builder.Services.AddScoped<ITipoPessoaBo, TipoPessoaBo>();
builder.Services.AddScoped<ISocioBo, SocioBo>();
builder.Services.AddScoped<IFuncionarioBo, FuncionarioBo>();

//REPOSITORY
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoCCTRepository, TipoCCTRepository>();
builder.Services.AddScoped<IStatusCCTRepository, StatusCCTRepository>();
builder.Services.AddScoped<IConvencaoRepository, ConvencaoRepository>();
builder.Services.AddScoped<IAccessRepository, AccessRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IRamoAtividadeRepository, RamoAtividadeRepository>();
builder.Services.AddScoped<ITipoPessoaRepository, TipoPessoaRepository>();
builder.Services.AddScoped<ISocioRepository, SocioRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

//SERVOCES
builder.Services.AddScoped<IControleAcesso, ControleAcesso>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "pt-BR", "en-US" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures)
        .AddInitialRequestCultureProvider(
                            new CustomRequestCultureProvider(async context =>
                            {
                                // My custom request culture logic
                                return new ProviderCultureResult("pt-BR");
                            }));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}"); 

app.Run();
