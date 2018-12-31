using KenticoCloud.Delivery;
using Pchp.Core;
using System;


namespace kc_peachpie_console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var ctx = Context.CreateConsole(string.Empty, args))
            {
                ctx.Include(null, @"vendor\autoload.php");
                //TestInterop1(ctx);
                TestInterop2(ctx);
            }
            Console.ReadLine();
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
            // var urlBuilder = new UrlBuilder(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3", false); // works

            // All arguments provided
            // Fails with 'Operation is not valid due to the current state of the object.' when creating urlBuilder
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3", 
                PhpValue.Null, PhpValue.Null, PhpValue.False, PhpValue.False, PhpValue.Create(0)); 

            PhpValue result = deliveryClient.getItems();
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
