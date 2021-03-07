using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç veritabanına eklendi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarDeleted = "Araç veritabanından kaldırıldı.";
        public static string IncorrectTransaciton = "Hatalı işlem.";
        public static string MaintenanceTime = "Bakım saati.";
        public static string CarsListed = "Araçlar listelendi.";
        public static string BrandLimitExceded = "Marka sınırına ulaşıldı.";

        public static string CarCountLimit = "Bu marka için araç sınırına ulaşıldı.";

        public static string UserNotFound = "Kullanıcı mevcut değil.";

        public static string PasswordError = "Hatalı şifre girdiniz.";

        public static string SuccessfulLogin = "Giriş yapıldı.";

        public static string UserAlreadyExist = "Bu mail adresine sahip kullanıcı bulunmakta.";

        public static string UserRegistered = "Kulanıcı kaydedildi.";

        public static string AccessTokenCreate= "Access Token oluşturuldu.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
