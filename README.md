# Kentico Kontent Delivery SDK for PHP running on .NET via PeachPie
[![Build status](https://ci.appveyor.com/api/projects/status/l1n1lsb5u8rjbsnc?svg=true)](https://ci.appveyor.com/project/petrsvihlik/peachpietests)

![Kentico Cloud Delivery SDK for PHP running on .NET via PeachPie](https://i.imgur.com/DIkxQvd.png)




Read more about C# and PHP interop at https://www.peachpie.io/2019/02/using-c-in-php-and-vice-versa.html

Use https://ci.appveyor.com/nuget/peachpie for debugging.

# Developing

## Updating the Kentico Kontent SDK
1. Delete the contents of [`/Kentico.Kontent.Delivery.PHP/`](https://github.com/petrsvihlik/Kentico.Kontent.Delivery.PeachPie/tree/master/Kentico.Kontent.Delivery.PHP), keep only the `.msbuildproj` file
2. Download the SDK at https://github.com/Kentico/kontent-delivery-sdk-php
3. Copy over the `src` folder and `composer.json` to `/Kentico.Kontent.Delivery.PHP/`
4. Run `composer install --no-dev`
5. Persist the [Example.php](https://github.com/petrsvihlik/Kentico.Kontent.Delivery.PeachPie/blob/master/Kentico.Kontent.Delivery.PHP/src/Kentico/Kontent/Delivery/Example.php) file
6. Done
