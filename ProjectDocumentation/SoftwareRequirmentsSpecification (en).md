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
 4. [Game Description](#4) <br>
  4.1 [Game Goals](#4.1) <br>
  4.2 [Game Rules](#4.2) <br>
 5. [Analogues](#5) <br>
 
 ### 1. Introduction <a name="1"></a>
There are plenty of mobile and desktop tictactoe applications that allow you to play with bots or human opponent. Regular tictactoe game is quite simple and doesn't require you to think about your moves a lot, all possilbe moves have already been calculated and game is in "Draw death" position right now. If both players play perfect game it 
inevitably ends up in draw.There is an upgrade of this well-known game that's called Ultimate(super) tic-tac-toe that requires much more attention and effort to win the game. It's hard to precalculate the outcome of the game and that brings new interest in gameplay.This gamemode poorly developed and existing applications don't provide appropriate comfort level. Web applications are full of advertising and have poor user experience. Ultimate TicTacToe is the application with conventient interface and simple logic.

### 2. User Requirements <a name="2"></a>
#### 2.1. Software Interfaces <a name="2.1"></a>
The project uses C# language.WPF is used to implement Windows desktop application.MSSQL database is used to store user data;Entity Framework is used as ORM to increase development speed and abstract from the database relational represenation.
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
* Users that interested in the classic game tic-tac-toe but want to increase the difficulty of the game, fans of strategic games. 

### 3. System Requirements <a name="3"></a>
#### 3.1. Functional Requirements <a name="3.1"></a>
The user is provided with the following options:

| Function | Requirements | 
|:---|:---|
| Review rules | When you click "Rules" tab you will be provieded with detailed game rules. |
| Theme change | It's possible to choose application theme in specific screen. |
| Game stage | Screen that displays current game and allows players perform turn-based moves. |
| View user information | Displays users information. Amount of wins, loses,winrate. |
| Registration | When you click "Register" tab with valid data new account with persional data is created in database.|
| Login | When you click "Login" with valid data you are authentificated under your credentials. |
| Unauthorized mode | If you don't want to save your credetinals in the system you can play it in authorized mode. |

### 3.2 Non-Functional Requierements <a name="3.2"></a>
#### 3.2.1 Software Quality Attributes <a name="3.2.1"></a>
Since this application is desktop and doesn't interact with internet connection perfect user experience and absence of delays is guaranteed.That application doesn't require a lot of resources and can be launched even on the old systems. It's quite straightforward approach in using the application so users need only basic knowledge working with PC. Users personal data encoded inside the application.
##### 3.2.1.1 Usability requirements <a name="3.2.1.1"></a>
1. Material Design controls used for modern view.
2. Smooth animations during the game and while switching screens.
3. All tabs and buttons are signed.
##### 3.2.1.2 Security requirements <a name="3.2.1.2"></a>
1. Regular user is unable to access database inforamation.
2. Personal data is encrypted.User's passwords are saved in the database as hash.
#### 3.2.2 Limitations <a name="3.2.2"></a>
* The application is availiable on Windows platform.
* The application requires .NET Framework 4.6.2 and higher.
* For user registration database instance should be deployed locally.

### 4. Game Description <a name="4"></a>
#### 4.1 Game Goals <a name="4.1"></a>
The game can be generalized to an m,n,k-game in which two players alternate placing stones of their own color on an m×n board, with the goal of getting k of their own color in a row.
##### 4.2 Game Rules <a name="4.2"></a>
Each small 3-by-3 tic-tac-toe board is referred to as a local board, and the larger 3-by-3 board is referred to as the global board.
The game starts with X playing wherever they want in any of the 81 empty spots. This move 'sends' their opponent to its relative location. For example, if X played in the top right square of their local board, then O needs to play next in the local board at the top right of the global board. O can then play in any one of the nine available spots in that local board, each move sending X to a different local board.
If a move is played so that it is to win a local board by the rules of normal tic-tac-toe, then the entire local board is marked as a victory for the player in the global board.
Once a local board is won by a player or it is filled completely, no more moves may be played in that board. If a player is sent to such a board, then that player may play in any other board.
Game play ends when either a player wins the global board or there are no legal moves remaining, in which case the game is a draw.

### 5. Analogues <a name="5"></a>
Desktop application : [Ultimate Tic-Tac-Toe](https://store.steampowered.com/app/360870/Ultimate_TicTacToe/), Web application : [Ultimate TicTacToe](http://bejofo.net/ttt/)
