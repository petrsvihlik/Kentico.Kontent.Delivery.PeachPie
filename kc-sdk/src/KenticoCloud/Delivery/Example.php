<?php

namespace KenticoCloud\Delivery;
use KenticoCloud\Delivery\DeliveryClient;
use Models\Article;

class Example
{
	public function TestInstantiation()
	{
		return new \Models\Article();
	}	

	public function TestInstantiationWithTypeName()
	{
		$type = \Models\Article::class;
		return new $type();
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
