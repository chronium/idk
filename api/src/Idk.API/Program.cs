using Idk.Application.Manager;
using Idk.DataAccess.Manager.EF;
using Idk.Persistence.Manager;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ManagerContext>(options =>
   options
      .UseSqlServer(builder.Configuration.GetConnectionString("IdkManager")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
   options.SwaggerDoc(Structure.ManagerV1);
   options.SwaggerDoc(Structure.TenantV1);
   options.SwaggerDoc(Structure.Unsorted);

   options.DocInclusionPredicate(Structure.InclusionPredicate);

   options.CustomSchemaIds(type => {
      var split = (type.FullName ?? string.Empty).Split('.');
      var args = split[^1].Split('+');

      Console.WriteLine(type.FullName);

      return args[0] is "Request" or "Response"
      ? $"{split[^4]}.{split[^3]}.{split[^2]}.{(args.Length > 1 ? $"{args[0]}.{string.Join(".", args[1..])}" : args[0])}"
      : type.FullName;
   });
});
builder.Services.AddMediatR(typeof(Dummy).Assembly);
builder.Services.RegisterManagerDataAccess();
builder.Services.AddAutoMapper(typeof(Dummy));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
   app.UseSwagger();
   app.UseSwaggerUI(options => {
      options.SwaggerEndpoint(Structure.ManagerV1);
      options.SwaggerEndpoint(Structure.TenantV1);
      options.SwaggerEndpoint(Structure.Unsorted);
   });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
