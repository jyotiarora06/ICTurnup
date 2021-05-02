Feature: Functionality around Company Page
	
Scenario: I am able to create the Company
	Given I am logged in
	And I am at the company page
	When I click the create new button
	And I enter the details for the new company
	And I click the save company button													
	And I click the last page icon
	Then Validate the company is created

Scenario: I am able to edit the Company
	Given I am logged in
	And I am at the company page
	When I click the last page icon
	And I click the edit button
	And I edit the details
	And I click the save company button
	And I click the last page icon
	Then Validate that company I edited was saved


