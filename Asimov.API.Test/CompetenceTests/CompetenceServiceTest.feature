Feature: CompetenceServiceTests
As a Director
I want to add new Compentence through application
So that It can be available to all teachers
    
    Background:
        Given the Endpoint https://localhost:5001/api/v1/competences is available
        
    @competence-adding
    Scenario: Add Competence
        When A Post Request to Competence is sent
          | Title              | Description                  |
          | Digital Competence | The student is capable of... |
        Then A Response with Status 200 is received in Competence
        And A Competence Resource is included in Response body
          | Title              | Description                  |
          | Digital Competence | The student is capable of... |