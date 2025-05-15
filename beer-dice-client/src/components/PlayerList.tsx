import React, { useEffect, useState} from "react";
import { getPlayers, Player } from "../services/api";

const PlayerList: React.FC = () => {
  const [players, setPlayers] = useState<Player[]>([]);

  useEffect(() => {
    const fetchPlayers = async () => {
      try {
        const data = await getPlayers();
        setPlayers(data);
      } catch (error) {
        console.error("Failed to fetch players:", error);
      }
    };

    fetchPlayers();
  }, []);

  return (
    <div>
      <h2>Players</h2>
      <ul>
        {players.map((player) => (
          <li key={player.playerId}>
            {player.name} {player.teamName ? `(${player.teamName})` : '(No Team)'}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PlayerList;