Feature: AddAndCheckProduct
		 I log in
		 I add new product
		 I check info about new product

@AddCheck
Scenario: Add and check product
	Given I open "http://localhost:5000" url
	When I log in to the app
	And I go to the page All Product
	And I go to the page Create New
	And I add new product 
	And I go to the added product page
	Then I check info about new product
