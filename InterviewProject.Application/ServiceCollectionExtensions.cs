using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using InterviewProject.Application.Interfaces;
using InterviewProject.Application.Common;

namespace InterviewProject.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IGraphPathFinder, GraphPathFinder>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
