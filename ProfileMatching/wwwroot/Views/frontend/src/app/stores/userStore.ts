import { makeAutoObservable, runInAction } from 'mobx';
import { makePersistable } from 'mobx-persist-store';
import agent from '../api/agent';
import { ApplicationDto } from '../models/ApplicationDto';
import { User, UserFormValues, UserRegister } from '../models/User';
import { store } from './store';

export default class UserStore {
  user: User | null = null;
  error: boolean = false;

  constructor() {
    makeAutoObservable(this);

    makePersistable(this, {
      name: 'UserStore',
      properties: ['user'],
      storage: window.localStorage,
    });
  }

  get isLoggedIn() {
    return this.user ? true : false;
  }

  login = async (creds: UserFormValues) => {
    try {
      const user = await agent.Account.login(creds);
      store.commonStore.setToken(user.token);
      runInAction(() => (this.user = user));
      this.removeError();
      console.log(user);
    } catch (error) {
      console.log('Invalid credentials');
      this.triggerError();
      throw error;
    }
  };

  register = async (creds: UserRegister) => {
    try {
      const user = await agent.Account.register(creds);
      store.commonStore.setToken(user.token);
      runInAction(() => (this.user = user));
    } catch (error) {
      throw error;
    }
  };

  logout = () => {
    store.commonStore.setToken(null);
    window.localStorage.removeItem('jwt');
    this.user = null;
    window.location.replace('/login');
  };

  getUser = async () => {
    try {
      const user = await agent.Account.current();
      console.log(user);
      runInAction(() => (this.user = user));
    } catch (error) {
      console.log(error);
    }
  };

  getCurrentUserId = async (): Promise<string> => {
    try {
      const userId = await agent.Account.currentId();
      return userId;
    } catch (error) {
      console.log(error);
      return '';
    }
  };

  apply = async (creds: ApplicationDto): Promise<boolean> => {
    try {
      const application = await agent.Application.apply(creds);
      return application;
    } catch (error) {
      console.log(error);
      return false;
    }
  };

  /*   getRoles = async (): Promise<string[]> => {
    try {
      const roles = await agent.Account.roles;
      return roles;
    } catch (error) {
      console.log(error);
      return [];
    }
  }; */

  triggerError = () => {
    this.error = true;
  };
  removeError = () => {
    this.error = false;
  };
}
