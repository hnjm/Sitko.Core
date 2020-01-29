using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;
using Sitko.Core.MessageBus;
using Xunit;
using Xunit.Abstractions;

namespace Sitko.Core.Queue.Tests
{
    public class MessageBusTests : BaseTestQueueTest<MessageBusTestScope>
    {
        public MessageBusTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task TranslateNotification()
        {
            var scope = GetScope();

            var queue = scope.Get<IQueue>();

            Guid? receivedId = null;
            var sub = await queue.SubscribeAsync<TestRequest>((testRequest, context) =>
            {
                receivedId = testRequest.Id;
                return Task.FromResult(true);
            });
            Assert.True(sub.IsSuccess);

            var mediator = scope.Get<IMediator>();
            var request = new TestRequest();
            await mediator.Publish(request);

            await Task.Delay(TimeSpan.FromSeconds(1));

            Assert.NotNull(receivedId);
            Assert.Equal(request.Id, receivedId);
        }
    }

    public class MessageBusTestScope : BaseTestQueueTestScope
    {
        protected override void ConfigureQueue(TestQueueConfig config, IConfiguration configuration,
            IHostEnvironment environment, string name)
        {
            base.ConfigureQueue(config, configuration, environment, name);
            config.TranslateMessageBusNotification<TestRequest>();
        }

        protected override Application ConfigureApplication(Application application, string name)
        {
            return base.ConfigureApplication(application, name)
                .AddModule<MessageBusModule, MessageBusModuleConfig>((configuration, environment) =>
                    new MessageBusModuleConfig(typeof(MessageBusTests).Assembly));
        }
    }

    public class TestRequest : TestMessage, INotification
    {
    }
}