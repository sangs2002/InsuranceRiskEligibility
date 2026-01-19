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
builder.Services.AddScoped<IRiskTierRuler, LowRiskRule>();
builder.Services.AddScoped<IRiskTierRuler, MediumRiskRule>();
builder.Services.AddScoped<IRiskTierRuler, HighRiskRule>();

builder.Services.AddScoped<IRiskTierResolver, RiskTierResolver>();
builder.Services.AddScoped<IEligibilityValidationService, EligibilityValidationService>();

//Strategies
builder.Services.AddScoped<ComprehensivePolicyRiskStrategy>();
builder.Services.AddScoped<ThirdPartyPolicyRiskStrategy>();
builder.Services.AddScoped<CollisionPolicyRiskStrategy>();
builder.Services.AddScoped<IRiskStrategyFactory, RiskStrategyFactory>();
builder.Services.AddScoped<IReadOnlyDictionary<PolicyType, IRiskCalculationStrategy>>(sp =>
    new Dictionary<PolicyType, IRiskCalculationStrategy>
    {
        { PolicyType.Comprehensive, sp.GetRequiredService<ComprehensivePolicyRiskStrategy>() },
        { PolicyType.ThirdParty, sp.GetRequiredService<ThirdPartyPolicyRiskStrategy>() },
        { PolicyType.Collision, sp.GetRequiredService<CollisionPolicyRiskStrategy>() }
    });

//Services
builder.Services.AddScoped<IRiskEvaluationCommandService, RiskEvaluationCommandService>();
builder.Services.AddScoped<IRiskEvaluationQueryService, RiskEvaluationQueryService>();

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
