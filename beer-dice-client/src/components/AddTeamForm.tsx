import React, {useState} from 'react';
import {createTeam} from '../services/api';

interface Props {
    onTeamCreated: () => void; // optional callback to refresh the team list
}

const AddTeamForm: React.FC<Props> = ({onTeamCreated}) => {
    const [name, setName] = useState('');
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setError('');

        try {
            await createTeam({name});
            setName('');
            onTeamCreated?.();

        } catch (err) {
            setError('Failed to create team');
            console.error(err);
        } finally {
            setLoading(false);
        }
    };


    return (
        <form onSubmit={handleSubmit} style={{ marginBottom: '2rem' }}>
            <h3>Add New Team</h3>
            <input
                type="text"
                placeholder="team name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                required
                style={{ padding: '0.5rem', marginRight: '1rem' }}
            />
            <button type="submit" disabled={loading}>
                {loading ? 'Adding...' : 'Add Team'}
            </button>
            {error && <p style={{ color: 'red' }}>{error}</p>}
        </form>
    );
};

export default AddTeamForm;

