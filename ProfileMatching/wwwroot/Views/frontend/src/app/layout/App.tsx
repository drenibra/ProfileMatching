import JobPositionsComponent from './JobPositionsComponent';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LoginForm from '../../features/users/LoginForm';
import LandingPage from './LandinPage';
import SignUpForm from '../../features/users/SignUpForm';
import ResponsiveAppBar from './ResponsiveAppBar';

const logo = require('./../../logo.svg') as string;

const routes = [
  { path: '/', element: LandingPage },
  { path: '/jobpositions', element: JobPositionsComponent },
  { path: '*', element: LandingPage },
  { path: '/home', element: LandingPage },
  { path: '/login', element: LoginForm },
  { path: '/signup', element: SignUpForm },
];

function App() {
  return (
    <BrowserRouter>
      <ResponsiveAppBar />
      <Routes>
        {routes.map((route) => (
          <Route key={route.path} path={route.path} element={<route.element />} />
        ))}
      </Routes>
    </BrowserRouter>
  );
}

export default App;
