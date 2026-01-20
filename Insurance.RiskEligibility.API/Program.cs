var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<RiskEligibilityDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddHealthChecks()
    .AddDbContextCheck<RiskEligibilityDbContext>();
builder.Services.AddScoped<IRiskReadDbContext>(sp =>
    sp.GetRequiredService<RiskEligibilityDbContext>());

// Specifications
builder.Services.AddScoped<ISpecification<EligibilityRequest>, AgeSpecification>();
builder.Services.AddScoped<ISpecification<EligibilityRequest>, DrivingExperienceSpecification>();
builder.Services.AddScoped<ISpecification<EligibilityRequest>, AccidentHistorySpecification>();
builder.Services.AddScoped<ISpecification<EligibilityRequest>, PolicyTypeSpecification>();

// Risk rules
builder.Services.AddScoped<IRiskTierRuler, LowRiskTier>();
builder.Services.AddScoped<IRiskTierRuler, MediumRiskTier>();
builder.Services.AddScoped<IRiskTierRuler, HighRiskTier>();

builder.Services.AddScoped<IRiskTier, RiskTiersService>();
builder.Services.AddScoped<IEligibilityValidationService, EligibilityValidationService>();

//Strategies
builder.Services.AddScoped<IRiskStrategyFactory, RiskStrategyFactory>();
builder.Services.AddScoped<IRiskCalculationStrategy, ComprehensivePolicyRiskStrategy>();
builder.Services.AddScoped<IRiskCalculationStrategy, ThirdPartyPolicyRiskStrategy>();
builder.Services.AddScoped<IRiskCalculationStrategy, CollisionPolicyRiskStrategy>();


//Services
builder.Services.AddScoped<IRiskCommandService, RiskEvaluationCommandService>();
builder.Services.AddScoped<IRiskQueryService, RiskQueryService>();

// Repositories and Unit of Work
builder.Services.AddScoped<ICustomerRespository, CustomerRespository>();
builder.Services.AddScoped<IUnitofWork, UnitOfWork>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("/health");

app.MapControllers();
app.Run();
