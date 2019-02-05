using KenticoCloud.Delivery;
using Pchp.Core;
using System;
using System.Reflection;

namespace kc_peachpie_console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Context.AddScriptReference(typeof(UrlBuilder).Assembly);

            using (var ctx = Context.CreateConsole(string.Empty, args))
            {
                ctx.Include(string.Empty, @"vendor\autoload.php", true, true);
                //TestInterop1(ctx);
                TestInterop2(ctx);
                TestInteropUrlBuilder(ctx); // works
            }
            Console.ReadLine();
        }

        private static void TestInteropUrlBuilder(Context ctx)
        {
            var urlBuilder = new UrlBuilder(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3", false);
            var url = urlBuilder.getItemUrl("home", PhpValue.Null);
            Console.WriteLine(url);
        }

        public static void TestInterop1(Context ctx)
        {
            // Fails with 'Operation is not valid due to the current state of the object.'
            Example x = new Example(ctx);
            var content = x.Test();
            Console.WriteLine(content.String);
        }

        public static void TestInterop2(Context ctx)
        {
            // All arguments provided
            // Fails with 'Operation is not valid due to the current state of the object.' when creating urlBuilder
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3",
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0));

            var result = deliveryClient.getType("article");
            // PhpValue result = deliveryClient.getItems();
            foreach (var item in result)
            {
                Console.WriteLine(item.Key.ToString());
            }
        }
    }
}
