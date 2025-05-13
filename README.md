# 🍺 Beer Dice Tracker

A full-stack web application for tracking real-time game statistics for Beer Dice, built with C# (ASP.NET Core) and React (TypeScript).

## 📌 Project Vision

This app allows users to input teams, players, and real-time in-game actions for Beer Dice. A third party can record throws, catches, drops, points, and special moves (e.g., cups, fifas, headers), while the app calculates live stats and stores historical game data for review.

## 🛠️ Tech Stack

- **Frontend**: React (TypeScript)
- **Backend**: ASP.NET Core Web API (C#)
- **Database**: Entity Framework Core + SQL Server (TBD)
- **Real-Time**: SignalR (Planned)
- **CI/CD**: GitHub Actions (Planned)
- **Deployment**: Azure / Vercel (Planned)

## 📁 Project Structure

/BeerDice.API # C# backend
/beer-dice-client # Reach frontend


## 🔧 Development Setup

1. **Backend**  
   ```bash
   cd BeerDice.API
   dotnet run
   ```
2. **Frontend**
   ```bash
   cd beer-dice-client
    npm install
    npm start
   ```


