import React from 'react';
import TeamList from './components/TeamList';
import PlayerList from './components/PlayerList';
import './App.css';
import AddTeamForm from './components/AddTeamForm';

function App() {
  const [refreshKey, setRefreshKey] = React.useState(0);

  const refreshTeams = () => setRefreshKey(prev => prev + 1);

  return (
    <div className="App" style={{ padding: '2rem' }}>
      <h1>Beer Dice Tracker</h1>

      <AddTeamForm onTeamCreated={refreshTeams} />
      <TeamList key={refreshKey} />
      <hr />
      <PlayerList />
    </div>
  );
}

export default App;
