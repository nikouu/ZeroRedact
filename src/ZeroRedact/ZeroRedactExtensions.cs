using Microsoft.Extensions.DependencyInjection;

namespace ZeroRedact
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/> to register <see cref="IRedactor"/> with the <see cref="Redactor"/> implementation.
    /// </summary>
    public static class ZeroRedactExtensions
    {
        /// <summary>
        /// Registers an instance of <see cref="IRedactor"/> with the <see cref="Redactor"/> implementation.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns></returns>
        public static IServiceCollection AddZeroRedact(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddSingleton<IRedactor, Redactor>();
            return services;
        }

        /// <summary>
        /// Registers an instance of <see cref="IRedactor"/> with the <see cref="Redactor"/> implementation with <see cref="RedactorOptions"/>.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="options">The <see cref="RedactorOptions"/> to configure the <see cref="Redactor"/></param>.
        /// <returns></returns>
        public static IServiceCollection AddZeroRedact(this IServiceCollection services, RedactorOptions options)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddSingleton<IRedactor>(new Redactor(options));
            return services;
        }
    }
}
