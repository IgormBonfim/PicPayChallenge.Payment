using Microsoft.Extensions.Logging;
using PicPyChallenge.Payment.Consumers.Users.Interfaces;

namespace PicPyChallenge.Payment.Consumers.Users
{
    public class UsersCreatedBackgroundService : BackgroundService
    {
        private readonly IServiceProvider services;
        private readonly ILogger<UsersCreatedBackgroundService> logger;

        public UsersCreatedBackgroundService(IServiceProvider services, ILogger<UsersCreatedBackgroundService> logger)
        {
            this.services = services;
            this.logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = services.CreateScope())
            {
                IUsersCreatedConsumer usersCreatedConsumer = scope.ServiceProvider.GetRequiredService<IUsersCreatedConsumer>();
                logger.LogInformation("UsersCreated Consumer Started");
                await usersCreatedConsumer.Execute();
            }
        }
    }
}
