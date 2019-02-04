export class UserViewModel {
  id: string;
  userName: string;
  phoneNumber: string;
  email: string;
  roleId: string;
  role: string;
}



export class UserModel {
  id?: string;
  userName: string;
  roleId: string;
}

export class PasswordChangeModel {
  id: string;
  currentPassword: string;
  newPassword: string;
  confirmedPassword: string;
}


export class UpdatedUserModel {
  id: string;
  userName: string;
  email: string;
  phoneNumber: string;
  fullName: string;
  roleId: string;
}
