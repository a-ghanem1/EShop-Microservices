var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config => 
{
   config.RegisterServicesFromAssembly(assembly);
   config.AddOpenBehavior(typeof(ValidationBehavior<,>));
   config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddMarten(opts => 
{
   opts.Connection(builder.Configuration.GetConnectionString("DefaultConnection"));
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
   builder.Services.InitializeMartenWith<InitialDataSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => {});

app.Run();
