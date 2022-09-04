using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Ioc
{
  public static class ServiceTool // ınjectionları kontrol ediyoruz
  {
    public static IServiceProvider ServiceProvider { get; private set; }

    public static IServiceCollection Create(IServiceCollection services)
    {
      ServiceProvider = services.BuildServiceProvider();
      return services;
    }
  }
}
