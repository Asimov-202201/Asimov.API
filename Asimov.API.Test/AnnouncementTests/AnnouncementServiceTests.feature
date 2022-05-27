Feature: AnnouncementServiceTests
	As a Developer
	I want to add new Announcement through API
	So that It can be available for applications.

	Background:
		Given the Endpoint https://localhost:5001/api/v1/announcements is available
		And A Director is already registered in Director's Data
		  | FirstName | LastName   | Age | Email                  | Password    | Phone     |
		  | Ricardo   | De la Cruz | 42  | ric.cruz1212@gmail.com | Ss924@d#p_s | 918274009 |

@announcement-adding
Scenario: Add Announcement
	When A Post Request to Announcement is sent
	  | Title     | Description                 | DirectorId |
	  | Meeting 1 | New competences to be added | 1          |
	Then A Response with Status 200 is received in Announcement
	And A Announcement Resource is included in Response Body
	  | Title     | Description                 | DirectorId |
	  | Meeting 1 | New competences to be added | 1          |
   