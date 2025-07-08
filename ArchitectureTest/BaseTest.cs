using CleanArchitectureApp.Infrastructure.Data;
using CleanArchitectureApp;
using System.Reflection;
using CleanArchitectureApp.Application.DTOs;

namespace ArchitectureTest
{
    public class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(CleanArchitectureApp.Domain.Model.Product).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(GetAllProductDTO).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
    }
}