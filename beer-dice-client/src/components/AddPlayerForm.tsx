import React, { useEffect, useState } from 'react';
import { getTeams, createPlayer, Team } from '../services/api';

interface Props {
    onPlayerCreated: () => void; // optional callback to refresh the player list
    refreshKey?: number; // optional key to force re-render
}

const AddPlayerForm: React.FC<Props> = ({ onPlayerCreated, refreshKey }) => {
    const [name, setName] = useState('');
    const [teamId, setTeamId] = useState<number | ''>('');
    const [teams, setTeams] = useState<Team[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchTeams = async () => {
            try {
                const data = await getTeams();
                setTeams(data);
            } catch (err) {
                console.error('Failed to fetch teams:', err);
            }
        };

        fetchTeams();
    }, [refreshKey]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setError('');

        try {
            await createPlayer({ name, teamId: Number(teamId) });
            setName('');
            setTeamId('');
            onPlayerCreated?.();
        } catch (err) {
            setError('Failed to create player');
            console.error(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <form onSubmit={handleSubmit} style={{ marginBottom: '2rem' }}>
            <h3>Add New Player</h3>
            <input
                type="text"
                placeholder="Player name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                required
                style={{ padding: '0.5rem', marginRight: '1rem' }}
            />
            <select
                value={teamId}
                onChange={(e) => setTeamId(Number(e.target.value))}
                required
                style={{ padding: '0.5rem', marginRight: '1rem' }}
            >
                <option value="">Select Team</option>
                {teams.map((team) => (
                    <option key={team.teamId} value={team.teamId}>
                        {team.name}
                    </option>
                ))}
            </select>
            <button type="submit" disabled={loading}>
                {loading ? 'Adding...' : 'Add Player'}
            </button>
            {error && <p style={{ color: 'red' }}>{error}</p>}
        </form>
    );
};

export default AddPlayerForm;