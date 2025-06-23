Feature: Login Functionality

As a user, I want to log in to the SauceDemo website so that I can access the dashboard.

Background: 
    Given I am on the login page

    @UC-1
    Scenario Outline: Login with empty credentials
	    When I enter <username> and <password>
	    And I clear the username and password fields
	    And I click the login button
	    Then I should see the error message "Username is required"

        Examples: 
        | username      | password                  |
        | standard_user | secret_sauce              |
        | "     "       | 123456                    |
        | !@#$%^        | <script>alert(1)</script> |

    @UC-2
    Scenario Outline: Login with only username
        When I enter <username> and <password>
        And I clear the password field
        And I click the login button
        Then I should see the error message "Password is required"

        Examples: 
        | username        | password      |
        | " s "           | 123456        |
        | locked_out_user | doesntmatter  |
        | secret_sauce    | standard_user |

    @UC-3
    Scenario Outline: Login with valid credentials
        When I enter <username> and <password>
        And I click the login button
        Then I should see the dashboard title "Swag Labs"

        Examples: 
        | username      | password     |
        | standard_user | secret_sauce |
        | problem_user  | secret_sauce |
        | error_user    | secret_sauce |
        | visual_user   | secret_sauce |
