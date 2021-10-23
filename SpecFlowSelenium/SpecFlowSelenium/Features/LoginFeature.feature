Feature: LoginFeature
	Login page

@mytag
Scenario: Login page should be displayed
	Given I have navigated to login page
	Then Login Page should be displayed

Scenario: Login page username and password input should be displayed and empty and button should be displayed
	Given I have navigated to login page
	Then Username and password input should be displayed and empty and login button should be displayed

Scenario: Login page should display an error message if username or password is incorrect
	Given I have navigated to login page
	And I have entered wrong_username as username and wrong_password as password
	When I press the login button
	Then "Epic sadface: Username and password do not match any user in this service" error message should be displayed

Scenario: Login page should display an error message if username is not entered but password is
	Given I have navigated to login page
	And I have entered  as username and wrong_password as password
	When I press the login button
	Then "Epic sadface: Username is required" error message should be displayed

Scenario: Login page should display an error message if password is not entered
	Given I have navigated to login page
	And I have entered wrong_username as username and  as password
	When I press the login button
	Then "Epic sadface: Password is required" error message should be displayed

Scenario: Login page should login the user if Username and Password are correct
	Given I have navigated to login page
	And I have entered standard_user as username and secret_sauce as password
	When I press the login button
	Then I should be redirected to products page