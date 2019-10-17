# UML Диаграммы
1. [Use Case](#1)<br>
1.1 [Actors](#1.1)<br>
1.2 [Flow of events](#1.2)<br>
1.2.1 [Registration](#1.2.1)<br>
1.2.2 [Login](#1.2.2)<br>
1.2.3 [Click cell](#1.2.3)<br>
1.2.4 [View user information](#1.2.4)<br>
1.2.5 [Configure theme settings](#1.2.5)<br>
2. [Activity Diagram](#2)<br>
2.1 [Registration](#2.1)<br>
2.2 [Game Activity](#2.2)<br>
2.3 [Cell click activity](#2.3)<br>
3. [Sequence Diagram](#3)
4. [State Diagram](#4)
5. [Class Diagram](#5)
6. [Component Diagram](#6)
7. [Deployment Diagram](#7)



### 1. Use Case Diagram<a name="1"></a>
Use Case Diagram of Tic-Tac-Toe game:
![Use Case](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/UseCase/UseCase.jpg)
#### 1.1 Actors<a name="1.1"></a>
Actors | Description
--- | ---
Anonymous user|Person that use the application without authorization
Registered user|Person that use the application in authorized way that provides user statistics.

#### 1.2 Flow of events<a name="1.2"></a>
##### 1.2.1 Registration<a name="1.2.1"></a>
**Describtion.** "Registration" provides to new user ability to store his personal achievments in the game and observe them in the game 
Flow of events:
1. User presses "Register" button on the Authorization screen
2. User enters "Username", "Password" in required fields.
4. Applications verifies data consistency and unique credentials.Error message when data is wrong.Return to the 2 step.
5. User presses Register button.
6. Application adds new user in the database
7. End.
##### 1.2.2 Login<a name="1.2.2"></a>
**Описание.** "Login" provides user ability to login under existing credentials.
Flow of events:
1. User enters "Username", "Password" fields in the required fields.
2. Application validates entered data according to the restrictions.
3. User presses "Login" button on the Login screen.
4. In case data is wrong return to the step 1
5. Application authorizes the user and changes screen to MainActivity.
6. End.
##### 1.2.3 Cell on the board clicked<a name="1.2.3"></a>
**Описание.**"Cell on the board clicked" allows user to make turn in the main game stage.
Flow of events:
1. User presses empty cell on one of the localboards.
2. Application marks the cell accroring to the user mark.
3. Application calculates the score on the board according to changes.
4. End.
Alternate thread А1:
1. User clicks marked cell.
2. The cell is disabled.
3. User keeps the turn and return to step 1.
4. End.
##### 1.2.4 View User Information<a name="1.2.4"></a>
**Описание.** "View User Information" allows authorized user observe personal game results.
1. User presses on the User Info tab.
2. Current screen is changed on User Info screen
3. User can observe stats and records.
4. End.
##### 1.2.5 Configure theme settings<a name="1.2.5"></a> 
**Описание.** "Configure theme settings" allows user to customize application theme settings
Поток событий:
1. Users presses Theme Settings tab on the MainActivity Screen.
2. Current screen is changed on Theme setting screen.
3. User can choose the theme he likes from provided.
4. User chooses one theme.
5. Application dynamically changes theme settings according to choice. 
6. User leaves theme settings screen.
8. End.
### 2. Activity Diagram<a name="2"></a>
##### 2.1 Registration<a name="2.1"></a> 
When the user registers in application in case on valid data new entity in the database is created. If data is invalid user has to enter
valid data once again.
![Register activity](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/Activity/RegistrationActivity.jpg)
##### 2.2 Game Activity<a name="2.2"></a> 
On every turn application calculates current game status and analyzes if there is a win condition. If cell is already marked user keeps the turn.
![Game activity](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/Activity/GameActivity.jpg)
##### 2.3 Cell click activity <a name="2.3"></a> 
On the game stage if the disabled cell is clicked user keeps the turn. In other case the cell is marked and turn changes.
![Cell click activity](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/Activity/CellActivity.jpg) 
### 3. Sequence Diagram<a name="3"></a>
Sequence Diagram of main options to use the application:
![Sequence Diagram](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/Sequence/SequenceDiagram.jpg)
### 4. State Diagram<a name="4"></a>
State Diagram to describe the cell behaviour when user interacts with it during the game stage.
![State Diagram](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/State/StateDiagram.jpg)
### 5. Class Diagram<a name="5"></a>
Class diagram illustrates how the system is designed and how components interact with each other when the application is running.
![Class Diagram](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/Class/Tic-Tac-Toe.jpg)
### 6. Component Diagram<a name="6"></a>
Component diagram describes how components are wired and provides the abstraction to observe how data moves throught the application. 
Ultimate Tic-Tac-Toe game is designed as WPF applicaiton that is highly adapted for MVVM architecture pattern. It has native databinding and provides easy tools for using it.
![Component Diagram](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/Component/Component.jpg)
### 7. Deployment Diagram<a name="7"></a>
All soft is stored and launched on the Windows OS.Database that stores user data would be stored on the application server that is deployed locally and hosts on the same PC that Desktop Client. That way it can track data of games that were played on that PC between two user. Both Client and Server should have .NET Framework 4.8 in order to launch required soft. Database woudl me managed by MSSQL DBMS so it is also should be deployed locally. Client should have application exe file in order to launch the application.
![Deployment Diagram](https://github.com/VladislavTikh/TicTacToe/blob/master/Diagrams/Deployment/Deployment.jpg)




