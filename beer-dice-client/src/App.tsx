import React, { useState } from 'react';
import TeamList from './components/TeamList';
import PlayerList from './components/PlayerList';
import AddTeamForm from './components/AddTeamForm';
import AddPlayerForm from './components/AddPlayerForm';

function App() {
  const [refreshKey, setRefreshKey] = React.useState(0);
  
  const refreshData = () => setRefreshKey(prev => prev + 1);

  return (
    <div className="App" style={{ padding: '2rem' }}>
      <h1>Beer Dice Tracker</h1>

      <AddTeamForm onTeamCreated={refreshData} />
      <AddPlayerForm onPlayerCreated={refreshData} refreshKey={refreshKey} />

      <TeamList key={`teams-${refreshKey}`} />
      <hr />
      
      <PlayerList key={`players-${refreshKey}`} />
    </div>
  );
};

export default App;
