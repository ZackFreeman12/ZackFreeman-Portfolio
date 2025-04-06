# Discord Dice Game Bot - Gamba 📈

<div align="center">
  <img src="https://i.imgur.com/GMHrUgH.png" alt="Gamba Bot Screenshot" width="600">
</div>

## Overview

Gamba is a Discord bot designed to bring fun dice-based wagering games to your server. Users can register, bet virtual points ("GambaCoins") on games like Highroll and Cee-lo, and track their stats. The bot uses a database to persist user data, including points, win streaks, and lifetime earnings.

Gamba can be added to any Discord server. For the best user experience, it's recommended to dedicate a specific text channel for the bot due to the potentially rapid pace of games and command usage.

## Features

*   **User Registration:** Players register with `!newplayer` to start playing.
*   **Points System:** Wager GambaCoins on games.
*   **Dice Games:**
    *   `!highroll`: Roll 5 dice against the house; highest sum wins.
    *   `!ceelo`: Roll 3 dice against the house following Cee-lo scoring rules.
*   **Stat Tracking:** View your points, win streak, and lifetime earnings with `!stats`.
*   **Point Reset:** Ran out of points? Use `!reset` to get back to the starting amount.
*   **Persistence:** User data is stored in a database via a backend API.
*   **Help & Rules:** `!help` and `!rules` commands provide guidance.

## Tech Stack

*   **Bot Framework:** [Discord.js](https://discord.js.org/)
*   **Runtime:** [Node.js](https://nodejs.org/)
*   **Database:** [SQLite](https://www.sqlite.org/index.html)
*   **API:** Custom RESTful API (Node.js/Express - *assumed*) for database interaction.

## Architecture

Gamba consists of two main parts:

1.  **The Discord Bot (This Repository):** Handles Discord events, user commands, game logic presentation, and communicates with the backend API.
2.  **Backend API & Database:** A separate Node.js application acts as a RESTful API layer. The bot sends HTTP requests (GET, POST, PUT) to this API to fetch or update user data stored in the SQLite database.

**Note:** The current bot code is configured to communicate with an API running on `http://localhost:3000`. For deployment or use by others, the API needs to be hosted, and the API endpoint URL in the bot's code (specifically within the `axios` calls) must be updated accordingly.

## Database Schema

The SQLite database stores user information with the following structure:

<div align="center">
  <img src="https://github.com/ZackFreeman12/ZackFreeman-Portfolio/raw/GambaBot/mL9OQAU.png" alt="Database Schema">
  <!-- Note: Consider embedding the image directly in this repo or using a more permanent link if the source might change -->
</div>

*   `userid` (TEXT, PRIMARY KEY): The unique Discord User ID.
*   `points` (INTEGER): The user's current GambaCoin balance.
*   `streak` (INTEGER): The user's current winning streak.
*   `lifetime` (INTEGER): The total amount of GambaCoins won over time.

## Prerequisites

*   [Node.js](https://nodejs.org/) (LTS version recommended)
*   npm (comes with Node.js) or yarn
*   A Discord Bot Token (See [Discord Developer Portal](https://discord.com/developers/applications))
*   The backend API server running and accessible by the bot.

## Installation & Setup

1.  **Clone the Repository:**
    ```bash
    git clone <repository-url>
    cd <repository-folder>
    ```
2.  **Install Dependencies:**
    ```bash
    npm install
    # or
    yarn install
    ```
3.  **Configure the Bot:**
    *   Create a `config.json` file in the root directory.
    *   Add your Discord bot token and the desired channel ID:
        ```json
        {
          "token": "YOUR_DISCORD_BOT_TOKEN",
          "channelId": "YOUR_TARGET_CHANNEL_ID"
        }
        ```
4.  **Configure API Endpoint:**
    *   Open the main bot file (e.g., `index.js` or similar).
    *   Find all instances of `axios` calls (e.g., `axios.get('http://localhost:3000/api/get/...')`).
    *   **Important:** Change `'http://localhost:3000'` to the actual URL where your backend API is hosted if it's not running locally.
5.  **Setup & Run the Backend API:**
    *   Follow the setup instructions for the separate Gamba API repository/project to get the database and API server running.
6.  **Start the Bot:**
    ```bash
    node index.js
    # or your main bot file name
    ```

## Commands

*(Prefix: `!`)*

*   `!newplayer`: Register yourself as a player (first time only).
*   `!help`: Displays a list of available commands and their descriptions.
*   `!rules`: Shows the rules for the implemented dice games.
*   `!stats`: View your current GambaCoins, win streak, and lifetime earnings.
*   `!highroll <bet>`: Play a game of Highroll. Replace `<bet>` with the number of GambaCoins you want to wager (Min: 10).
*   `!ceelo <bet>`: Play a game of Cee-lo. Replace `<bet>` with the number of GambaCoins you want to wager (Min: 10).
*   `!reset`: Resets your GambaCoins to the default starting amount (100). Use this if you run out.

## Testing

*   **Manual Test Cases:** Detailed test scenarios can be found here:
    [Test Cases Spreadsheet](https://docs.google.com/spreadsheets/d/1Yf7WsJ--CKpGeowe3_MGfpVgLCHumU3zBggoNspn51g/edit?gid=0#gid=0)
*   **Automated Tests:** Code for automated tests (if applicable) is located in the `/Tests` directory within the [original portfolio repository branch](https://github.com/ZackFreeman12/ZackFreeman-Portfolio/tree/GambaBot/Tests).
    *(Note: Consider integrating relevant tests directly into this repository if separating from the portfolio.)*

## Contributing

Contributions are welcome! If you'd like to contribute, please follow these steps:

1.  Fork the repository.
2.  Create a new branch (`git checkout -b feature/your-feature-name`).
3.  Make your changes.
4.  Commit your changes (`git commit -m 'Add some feature'`).
5.  Push to the branch (`git push origin feature/your-feature-name`).
6.  Open a Pull Request.

Please ensure your code adheres to the existing style and add tests for new features where applicable.

*(Original Author Certification Note: "StAuth10222: I Zack Freeman, 000781330 certify that this material is my original work. No other person's work has been used without due acknowledgement. I have not made my work available to anyone else." - This certification belongs in the header of the relevant source code files, not directly in the README.)*

## License

(Optional: Add license information here, e.g., MIT License)
