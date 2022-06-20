# RiseTech

Projede 2 tane servis yazıldı. Contact ve Report diye.
.Net 6 kullanıldı projede.
Servisler Swagger üzerinden ayağa kalkmakta testler yapılabilmektedir.
MongoDb kullanıldı. Docker üzerinden MongoDb'nin kurulumu yeterli. Proje çalışırken collectionlarını oluşturuyor. Ek bir işlem yapmaya gerek yok.
Validasyon için Fluent Validation eklendi.
RabbitMq eklendi Docker üzerinden ayağa kaldırılır.
RabbitMq için base kodlar yazıldı henüz projede aktif kullanılmadı.
UnitTest projesi kuruldu. Bunun için xUnit kullanıldı. Report servisi için unit testin code coverage oranı %60'ın üstünde. Daha sonra unit test yazılmadı ama yeni servis ve kodlar eklendi.
ErrorList'te "Errors" değeri zaten 0 olmakla beraber "Warnings" ve "Messages" değerlerinin de 0 olmasına özen gösterildi.
