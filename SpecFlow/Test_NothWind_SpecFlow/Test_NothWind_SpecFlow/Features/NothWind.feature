Feature: Login
		 To log in to the app
		 I want to open the app
		 I have to enter my username and password

@mytag
Scenario: Login
	Given I open "http://localhost:5000" url
	When I enter my username "user"
	And I enter password "user"
	And I click button 
	Then I should be on the page Home page
