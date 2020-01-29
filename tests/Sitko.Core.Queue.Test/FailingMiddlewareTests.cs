using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;

namespace Sitko.Core.Queue.Tests
{
    public class FailingMiddlewareTests : BaseTestQueueTest<FailingMiddlewareQueueTestScope>
    {
        public FailingMiddlewareTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task FailingPublish()
        {
            var scope = GetScope();

            var queue = scope.Get<IQueue>();

            var publishResult = await queue.PublishAsync(new TestMessage());
            Assert.False(publishResult.IsSuccess);
        }

        [Fact]
        public async Task FailingReceive()
        {
            var scope = GetScope();

            var queue = scope.Get<IQueue>();

            var mw = scope.Get<FailingMiddleware>();


            var received = false;
            await queue.SubscribeAsync<TestMessage>((message, context) =>
            {
                received = true;
                return Task.FromResult(true);
            });

            mw.FailOnPublish = false;
            var publishResult = await queue.PublishAsync(new TestMessage());
            Assert.True(publishResult.IsSuccess);
            Assert.False(received);

            mw.FailOnReceive = false;

            publishResult = await queue.PublishAsync(new TestMessage());
            Assert.True(publishResult.IsSuccess);
            Assert.True(received);
        }
    }

    public class FailingMiddlewareQueueTestScope : BaseTestQueueTestScope
    {
        protected override void ConfigureQueue(TestQueueConfig config, IConfiguration configuration,
            IHostEnvironment environment, string name)
        {
            base.ConfigureQueue(config, configuration, environment, name);
            config.RegisterMiddleware<FailingMiddleware>();
        }
    }

    public class FailingMiddleware : IQueueMiddleware
    {
        public bool FailOnPublish { get; set; } = true;
        public bool FailOnReceive { get; set; } = true;

        public Task<QueuePublishResult> OnBeforePublishAsync(object message, QueueMessageContext messageContext)
        {
            var result = new QueuePublishResult();
            if (FailOnPublish)
            {
                result.SetError("Middleware failed publish");
            }

            return Task.FromResult(result);
        }
        
        public Task<bool> OnBeforeReceiveAsync(object message, QueueMessageContext messageContext)
        {
            return Task.FromResult(!FailOnReceive);
        }
    }
}