# FashionApp

| Route | HTTP | Method | Description |
| --- | --- | --- | --- |
| /api/user/SignUp | POST | {Email-UserName-PasswordHash} | Kullanıcının üye olma yönetimi. |
| /api/genericInfo/Get | Get | {GenericInfoId} | Kullanıcının genel bilgilerini listele. |
| /api/genericInfo/GetByUser | Get | {GenericInfoId} | Kullanıcının kullanıcı bilgileri ve genel bilgilerini listele. |
| /api/genericInfo/GetUserId | Get | {UserId} | Kullanıcının  genel bilgilerini listele. |
| /api/genericInfo/GetByUserId | Get | {UserId} | Kullanıcının kullanıcı bilgileri ve genel bilgilerini listele. |
| /api/genericInfo/Update | Put | {UserId-Name-Surname-Thumbnail} | Kullanıcının kullanıcı bilgileri ve genel bilgilerini listele. |
| /api/genericInfo/Add | Post | {Name-Surname-Thumbnail} | Kullanıcının genel bilgilerini ekler. |
| /api/privateInfo/Get | Get | {PrivateInfoId} | Kullanıcının özel bilgilerini listele. |
| /api/privateInfo/GetByUser | Get | {PrivateInfoId} | Kullanıcının kullanıcı bilgileri ve özel bilgilerini listele. |
| /api/privateInfo/GetUserId | Get | {UserId} | Kullanıcının  özel bilgilerini listele. |
| /api/privateInfo/GetByUserId | Get | {UserId} | Kullanıcının kullanıcı bilgileri ve özel bilgilerini listele. |
| /api/privateInfo/Update | Put | {UserId-Name-Surname-Thumbnail} | Kullanıcının kullanıcı bilgileri ve özel bilgilerini listele. |
| /api/privateInfo/Add | Post | {Height-Weight-ChestWidth-WaistWidth-HipWidth} | Kullanıcının özel bilgilerini ekler. |
| /api/post/Get | Get | {PostId} | Id göre postu listeler. |
| /api/post/GetAll | Get | {UserId} | Kullanıcının tüm postlarını listeler. |
| /api/post/Add | Post | {UserId-FullyCombinedId-Description-Path-FullyCombineId-BodySizeId-ColorId-Path-Brand-Name} | Kullanıcının tüm postlarını listeler. |
| /api/follow/GetAll | Get | {userId} | Id göre beğeniyi listeler. |
| /api/follow/Add | Post | {UserId-FollowedId} | Posta beğeni ekler |
| /api/follow/Update | Update | {UserId-FollowedId-Id} | Beğeni durumunu günceller. |
| /api/blocked/GetAll | Get | {userId} | Id göre engellileri listeler. |
| /api/blocked/Add | Post | {UserId-BlockedId} | Kişi engellenen listesine ekler |
| /api/blocked/Update | Update | {UserId-BlockedId-Id} | Engelleme  durumunu günceller. |


