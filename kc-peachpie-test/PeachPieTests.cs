using System;
using Xunit;
using Pchp.Core;
using KenticoCloud.Delivery;
using System.Reflection;
using Models;
using KenticoCloud.Delivery.Models.Types;

namespace kc_peachpie_test
{
    public class PeachPieTests : IDisposable
    {
        Context ctx;
        public PeachPieTests()
        {
            Context.AddScriptReference(typeof(UrlBuilder).Assembly);
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
            var urlBuilder = new UrlBuilder(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3", false);
            var url = urlBuilder.getItemUrl("home", PhpValue.Null);
            Assert.StartsWith("https://deliver.kenticocloud.com", url.ToString());
        }

        [Fact]
        public void TestInteropGetTypePhp()
        {
            Example x = new Example(ctx);
            var result = x.TestGetType();

            var ct = result.ToClr(typeof(ContentType)) as ContentType;
            var system = ct.system.ToClr(typeof(ContentTypeSystem)) as ContentTypeSystem;

            Assert.Equal("Article", system.name);
        }

        [Fact]
        public void TestInteropInstantiation()
        {
            Example x = new Example(ctx);
            var result = x.TestInstantiation();

            Article article = result.ToClr(typeof(Article)) as Article;

            Assert.IsType<Article>(article);
        }

        [Fact]
        public void TestInteropGetType()
        {
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3",
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0));

            var result = deliveryClient.getType("article");

            var ct = result.ToClr(typeof(ContentType)) as ContentType;
            var system = ct.system.ToClr(typeof(ContentTypeSystem)) as ContentTypeSystem;

            Assert.Equal("Article", system.name);
        }

        [Fact]
        public void TestInteropGetItem()
        {
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3",
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0));

            deliveryClient.typeMapper = PhpValue.FromClass(new CustomTypeProvider());


            var result = deliveryClient.getItem("coffee_beverages_explained");
            foreach (var item in result)
            {
                var classa = item.Value.ToClass();
                var itemName = item.Value.GetPropertyValue("name").ToString();
                Console.WriteLine(itemName);
            }
        }
    }
}
