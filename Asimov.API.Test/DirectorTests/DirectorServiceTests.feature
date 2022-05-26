Feature: DirectorServiceTests
	As a Developer
	I want to register a new Director through API
	So that It can be available for applications.
	
	Background:
		Given the Endpoint https://localhost:5001/auth/sign-up/director

@director-register
Scenario: Sign-up Director
	When A Post Request is Sent 
		| FirstName | LastName   | Age | Email                 | Password | Phone |
		| Ricardo   | De la Cruz | 42  | fernan.82@outlook.com | Ss924@d#p_s | 918274009 |
	Then A Response with Status 200 is Received
	And A Message of "Registration successful." is included in Response Body

@director-register
Scenario: Sign-up Director with existing Email
	Given A Director is already stored
		| FirstName | LastName | Age | Email                 | Password | Phone     |
		| Luis      | Castillo | 39  | fernan.82@outlook.com | Pls99281 | 992121083 |
	When A Post Request is Sent
		| FirstName | LastName | Age | Email                 | Password | Phone     |
		| Juanito   | Castillo | 40  | fernan.82@outlook.com | Pls99281 | 982182734 |
	Then A Response with Status 400 is Received
	And A Message of "Email fernan.82@outlook.com is already taken." is included in Response Body