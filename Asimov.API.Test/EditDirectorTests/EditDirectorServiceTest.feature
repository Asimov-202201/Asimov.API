Feature: EditDirectorServiceTest
	As a Director
	I want to edit my Director profile
	So that It can be available for applications.
	
	Background: 
		Given the Endpoint https://localhost:5001/api/v1/directors is available
		And A Director is already stored in Director's Data
		  | FirstName | LastName | Age | Email           | Password | Phone     |
		  | Julio     | Salazar  | 22  | julio@gmail.com | yulius15 | 987654321 |

	@director-profile-updating
	Scenario: Edit Director profile
		When A Update Request to Director 1 profile is sent
		  | FirstName | LastName | Age | Email           | Password | Phone     |
		  | Julio     | Zapata   | 22  | julio@gmail.com | yulius15 | 987654321 |
		Then A Response with Status 200 is received a Director
		And A Message of "User Updated Successfully." is included in Response Body of Director