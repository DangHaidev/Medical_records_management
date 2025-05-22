using Medical_record.Application.Services;
using Medical_record.Domain.Interfaces;
using Medical_record.Infrastructure.Persistence;
using Medical_record.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Medical_record.Application.Common.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

//cac service moi

builder.Services.AddScoped<Service>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DoctorSevice>();
builder.Services.AddScoped<PhieuKhamBenhService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPhieuKhamBenhRepository, PhieuKhamBenhRepository>();
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<MedicalRecordService>();




builder.Services.AddDbContext<ApplicationDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));


// Thêm d?ch v? xác th?c và cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";     // Khi ch?a ??ng nh?p, s? redirect t?i ?ây
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied"; // N?u dùng [Authorize(Roles = "Admin")] ch?ng h?n
    });

builder.Services.AddAuthorization(); // Thêm d?ch v? ?y quy?n


// Add services to the container.
builder.Services.AddControllersWithViews();

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

//moi
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "account", // route riêng cho Account không n?m trong Area
    pattern: "Account/{action=Login}/{id?}",
    defaults: new { controller = "Account" });

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Client" });


app.Run();
