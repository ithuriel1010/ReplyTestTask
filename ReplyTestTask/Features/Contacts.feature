Feature: Contacts

User can create, view, edit and delete contacts

@smoke
Scenario: Create contact
	Given Login
	When Navigate to Contacts
	And Create new contact
	And Open created contact
	Then Contract data matches
