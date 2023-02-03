import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './app/layout/App';
import { store, StoreContext } from './app/stores/store';

const root = ReactDOM.createRoot(document.getElementById('root')!);
root.render(
  <StoreContext.Provider value={store}>
    <App />
  </StoreContext.Provider>
);
