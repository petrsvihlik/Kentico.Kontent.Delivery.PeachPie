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
                TestInterop1(ctx);
                TestInterop2(ctx);
            }
            Console.ReadLine();
        }

        public static void TestInterop1(Context ctx)
        {
            Example x = new Example(ctx);
            var content = x.Test();
            Console.WriteLine(content.String);
        }

        public static void TestInterop2(Context ctx)
        {
            DeliveryClient deliveryClient = new DeliveryClient(ctx, "975bf280-fd91-488c-994c-2f04416e5ee3");
            PhpValue result = deliveryClient.getItems();
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
