export class LogInModel {
  userName: string;
  password: string;
}

export class AuthenticationModel {
  token: string;
  expires: Date;
  userName: string;
  userId: string;
  role: string;
}
