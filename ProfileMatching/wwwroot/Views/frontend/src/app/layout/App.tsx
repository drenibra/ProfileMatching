import JobPositionsComponent from './JobPositionsComponent';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LoginForm from '../../features/users/LoginForm';
import LandingPage from './LandinPage';
import RegisterForm from '../../features/users/RegisterForm';
import ResponsiveAppBar from './ResponsiveAppBar';
import { useStore } from '../stores/store';
import { useEffect } from 'react';

const logo = require('./../../logo.svg') as string;

const routes = [
  { path: '/', element: LandingPage },
  { path: '/jobpositions', element: JobPositionsComponent },
  { path: '*', element: LandingPage },
  { path: '/home', element: LandingPage },
  { path: '/login', element: LoginForm },
  { path: '/signup', element: RegisterForm },
];

function App() {
  const { commonStore, userStore } = useStore();

  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded());
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore]);

  /*   return userStore.isLoggedIn ? (
    <BrowserRouter>
      <ResponsiveAppBar />
      <Routes>
        {routes.map((route) => (
          <Route key={route.path} path={route.path} element={<route.element />} />
        ))}
      </Routes>
    </BrowserRouter>
  ) : (
    <LoginForm />
  ); */
  return (
    <BrowserRouter>
      {userStore.isLoggedIn ? (
        <>
          <ResponsiveAppBar />
          <Routes>
            {routes.map((route) => (
              <Route key={route.path} path={route.path} element={<route.element />} />
            ))}
          </Routes>
        </>
      ) : (
        <LoginForm />
      )}
    </BrowserRouter>
  );
}

export default App;
