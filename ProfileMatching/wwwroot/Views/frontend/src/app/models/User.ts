export interface User {
  name: string;
  username: string;
  token: string;
}

export interface UserRegister {
  Name: string;
  Surname: string;
  UserName: string;
  Email: string;
  Password: string;
  Skills: string;
}

export interface UserFormValues {
  email: string;
  password: string;
  username?: string;
}

export interface AppUser {
  name: string;
  surname: string;
}
