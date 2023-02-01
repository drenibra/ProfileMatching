import logo from './logo.svg';
import './App.css';
import JobPosition from './JobPosition';
import SearchAppBar from './SearchAppBar';


function App() {
  return (
    <div className="App">
      <SearchAppBar></SearchAppBar>
      <div className='mt-10'>
      <JobPosition></JobPosition>
      </div>
      
    </div>
  );
}

export default App;
