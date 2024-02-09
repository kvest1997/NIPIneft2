using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System;

namespace WebAPI
{
    public class ConfigureSwaggerOptions 
        : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
            _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                                    new OpenApiInfo
                                    {
                                        Version = apiVersion,
                                        Title = $"Notes API {apiVersion}",
                                        Description =
                                            "My First API Rest",
                                        TermsOfService =
                                            new Uri("https://vk.com/chtooo0"),
                                        Contact = new OpenApiContact
                                        {
                                            Name = " My Page in VK",
                                            Email = string.Empty,
                                            Url =
                                                new Uri("https://vk.com/chtooo0")
                                        },
                                        License = new OpenApiLicense
                                        {
                                            Name = "No License",
                                            Url =
                                                new Uri("https://vk.com/chtooo0")
                                        }
                                    });

                options.AddSecurityDefinition($"AuthToken {apiVersion}",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Name = "Authorization",
                        Description = "Authorization token"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = $"AuthToken {apiVersion}"
                            }
                        },
                        new string[] { }
                    }
                });

                options.CustomOperationIds(apiDescription =>
                    apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : null);
            }
        }
    }
}
