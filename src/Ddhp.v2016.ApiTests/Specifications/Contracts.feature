Feature: Contracts

Scenario: Showing a club's stats
	Given the test data from 2012 with in-memory database
	And the in-memory webapi runner
	And the round is 201205
	And my club is the Cheats
	When I request contracts for the club and round
	Then I have 24 contracts returned
	And the following contracts are returned:
		|FirstName	| LastName		| FromRoundId	|	ToRoundId	|
		|Cameron	|	Bruce		|	201101		|	201210		|
		|Andrew		|	Swallow		|	201201		|	201224		|
		|Scott		|	Pendlebury	|	201201		|	201224		|
		|Jared		|	Brennan		|	201101		|	201324		|
		|Jarrad		|	McVeigh		|	201201		|	201424		|
		|Brent		|	Stanton		|	201201		|	201224		|
		|Kade		|	Simpson		|	201101		|	201224		|
		|Adam		|	Schneider	|	201101		|	201224		|
		|Jarrod		|	Harbrow		|	201101		|	201211		|
		|Robert		|	Warnock		|	201201		|	201224		|
		|Jack		|	Riewoldt	|	201201		|	201224		|
		|Mark		|	Nicoski		|	201201		|	201224		|
		|Shaun		|	Grigg		|	201201		|	201524		|
		|Shaun		|	Hampson		|	201201		|	201324		|
		|Cale		|	Hooker		|	201101		|	201224		|
		|Luke		|	Breust		|	201201		|	201324		|
		|Hamish		|	Hartlett	|	200901		|	201224		|
		|Tyrone		|	Vickery		|	200901		|	201224		|
		|Aaron		|	Cornelius	|	201001		|	201224		|
		|Daniel		|	Menzel		|	201001		|	201211		|
		|David		|	Swallow		|	201101		|	201324		|
		|Max		|	Gawn		|	201201		|	201224		|
		|Orren		|	Stephenson	|	201201		|	201324		|
		|Ahmed		|	Saad		|	201201		|	201424		|