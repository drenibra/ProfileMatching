import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5048/api/v1',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('access_token')}`,
  },
});

const requireAdmin = () => {
  const role = localStorage.getItem('role');
  if (role !== 'Applicant') {
    throw new Error('Unauthorized: Requires applicant role.');
  }
};

export const getJobPositions = async () => {
  requireAdmin();
  const response = await api.get('/jobPosition');
  return response.data;
};
