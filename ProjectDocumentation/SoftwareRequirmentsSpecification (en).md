# Requirements Document
### Contents
1. [Introduction](#1)
2. [User Requirements](#2) <br>
  2.1. [Software Interfaces](#2.1) <br>
  2.2. [User Interfaces](#2.2) <br>
  2.3. [User Characteristics](#2.3) <br>
3. [System Requirements](#3) <br>
  3.1 [Functional Requirements](#3.1) <br>
  3.2 [Non-Functional Requierements](#3.2) <br>
    3.2.1 [Software Quality Attributes](#3.2.1) <br>
      3.2.1.1 [Usability requirements](#3.2.1.1) <br>
      3.2.1.2 [Security requirements](#3.2.1.2) <br>
	3.2.2 [Limitations](#3.2.2) <br>
 4. [Analogues](#4) <br>
 
 ### Glossary
 
 ### 1. Introduction <a name="1"></a>
There are plenty of mobile and desktop tictactoe applications that allow you to play with bots or human opponent. Regular tictactoe game is quite simple and doesn't require you to think about your moves a lot, all possilbe moves have already been calculated and game is in "Draw death" position right now. If both players play perfect game it 
inevitably ends up in draw.There is an upgrade of this well-known game that's called Ultimate(super) tic-tac-toe that requires much more attention and effort to win the game. It's hard to precalculate the outcome of the game and that brings new interest in gameplay.This gamemode poorly developed and existing applications don't provide appropriate comfort level. Web applications are full of advertising and have poor user experience. Ultimate TicTacToe is the application with conventient interface and simple logic.

### 2. User Requirements <a name="2"></a>
#### 2.1. Software Interfaces <a name="2.1"></a>
The project uses C# language.WPF is used to implement Windows desktop application.MSSQL database is used to store user data;Entity Framework is used as ORM to 
increase development speed abstract from the database relational represenation.
#### 2.2. User Interfaces <a name="2.2"></a>
- Login/Register initial screen
  ![Login/Register initial screen](https://github.com/VladislavTikh/TicTacToe/blob/master/Mockups/LoginScreen.png)
- Rules Screen
  ![Rules Screen](https://github.com/VladislavTikh/TicTacToe/blob/master/Mockups/RulesScreen.png)
- User Info
  ![User Info](https://github.com/VladislavTikh/TicTacToe/blob/master/Mockups/UserInfoScreen.png) 
- Game Screen
  ![Game Screen](https://github.com/VladislavTikh/TicTacToe/blob/master/Mockups/GameScreen.png)

#### 2.3. User Characteristics <a name="2.3"></a>
The target audience:
* Users that interested in classic game but want to increase the difficulty of the game, fans of strategic games. 

### 3. System Requirements <a name="3"></a>
#### 3.1. Functional Requirements <a name="3.1"></a>
The user is provided with the following options:

| Function | Requirements | 
|:---|:---|
| Review rules | When you click "Rules" tab you will be provieded with detailed game rules. |
| Theme change | It's possible to choose application theme in specific screen. |
| Game stage | Screen that displays current game and allows players perform turn-based moves. |
| View user information | Displays users information. Amount of wins, loses. |
| Registration | When you click "Register" tab with valid data new account with persional data is created in database.|
| Login | When you click "Login" with valid data you are authentificated under your credentials. |
| Unauthorized mode | If you don't want to save your credetinals in the system you can play it in authorized mode. |

### 3.2 Non-Functional Requierements <a name="3.2"></a>
#### 3.2.1 Software Quality Attributes <a name="3.2.1"></a>
Since this application is desktop and doesn't interact with internet connection perfect user experience and absence of delays is guaranteed.That application doesn't require a lot of resources and can be launched even on the old systems. It's quite straightforward approach in using the application so users don't need any knowledge in computers sphere. Users personal data encoded inside the application.
##### 3.2.1.1 Usability requirements <a name="3.2.1.1"></a>

##### 3.2.1.2 Security requirements <a name="3.2.1.2"></a>
1. Regular user is unable to access database inforamation.
2. Personal data is encrypted.User's passwords are saved in the database as hash.
#### 3.2.2 Limitations <a name="3.2.2"></a>
* The application is availiable on Windows platform.
* The application requires .NET Framework 4.6.2 and higher.
* For user registration database instance should be deployed locally.
### 4. Analogues <a name="4"></a>
