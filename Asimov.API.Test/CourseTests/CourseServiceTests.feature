Feature: CourseServiceTests
	As a Developer
	I want to add new Course through API
	So that It can be available for applications.
	
	Background: 
		Given the Endpoint https://localhost:5001/api/v1/courses is available

@course-adding
Scenario: Add Course
	When A Post Request is sent to Course
	| Name    | Description                | State |
	| Algebra | A branch of Mathematics... | true  |
 	Then A Response with Status 200 is received in Course
 	And A Course Resource is included in Response Body
      | Name    | Description                | State |
      | Algebra | A branch of Mathematics... | true  |