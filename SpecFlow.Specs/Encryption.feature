Feature: Encryption
	In order to store my password
	As a user
	I want to encrypt it with salt and hash

@mytag
Scenario: Create hashed password
	Given I provided password	
	When I call CreateHashedPassword method
	Then I want to see hash and salt for it

Scenario: ValidateCreatedPasswordGood
	Given I have created password
	When I call Validate method with right password
	Then I want to see that passwords match

Scenario: ValidateCreatedPasswordBad
	Given I have created password 
	When I call Validate method with wrong password
	Then I want to see that passwords do not match
