import { createContext, useContext } from 'react';
import JobPositionStore from './jobPositionStore';

interface Store {
  jobPositionStore: JobPositionStore;
}

export const store: Store = {
  jobPositionStore: new JobPositionStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
