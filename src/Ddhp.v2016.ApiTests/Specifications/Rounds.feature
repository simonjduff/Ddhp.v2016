Feature: Rounds

Scenario: Getting the next incomplete round
	Given the test data from 2012 with in-memory database
	And the in-memory webapi runner
	When I request the next incomplete round
	Then the round 201301 is returned