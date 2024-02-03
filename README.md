# Battleship Game Solution

This solution implements a Battleship game backend API and includes a simple front end to interact with the API.

## Project Structure

The solution consists of the following projects:

1. **BattleshipGame**: Contains the backend API implementation using ASP.NET Core.

## Backend API

### Controllers

- **BattleshipController**: Handles HTTP requests related to the Battleship game. It provides endpoints to initialize the game board and fire missiles.

### Services

- **IGameService**: Defines the interface for the game service.
- **GameService**: Implements the game service, including logic for initializing the game board, firing missiles, and checking game status.

### Models

- **Coordinates**: Represents the coordinates on the game board.
- **ShipPositions**: Represents the positions of ships on the game board.

## Frontend UI

A basic frontend UI is provided to interact with the backend API. The frontend consists of an HTML file and a JavaScript file.

### HTML File

The `index.html` file contains the HTML structure of the UI, including buttons to initialize the game and fire missiles, and a section to display the game message.

### JavaScript File

The `script.js` file contains the JavaScript code to handle user interactions, such as clicking buttons and making HTTP requests to the backend API.

## Configuration

- **appsettings.json**: Contains application settings, including the flag to determine whether to load ship positions from a file or generate them randomly.
- **ships.json**: Contains ship positions if loaded from a file.

## Usage

1. Build and run the solution.
2. Open the `index.html` file in a web browser.
3. Initialize the game board and start playing Battleship.

## Dependencies

- ASP.NET Core
- Newtonsoft.Json

## Setup

- Clone the repository.
- Open the solution in Visual Studio or your preferred IDE.
- Build and run the solution.

## Contributors

- Simone Dore

Feel free to contribute to this project by submitting pull requests or reporting issues.

