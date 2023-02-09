export interface User {
  name: string;
  username: string;
  token: string;
}

export interface UserFormValues {
  email: string;
  password: string;
  username?: string;
}
