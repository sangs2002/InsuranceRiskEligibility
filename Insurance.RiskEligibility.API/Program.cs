using Insurance.RiskEligibility.Application.DTO;
using Insurance.RiskEligibility.Application.Interfaces;
using Insurance.RiskEligibility.Application.Risk;
using Insurance.RiskEligibility.Application.Risk.Rules;
using Insurance.RiskEligibility.Application.Services;
using Insurance.RiskEligibility.Application.Specification;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RiskEligibilityDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//Application Services
builder.Services.AddScoped<EligibilityValidationService>();

builder.Services.AddScoped<ISpecification<EligibilityRequest>, AgeSpecification>();
builder.Services.AddScoped<ISpecification<EligibilityRequest>, DrivingExperienceSpecification>();
builder.Services.AddScoped<ISpecification<EligibilityRequest>, AccidentHistorySpecification>();
builder.Services.AddScoped<ISpecification<EligibilityRequest>, PolicyTypeSpecification>();

builder.Services.AddScoped<IRiskTierRuler, LowRiskRule>();
builder.Services.AddScoped<IRiskTierRuler, MediumRiskRule>();
builder.Services.AddScoped<IRiskTierRuler, HighRiskRule>();

builder.Services.AddScoped<IRiskTierResolver, RiskTierResolver>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
