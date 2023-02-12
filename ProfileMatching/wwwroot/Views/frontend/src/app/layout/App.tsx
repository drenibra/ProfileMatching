import JobPositions from './JobPositions';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LoginForm from '../../features/users/LoginForm';
import LandingPage from './LandinPage';
import RegisterForm from '../../features/users/RegisterForm';
import ResponsiveAppBar from './ResponsiveAppBar';
import { useStore } from '../stores/store';
import { useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import MyApplications from './MyApplications';
import Applications from './Applications';

const routes = [
  { path: '/', element: LoginForm },
  { path: '/jobpositions', element: JobPositions },
  { path: '*', element: LoginForm },
  { path: '/home', element: LandingPage },
  { path: '/login', element: LoginForm },
  { path: '/signup', element: RegisterForm },
  { path: '/my-applications', element: MyApplications },
  { path: '/applications', element: Applications },
];

export default observer(function App() {
  const { commonStore, userStore } = useStore();
  const [page, setPage] = useState('login');

  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded());
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore]);

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
      ) : page === 'login' ? (
        <LoginForm setPage={setPage} />
      ) : (
        <RegisterForm setPage={setPage} />
      )}
    </BrowserRouter>
  );
});
