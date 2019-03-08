<?php

namespace KenticoCloud\Delivery;
use KenticoCloud\Delivery\DeliveryClient;
use Models\Article;

class Example
{
	public function TestInstantiation()
	{	
		$x = new \Models\Article;
		$y = get_class($x);
		$z = $x::class;
		return $x;
	}	

	public function TestInstantiationWithString($className)
	{	
		$x = new $className;
		return $x;
	}	

	public function TestGetType()
	{	
		$client = new DeliveryClient('975bf280-fd91-488c-994c-2f04416e5ee3');
		$type = $client->getType('article');
		return $type;
		
	}

	public function TestGetItem()
	{
		$client = new DeliveryClient('975bf280-fd91-488c-994c-2f04416e5ee3');
		$item = $client->getItem('coffee_beverages_explained');
		return $item;
	}
}
