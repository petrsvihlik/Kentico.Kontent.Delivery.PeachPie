using KenticoCloud.Delivery;
using KenticoCloud.Delivery.Models.Types;
using Models;
using Pchp.Core;
using System;
using Xunit;

namespace kc_peachpie_test
{
    public class PeachPieTests : IDisposable
    {
        private Context ctx;
        public PeachPieTests()
        {
            Context.AddScriptReference(typeof(UrlBuilder).Assembly);
            Context.AddScriptReference(typeof(Article).Assembly);

            ctx = Context.CreateConsole(string.Empty, string.Empty);
            ctx.Include(string.Empty, @"vendor\autoload.php", true, true);

        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        [Fact]
        public void TestInteropUrlBuilder()
        {
            // Arrange
            var urlBuilder = new UrlBuilder(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3", false);

            // Act
            var url = urlBuilder.getItemUrl("home", PhpValue.Null);

            // Assert
            Assert.StartsWith("https://deliver.kenticocloud.com", url.ToString());
        }

        [Fact]
        public void TestInteropGetTypePhp()
        {
            // Arrange
            Example x = new Example(ctx);

            // Act
            var result = x.TestGetType();

            var ct = (ContentType)result.ToClr();
            var system = (ContentTypeSystem)ct.system.ToClr();

            // Assert
            Assert.Equal("Article", system.name);
        }

        [Fact]
        public void TestInteropInstantiation()
        {
            // Arrange
            Example x = new Example(ctx);

            // Act
            var result = x.TestInstantiation();

            // Assert
            Assert.IsType<Article>(result.ToClr());
        }

        [Fact]
        public void TestInstantiationWithTypeName()
        {
            ctx.DeclareType<Article>();

            // Arrange
            Example x = new Example(ctx);

            // Act
            var result = x.TestInstantiationWithTypeName(@"\Models\Article");

            // Assert
            Assert.IsType<Article>(result.ToClr());
        }

        [Fact]
        public void TestInteropGetType()
        {
            // Arrange
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3",
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0));

            // Act
            var result = deliveryClient.getType("article");

            var ct = (ContentType)result.ToClr();
            var system = (ContentTypeSystem)ct.system.ToClr();

            // Assert
            Assert.Equal("Article", system.name);
        }

        [Fact]
        public void TestInteropGetItem()
        {
            // Arrange
            ctx.DeclareType<Article>();
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3",
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0))
            {
                typeMapper = PhpValue.FromClass(new CustomTypeProvider())
            };

            // Act
            var result = deliveryClient.getItem("coffee_beverages_explained");

            //// Assert
            Assert.IsType<Article>(result.ToClr());
            Assert.Equal("Coffee Beverages Explained", (result.ToClr() as Article).title);
            Assert.StartsWith("Espresso and filtered coffee", (result.ToClr() as Article).summary);
        }
    }
}
