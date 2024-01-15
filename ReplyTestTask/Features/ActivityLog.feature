Feature: ActivityLog

List of activities performed in the site. User can delete, export or print selected activities.

@smoke
Scenario: Remove events from the activity log
	Given Login
	When Navigate to Activity Log
	And Select first <Number> items
	And Delete selected actions
	Then Check if <Number> items were deleted

Examples: 
| Number |
| 3      |