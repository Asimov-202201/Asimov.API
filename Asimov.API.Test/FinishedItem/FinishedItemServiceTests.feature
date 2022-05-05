Feature: FinishedItemServiceTests
As a Teacher
I want to complete an Item through API
So that It can be available for applications.

    Background: 
        Given the Endpoint https://localhost:5001/api/v1/items is available for FinishedItemServiceTests
        And A Course is already stored in the table courses
          | Id | Name    | Description                | State |
          | 1  | Algebra | A branch of Mathematics... | false |
        And A Item is already stored in the table items
          | Id | Name  | 					Value                  | State | CourseId |
          | 1  | Video | https://www.youtube.com/embed/LwCRRUa8yTU | false |   1      |
   
    @FinishedItem
    Scenario: Complete Item
        When he clicks the complete button of an item 1
          | Name  | 					Value                 | State | CourseId |
          | Video | https://www.youtube.com/embed/LwCRRUa8yTU | true  |   1      |
        Then A Response with Status 200 is received in Items
        And the item will be completed and the progress of a course increases
          | Id | Name  | 					Value                  | State | CourseId |
          | 1  | Video | https://www.youtube.com/embed/LwCRRUa8yTU | true  |   1      |