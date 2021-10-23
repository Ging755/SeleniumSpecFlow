Feature: ProductFeature
	Simple calculator for adding two numbers

@mytag
Scenario: Products page should display any number of products
	Given I have logged in successfully with standard_user username and secret_sauce password
	Then any number of product items should be displayed

Scenario: Clicking on add to cart button should add product item to the cart and display remove from cart button
	Given I have logged in successfully with standard_user username and secret_sauce password
	When I press add to cart or remove from cart button
	Then product item should be added the cart and REMOVE button should be displayed

Scenario: Clicking on add to cart button should add product item to the cart and display remove from cart button and then pressing remove from cart button should remove product from the cart
	Given I have logged in successfully with standard_user username and secret_sauce password
	When I press add to cart or remove from cart button
	Then product item should be added the cart and REMOVE button should be displayed
	When I press add to cart or remove from cart button
	Then product item should be removed from the cart and ADD TO CART button should be displayed

Scenario: Clicking on sorting dropdown and selecting "Price (high to low)" sort product items correctly
	Given I have logged in successfully with standard_user username and secret_sauce password
	When I select "Price (high to low)"
	Then first item should be priced $49.99

Scenario: Clicking on sorting dropdown and selecting "Price (low to high)" sort product items correctly
	Given I have logged in successfully with standard_user username and secret_sauce password
	When I select "Price (low to high)"
	Then first item should be priced $7.99