Feature: AnnouncementServiceTests
As a Director
I want to add new Announcement through Application
So that It can be available to all teachers

    Background:
        Given the Endpoint https://localhost:5001/api/v1/announcements is available
        And A Director is already stored
          | Id | FirstName | LastName   | Age | Email                  | Password    | Phone     |
          | 1  | Ricardo   | De la Cruz | 42  | ric.cruz1212@gmail.com | Ss924@d#p_s | 918274009 |

    @announcement-adding
    Scenario: Add Announcement
        When A Post Request to Announcement is sent
          | Title     | Description                 | DirectorId |
          | Meeting 1 | New competences to be added | 1          |
        Then A Response with Status 200 is received in Announcement
        And A Announcement Resource is included in Response Body
          | Title     | Description                 | DirectorId |
          | Meeting 1 | New competences to be added | 1          |

    Scenario: Add Announcement with Invalid Director
        When A Post Request to Announcement is sent
          | Title     | Description          | DirectorId |
          | Meeting 2 | Updating competences | -1         |
        Then A Response with Status 400 is received in Announcement
        And A Message of "Invalid Director" is included in Response Body of Announcement