Feature: Login
	In order to access restricted site options
	As a registered NopCommerce user
	I want to be able to log in

@browser
Scenario Outline: Login using valid credentials
	Given I have a registered user on NopCommerce website
	And User is on the NopCommerce page
	When User logs in using username <username> and password <password>
	Then User should land on the Home page
	Examples:
	 | username | password   |
	 | AlphaB   | Qwerty@123 |
	 | Alpha$   | Qwerty@123 |
	

@browser
Scenario:  Login using incorrect password
	Given I have a registered user on NopCommerce website
	And User is on the NopCommerce page
	When User logs in using valid username and invalid password
	Then he should see an error message stating that the Login attempt was not successful
	#"Your login attempt was not successful. Please try again"