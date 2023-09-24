using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using school_helper.DbContext;
using school_helper.Servicies;
using school_helper.Utilities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

string allowedOrigins = builder.Configuration["frontURL"];

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader();
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsTry",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://schelper.vercel.app");
                      });
});


//repositories
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IClassesRepository,ClassesRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

//timeonly converter
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
//});


builder.Services.AddAutoMapper(typeof(Program));

//postgresql 
//builder.Services.AddDbContext<SchoolDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//ssms
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SSMS")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SchoolDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opciones =>
    {

        opciones.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["jwtkey"])),
            ClockSkew = TimeSpan.Zero,

        };
        opciones.MapInboundClaims = false;
    }
    );

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("isAdmin", policy => policy.RequireClaim("role", "admin"));
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

//app.UseCors();
app.UseRouting();

app.UseCors("CorsTry");


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
