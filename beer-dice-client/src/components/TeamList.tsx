import React, { useEffect, useState } from 'react';
import { getTeams, Team } from '../services/api';

const TeamList: React.FC = () => {
    const [teams, setTeams] = useState<Team[]>([]);

    useEffect(() => {
        const fetchTeams = async () => {
            try {
                const data = await getTeams();
                console.log('Fetched teams:', data);
                setTeams(data);
            } catch (error) {
                console.error('Failed to fetch teams:', error);
            }
        };

        fetchTeams();
    }, []);

    return (
        <div>
            <h2>Teams</h2>
            <ul>
                {teams.map(team => (
                    <li key={team.teamId}>
                        <strong>{team.name}</strong>
                        <ul>
                            {team.players?.map(player => (
                                <li key={player.playerId}>{player.name}</li>
                            ))}
                        </ul>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default TeamList;

