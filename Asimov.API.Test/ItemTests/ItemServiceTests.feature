Feature: ItemServiceTests
As a Director
I want to add new Item through API
So that It can be available for applications.
	
    Background:
        Given the Endpoint https://localhost:5001/api/v1/items is available
        And A Course is already stored
          | Id | Name    | Description                | State |
          | 1  | Algebra | A branch of Mathematics... | true  |

    @item-adding
    Scenario: Add Item
        When A Post Request is sent to Item
          | Name          | Value                     | State | CourseId |
          | Documentation | This is the theorem of... | true  | 1        |
        Then A Response with Status 200 is received in Item
        And A Item Resource is included in Response Body
          | Name          | Value                     | State | CourseId |
          | Documentation | This is the theorem of... | true  | 1        |

    @item-adding-Invalid
    Scenario: Add Item with Invalid Course
        When A Post Request is sent to Item
          | Name  | Value                       | State | CourseId |
          | Video | https://www.youtube.com/... | true  | -1       |
        Then A Response with Status 400 is received in Item
        And A message of "Invalid Course" is included in Response Body