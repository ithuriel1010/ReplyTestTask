Feature: Contracts

A short summary of the feature

@tag1
Scenario: Create contact
	Given Login
	When Navigate to Contacts
	And Create new contact
	And Open created contact
	Then Contract data matches
