import ResponsiveAppBar from './ResponsiveAppBar';
import { Box } from '@mui/system';
import JobPositionsComponent from './JobPositionsComponent';
import JobPositonDetails from '../../features/jobPositions/details/JobPositionDetails';
import JobPositionForm from '../../features/jobPositions/form/JobPositionForm';

const logo = require('./../../logo.svg') as string;

function App() {
  return (
    <div className="App">
      <ResponsiveAppBar />
      <Box mt={13}></Box>
      <JobPositionsComponent />
      <JobPositonDetails />
      <JobPositionForm />
    </div>
  );
}

export default App;
