import logo from './logo.svg';
import './App.css';
import JobPosition from './JobPosition';
import SearchAppBar from './SearchAppBar';
import { Box } from '@mui/system';

function App() {
  return (
    <div className="App">
      <SearchAppBar></SearchAppBar>
      <Box mt={13}></Box>
      <JobPosition></JobPosition>
    </div>
  );
}

export default App;
