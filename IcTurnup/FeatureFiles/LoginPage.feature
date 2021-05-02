Feature: LoginPage
	In order to test the Login functionality 
	As a user
	I want to be able to validate the login works
	
Scenario: When valid creds are used should result in successful login
	Given I am at the login page
	And I validate that i am at the login page
	When I enter valid creds
	And I click the login button
	Then I should be logged in successfully

Scenario: When invalid username and invalid password are used should result in failure to login
	Given I am at the login page
	And I validate that i am at the login page
	When I login with <username> and with <password>
	And I click the login button
	Then I should be not logged in
	Examples:
	| username| password |
	| hari123 | 123123   |
	| hari    | 000test  |
	| abc123  | testtest |

