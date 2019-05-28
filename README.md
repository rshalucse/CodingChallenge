## Synopsis

The **Paint Calculator** is a hypothetical project that calculates how many gallons of paint would be required to paint a number of rooms.

## Requirements

* Python 3 (not 2)
* Pip
***Shalini added
***Command line Git


## What we're looking for

* Install Python / Pip
* Run application
* Write tests against the application. They do not have to be in Python, and should be in whatever language you are most comfortable with.
* Write a test plan for the application.  You are free to determine the structure and length of the test plan.
* You are allowed to change any of the source code as you see fit to make things easier for yourself. You are encouraged to fix any bugs you discover.
* Explain any problems you had while writing the tests, and what you did to make it easier. Pointing to localhost for the application is OK.
* What would be the proper level of execution for tests of this application?  If this differs from the testing level you wrote tests for, please explain where they would be better suited.

## Instructions

Because each applicant's code should be secret from one another, we should not submit it to the same repo.

1. Clone the repo (do not fork) 
***Shalini added
***'cd <to the target directory>'
***'git clone https://github.com/joecarlyon/paint-calculator.git'
2. Create a new public repo on Github
2a.
***Shalini added
***Local directory needs a .git folder to be recognized by git as a git repo
*** 'git init .'  ***this initializes an empty git repo
3. Add the new repo as as a new remote
* `git remote add acme <url>`
4. Initialize the new repo with what is cloned
***Shalini added
***'git commit -m "Initial commit"'*** this is needed in order to perform the next step
* `git push acme master`
5. Create a new branch off of master to put your changes on
6. Run the application locally
***Shalini added
***Goto the directory where pip3.exe is installed and run this command pointing to the directory where your code is installed
* `pip3 install -e .`
***Shalini added
***Goto the directory where python is installed and run this command pointing to the app directory where your code is installed 
* `python3 app/run.py`
7. Perform testing and debugging activities

## Submitting 

To make it easier on everybody, it's best if we use a PR to diff what work was completed.

1. Make any and all commits to your new branch and push the changes
* `git push acme <branch>`
2. Create a PR to your new repo
3. Make sure you include your test plan and any automated tests, as well as update this README to instruct someone on how to run the tests
4. Include any other text in a file - which tests would be suited for a different level of execution, or any problems encountered...etc
5. Send the link to the PR

## Running Tests

Write instructions for how a user executes the automated tests you created.

PRE-REQS:
--------
0. Please note - instructions above had missing steps, those have been modified as well.
1. Need Visual Studio to execute these tests - can get it from - https://visualstudio.microsoft.com/downloads/ (Community free download 2019 version) or use a licensed professional version
2. Project repository can be found under - https://github.com/rshalucse/CodingChallenge
3. api.py has been modified in order to fix sq.ft and gallons calculation, this has been checked in 
4. Chrome browser is needed to execute the tests

Test plan assumptions:
----------------------
1. Test plan assumes a lot of things, with requirements in place the test plan can be made more formal with actual expectations 
rather than hypothetical expectations. Please note, test plan is kept at a high level.

To execute tests:
-----------------
1. Incorporate the modified api.py file into the application, start website. All tests will run against website hosted locally @ http://127.0.0.1:5000
2. Open the solution from ..\CodeChallenge\CodeChallenge\CodeChallenge.sln
3. Run tests from the playlist, or select each test from Tests.cs file and run them
4. Tests have a 3 layered structure where: Tests are written in Tests.cs that belongs to the Regression project, Business flow is written in Business.cs that belongs to Business project and page objects are define in model.cs that belongs to Model project.
5. Only a handful of happy path test cases have been automated with more emphasis on building a robust extensible framework 
6. Please note tests execute very quickly, debug them in order to note what they do, didn't add unecessary wait to show slower execution

Test framework enhancements for the future:
-------------------------------------------
1. WaitForPage load - this needs to be implemented on the results page and any other relevant pages
2. Logging after each step, so anyone debugging the tests can understand what is going on by looking at the logs 
3. Exception handling with try/ catch exception can be added
4. Ability to execute the tests on multiple browsers - Firefox, Edge etc
5. Automation of other happy path scenarios and unhappy path scenarios

Application enhancements for the future:
----------------------------------------
Explain any problems you had while writing the tests, and what you did to make it easier:
1. Page that displays fields to enter coordinates and the results page - element names can match the row number - for example - row 1, 
should match element names like length 1, width 1, height 1 on the coordinates page and likewise on results should be room-1. I had to 
dynamically append the row number / coordinates in order to validate that the expected and actuals matched

Bugs fixed:
------------
1) Results calculation for sq.ft and #of gallons needed had a defect in api.py file

What would be the proper level of execution for tests of this application?  If this differs from the testing level you wrote tests for, please explain where they would be better suited.
I have written tests that covered end to end workflows. The websites I had tested earlier needed backend validation from DB
perspective as well, I had to write code to perform DB validations as well along with UI validations. Apart from thiat I would add tests at 
the API/ service level as well to get complete coverage.
