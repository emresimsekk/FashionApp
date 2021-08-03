using Microsoft.AspNetCore.Identity;

namespace FashionApp.IdentityServer.Models
{
    public class TurkishdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() => new IdentityError { Code = nameof(DefaultError), Description = "Bilinmeyen bir hata oluştu !" };
        public override IdentityError ConcurrencyFailure() => new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Erreur de concurrence simultanée optimiste, l'objet a été modifié." };
        public override IdentityError PasswordMismatch() => new IdentityError { Code = nameof(PasswordMismatch), Description = "Yanlış parola !" };
        public override IdentityError InvalidToken() => new IdentityError { Code = nameof(InvalidToken), Description = "Geçersiz değer !" };
        public override IdentityError LoginAlreadyAssociated() => new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Bu hesap adına sahip bir kullanıcı zaten var !" };
        public override IdentityError InvalidUserName(string userName) => new IdentityError { Code = nameof(InvalidUserName), Description = $"Hesap adı '{userName}' geçersiz. Yalnızca harf ve rakamlara izin verilir !" };
        public override IdentityError InvalidEmail(string email) => new IdentityError { Code = nameof(InvalidEmail), Description = $"'{email}' e-postası geçersiz !" };
        public override IdentityError DuplicateUserName(string userName) => new IdentityError { Code = nameof(DuplicateUserName), Description = $"Hesap adı '{userName}' zaten kullanılıyor !" };
        public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = nameof(DuplicateEmail), Description = $"'{email}' e-postası zaten kullanılıyor !" };
        public override IdentityError InvalidRoleName(string role) => new IdentityError { Code = nameof(InvalidRoleName), Description = $"Rol adı '{role}' geçersiz !" };
        public override IdentityError DuplicateRoleName(string role) => new IdentityError { Code = nameof(DuplicateRoleName), Description = $"Rol adı '{role}' zaten kullanılıyor !" };
        public override IdentityError UserAlreadyHasPassword() => new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "Kullanıcının zaten bir şifresi var !" };
        public override IdentityError UserLockoutNotEnabled() => new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Bu kullanıcı için kilit etkinleştirilmedi !" };
        public override IdentityError UserAlreadyInRole(string role) => new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"Kullanıcı zaten '{role}' rolüne sahip !" };
        public override IdentityError UserNotInRole(string role) => new IdentityError { Code = nameof(UserNotInRole), Description = $"Kullanıcı '{role}' rolüne sahip değil !" };
        public override IdentityError PasswordTooShort(int length) => new IdentityError { Code = nameof(PasswordTooShort), Description = $"Parola en az {length} karakter içermelidir !" };
        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Parola en az bir alfa sayısal olmayan karakter içermelidir !" };
        public override IdentityError PasswordRequiresDigit() => new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Parola en az bir sayı ('0' - '9') içermelidir !" };
        public override IdentityError PasswordRequiresLower() => new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Parola, en az bir küçük harf karakteri ('a' - 'z') içermelidir !" };
        public override IdentityError PasswordRequiresUpper() => new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Parola, en az bir büyük harf karakteri ('A' - 'Z') içermelidir !" };


    }
}
