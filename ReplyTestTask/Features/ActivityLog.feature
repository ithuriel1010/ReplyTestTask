Feature: ActivityLog

A short summary of the feature

@tag1
Scenario: Remove events from the activity log
	Given Login
	When Navigate to Activity Log
	And Select first <Number> items
	And Delete selected actions
	Then Check if <Number> items were deleted

Examples: 
| Number |
| 3      |