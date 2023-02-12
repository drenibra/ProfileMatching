import axios, { AxiosResponse } from 'axios';
import { ApplicationDto } from '../models/ApplicationDto';
import { JobPosition } from '../models/JobPosition';
import { ApplicationsByApplicant } from '../models/ApplicationsByApplicant';
import { User, UserFormValues, UserRegister } from '../models/User';
import CommonStore from '../stores/CommonStore';
import { store } from '../stores/store';
import { Result } from '../models/Result';

const sleep = (delay: number) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

axios.defaults.baseURL = 'http://localhost:5048/api/v1';

axios.interceptors.request.use(
  (config) => {
    const token = store.commonStore.token;
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(async (response) => {
  try {
    await sleep(400);
    return response;
  } catch (error) {
    console.log(error);
    return Promise.reject(error);
  }
});

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const JobPositions = {
  list: () => requests.get<JobPosition[]>('/jobposition'),
};

const Account = {
  current: () => requests.get<User>('/account'),
  login: (user: UserFormValues) => requests.post<UserFormValues>('/account/login', user),
  register: (user: UserRegister) => requests.post<UserRegister>('/account/register', user),
  currentId: () => requests.get<string>('/account/currentId'),
  roles: () => requests.get<Array<string>>('/account/roles'),
};

const Application = {
  apply: (app: ApplicationDto) => requests.post<ApplicationDto>('/application', app),
  listByApplicant: (applicantId: string) =>
    requests.get<ApplicationsByApplicant[]>(`/application/applicant/${applicantId}`),
};

const Results = {
  list: () => requests.get<Result[]>('/result'),
};

const agent = {
  JobPositions,
  Account,
  Application,
  Results,
};

export default agent;
