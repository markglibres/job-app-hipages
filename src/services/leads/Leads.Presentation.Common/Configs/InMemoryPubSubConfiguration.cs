using BizzPo.Core.Application;
using Leads.Application.Integration.Publish;
using Leads.Application.Integration.Subscribe.AccountCreated;
using Leads.Infrastructure.Messaging.InMemoryPubSub;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.Presentation.Common.Configs
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