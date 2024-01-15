Feature: Reports

User can run a report and view it's results

@smoke
Scenario: Run Report
	Given Login
	When Navigate to Reports
	And Find report
	And Run report
	Then Check results
