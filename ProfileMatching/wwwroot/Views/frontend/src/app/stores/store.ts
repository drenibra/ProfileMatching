import { createContext, useContext } from "react";
import CommonStore from "./CommonStore";
import JobPositionStore from "./jobPositionStore";
import UserStore from "./userStore";

interface Store {
  jobPositionStore: JobPositionStore;
  commonStore: CommonStore;
  userStore: UserStore;
}

export const store: Store = {
  jobPositionStore: new JobPositionStore(),
  commonStore: new CommonStore(),
  userStore: new UserStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
