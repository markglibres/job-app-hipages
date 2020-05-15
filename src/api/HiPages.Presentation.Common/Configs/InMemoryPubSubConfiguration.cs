using BizzPo.Core.Application;
using HiPages.Application.Integration.Publish;
using HiPages.Application.Integration.Subscribe.AccountCreated;
using HiPages.Infrastructure.Messaging.InMemoryPubSub;
using Microsoft.Extensions.DependencyInjection;

namespace HiPages.Presentation.Common.Configs
{
    public static class InMemoryPubSubConfiguration
    {
        public static void AddInMemoryPublishEvents(this IServiceCollection services)
        {
            services
                .AddTransient<IIntegrationEventPublisherService<ContactAddedEvent>,
                    InMemoryPublisherService<ContactAddedEvent>>();
        }

        public static void AddInMemorySubscribeEvents(this IServiceCollection services)
        {
            services.AddTransient<IIntegrationEventSubscriberService<AccountCreatedEvent>,
                InMemorySubscriberService<AccountCreatedEvent>>();
        }
    }
}