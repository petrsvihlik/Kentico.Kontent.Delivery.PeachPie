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
                //TestInteropPhpClass(ctx);
                //TestInteropGetType(ctx);
                //TestInteropUrlBuilder(ctx);
                TestInteropGetItem(ctx);
            }
            Console.ReadLine();
        }

        private static void TestInteropUrlBuilder(Context ctx)
        {
            var urlBuilder = new UrlBuilder(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3", false);
            var url = urlBuilder.getItemUrl("home", PhpValue.Null);
            Console.WriteLine(url);
        }

        public static void TestInteropPhpClass(Context ctx)
        {
            // Fails with 'Operation is not valid due to the current state of the object.'
            Example x = new Example(ctx);
            var content = x.Test();
            Console.WriteLine(content.String);
        }

        public static void TestInteropGetType(Context ctx)
        {                        
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3",
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0));

            var result = deliveryClient.getType("article");
            
            foreach (var item in result)
            {
                Console.WriteLine(item.Key.ToString());
            }
        }

        public static void TestInteropGetItem(Context ctx)
        {
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3",
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0));
                                    
            var result = deliveryClient.getItem("about_us");
            foreach (var item in result)
            {
                var classa = item.Value.ToClass();
                var itemName = item.Value.GetPropertyValue("name").ToString();
                Console.WriteLine(itemName);
            }
        }
    }
}
