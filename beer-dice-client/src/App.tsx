import React from 'react';
import TeamList from './components/TeamList';
import PlayerList from './components/PlayerList';
import './App.css';

function App() {
  return (
    <div className="App">
      <h1>Beer Dice Tracker</h1>

      <section>
        <TeamList />
      </section>

      <hr style={{ margin: '2rem 0' }} />

      <section>
        <PlayerList />
      </section>
    </div>
  );
}

export default App;
