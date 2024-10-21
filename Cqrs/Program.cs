using Cqrs.CQRS.Create;
using Cqrs.CQRS.GetAll;
using Cqrs.CQRS.GetById;
using Cqrs.CQRS.Remove;
using Cqrs.CQRS.Update;
using Cqrs.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddNewtonsoftJson(opt=>{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<StudentContext>(opt=>{
    opt.UseSqlite("Data Source=dbstudent");
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//! CQRS

//* MEDİATR
builder.Services.AddMediatR(typeof(Program));
//*
// builder.Services.AddScoped<GetByIdQueryHandler>();
// builder.Services.AddScoped<GetAllQueryHandle>();
// builder.Services.AddScoped<CreateCommandHandle>();
// builder.Services.AddScoped<RemoveHandle>();
// builder.Services.AddScoped<UpdateCommandHandle>();

//!

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
