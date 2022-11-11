export interface LoginModel {
  username: string;
  password: string;
  role: string;
}

export interface AuthenticatedResponse{
  token: string;
}