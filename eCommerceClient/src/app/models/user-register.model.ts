export class UserRegisterModel{
    id: number = 0;

    // Kullanıcının adını temsil eden özellik.
    firstName: string = "";

    // Kullanıcının soyadını temsil eden özellik.
    lastName: string = "";

    // Kullanıcının e-posta adresini temsil eden özellik.
    email: string = "";

    // Kullanıcının kullanıcı adını temsil eden özellik.
    userName: string = "";

    // Kullanıcının şifresini temsil eden özellik.
    password: string = "";

    // Kullanıcının yönetici (admin) rolüne sahip olup olmadığını temsil eden özellik.
    isAdmin: boolean = false;
}