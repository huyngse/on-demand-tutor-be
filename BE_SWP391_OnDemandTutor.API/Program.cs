using BE_SWP391_OnDemandTutor.API.AutoMapperConfig;
using BE_SWP391_OnDemandTutor.API.GlobalExceptionHandler;
using BE_SWP391_OnDemandTutor.BusinessLogic.Generations.DependencyInjection;
using BE_SWP391_OnDemandTutor.BusinessLogic.Helper.EmailSettings;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq(serverUrl: "http://localhost:5341"));

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))

    };
});
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo() { Title = "On Tutor Demand", Version = "v1" });
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.ConfigureAutoMapper();


// ADD CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(policyBuilder =>
        policyBuilder.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));


builder.Services.AddDbContext<BE_SWP391_OnDemandTutorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.InitializerDependencyInjection();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddTransient<IEmailServices, EmailSenderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "On Tutor Demand");
    });
}

app.UseCors();


//app.UseMiddleware<UnauthourizeExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
