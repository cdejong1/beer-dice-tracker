import axios from 'axios';

const API_BASE_URL = 'https://localhost:5127/api'; // Adjust if your backend uses a different port

export interface Team {
  teamId: number;
  name: string;
  players?: Player[];
}

export interface Player {
  playerId: number;
  name: string;
  teamId: number;
  team?: Team;
}

// ===== TEAM =====

export const getTeams = async (): Promise<Team[]> => {
  const response = await axios.get(`${API_BASE_URL}/team`);
  return response.data;
};

export const createTeam = async (team: { name: string }): Promise<Team> => {
  const response = await axios.post(`${API_BASE_URL}/team`, team);
  return response.data;
};

// ===== PLAYER =====

export const getPlayers = async (): Promise<Player[]> => {
  const response = await axios.get(`${API_BASE_URL}/player`);
  return response.data;
};

export const createPlayer = async (player: { name: string; teamId: number }): Promise<Player> => {
  const response = await axios.post(`${API_BASE_URL}/player`, player);
  return response.data;
};
