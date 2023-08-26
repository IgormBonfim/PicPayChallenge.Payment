using Confluent.Kafka;
using PicPayChallenge.Payment.Application.Users.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Users.Facts;
using PicPyChallenge.Payment.Consumers.Users.Interfaces;
using System.Text.Json;

namespace PicPyChallenge.Payment.Consumers.Users
{
    public class UsersCreatedConsumer : IUsersCreatedConsumer
    {
        private readonly IUsersAppService usersAppService;
        private readonly ILogger<UsersCreatedConsumer> logger;
        private readonly IConfiguration configuration;

        public UsersCreatedConsumer(IUsersAppService usersAppService, ILogger<UsersCreatedConsumer> logger, IConfiguration configuration)
        {
            this.usersAppService = usersAppService;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task Execute()
        {
            var configs = new ConsumerConfig
            {
                GroupId = "users-created-consumer",
                BootstrapServers = configuration.GetSection("Kafka:Url").Value!,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            string topic = "userCreated";

            using (var consumer = new ConsumerBuilder<string, string>(configs).Build())
            {
                consumer.Subscribe(topic);

                try
                {
                    while (true)
                    {
                        var evento = consumer.Consume();
                        string message = evento.Message.Value;

                        UserCreatedFact userCreatedFact = JsonSerializer.Deserialize<UserCreatedFact>(message);

                        usersAppService.InsertUser(userCreatedFact);
                    }
                }
                catch (Exception e)
                {
                    logger.LogInformation("An error ocurred while tried to process message, error: {@erro}", e);
                    throw;
                }
                finally
                {
                    consumer.Close();
                    await Task.CompletedTask;
                }
            }
        }
    }
}
