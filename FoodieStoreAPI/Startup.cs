﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FoodieStoreAPI.Repositories;
using FoodieStoreAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FoodieStoreAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddTransient<IDbConnection>(options => new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection")));
      services.AddTransient<ICustomerService, CustomerService>();
      services.AddTransient<IProductService, ProductService>();
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      services.AddTransient<IProductRepository, ProductRepository>();
     

      services.AddSwaggerGen(s =>
      {
        s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "FoodieStoreAPI", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();

      app.UseSwagger();
      app.UseSwaggerUI(a =>
      {
        a.SwaggerEndpoint("/swagger/v1/swagger.json", "Foodie Store API v1");
      });
    }
  }
}
