import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './app/layout/App';
import reportWebVitals from './reportWebVitals';
import LoginForm from './features/users/LoginForm';
import JobPositionsComponent from './app/layout/JobPositionsComponent';
import LandingPage from './app/layout/LandinPage';
import ResponsiveAppBar from './app/layout/ResponsiveAppBar';
import RegisterForm from './features/users/RegisterForm';

const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);
root.render(
  <React.StrictMode>
    {/* <ResponsiveAppBar /> */}
    <App />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
