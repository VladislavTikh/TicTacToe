# Test Plan
 ### Сontent
  1. [Introduction](#1)
  2. [Test Objects](#2)
  3. [Risks](#4)
  4. [Testing aspects](#5)<br>
  5. [Test approach](#6)
  6. [Presentation of results](#7)
  7. [Conclusion](#8)
  <a name="1"></a>
 ## 1. Introduction
Content of this document describes test plan desktop-application "Ultimate Tic-Tac-Toe". Purpose of testing - ensuring in application functionality according to SRS.
<a name="2"></a>
 ## 2. Test Objects
### 1. Functional suitability
-   #### Functional completness
    A set of application features should cover all the features described in SRS.
-   #### Functional correctness
    The application must perform all the declared functions correctly.
-   #### Functional expediency.
    There are no unclaimed functions that would prevent the application from performing its original tasks.
### 2. Ease of use
-   #### UI Availability
    Object controls should always be available to the user.
-   #### Relevance
    All changes occur in real time.
<a name="3"></a>
## 3. Risks
Risks could be:
- Application doesn't support any OS than Windows
- Applcation requires .NET Framework 4.8
- Application requires local DB storage like VS local or MSMS
<a name="4"></a>
 ## 4. Testing Aspects
During testing, the implementation of the basic functions of the application should be verified, which include:  
1. Start the game
2. Login/Register
3. Choose theme settings
4. Win the game
5. Lose the game
6. Draw the game
7. View game rules
8. View user profile
9. Start second game in a row
10. Close the application
11. Intuitive gameplay
12. Perfomance

### Functional requirments:
#### 1. Start the game
This use case needs to be tested for choices when:
- You are registered in the gamde
- You are logged in the game

#### 2. Login/Register
This use case needs to be tested for input processing (Input validation).

#### 3. Choose theme settings
This use case needs to be tested for correct changing of color theme depending on the current activated theme.

#### 4. Lose the game
This use case needs to be tested for the case when opponent has 3 global marks in a row. Output message should be displayed.

#### 5. Win the game 
This use case needs to be tested for the case when you have 3 global marks in a row. Output message should be displayed.

#### 6. Draw the game 
This use case needs to be tested for the case when no empty cells and noone has 3 global marks in a row. Output message should be displayed.

#### 7. Review the game rules
This use case needs to be tested for the case when you have clicked "Rules" tab in the main menu. Text with rules should be displayed.

#### 8. View user profile
This use case needs to be tested for the case when you have clicked "Profile" tab in the main menu. Your wins loses and username should be displayed.
Diagram with winrate.

#### 9. Start second game in a row
This use case needs to be tested for the case when the game has ended. After pressing restart button field should become availiable again with all cells empty.

#### 10. Close the app 
This use case needs to be tested for the case when you press "Exit" icon in the right left corner of main window.

### Non-functional requirments:
#### 1. Clear gameplay
User should clearly understand application worklof after 1-3 usages.

#### 2. Perfomance
No delays and freezes during the game

<a name="5"></a>
## 5. Testing approaches
For the testing of the application you need to manualy ensure every test case.

<a name="6"></a>
## 6. Presentation of results
Results of testing are displayed in [document](https://github.com/VladislavTikh/TicTacToe/blob/master/Testing/Test%20results.md).

<a name="7"></a>
## 7. Conclusion
This test plan allows you to test the main functionality of the application. Successful completion of all tests with a high probability can indicate good performance, and that this software works correctly.

    
