Feature: Functionality around TM Page
	
Scenario: I am able to create the TM
	Given I am logged into the site
	And I am at the TM page
	When I click the create new 
	And I enter the details for the new TM
	And I click the save 													
	And I click the last page 
	Then Validate the TM is created

Scenario: I am able to edit the TM
	Given I am logged into the site
	And I am at the TM page
	When I click the last page 
	And I click the edit 
	And I edit the details for the TM
	And I click the save 
	And I click the last page 
	Then Validate that TM I edited was saved

Scenario: I am able to delete the TM
	Given I am logged into the site
	And I am at the TM page
	When I click the delete 
	And I click the ok button
	Then Validate the TM is deleted

