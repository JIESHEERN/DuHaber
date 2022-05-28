# DuHaber
Kimlik Doğrulamalı Haber Sitesi
1) Projeyi indirdikten sonra DataAccesLayer katmanının içindeki migrations klasörünün içindekileri silin.
2) Visual Studio Sekmelerinden View-Other Windows-Package Manager Console'e tıklayın.
3) Burada DataAccesLayer'a gelir Set as Startup Project dedikten sonra Package Manage Console'da da default projecti DataAccessLayer olarak ayarlayın.
4) DataAccesLayer/Concrete/Context.cs sınıfındaki serveri kendi lokal serverinizin ismiyle değiştirin.
5) Package Manager Console'da add-migration test1 komutunu yazın işlem tamamlandıktan sonra update-database ile veritabanını sql'e aktarın.
6) NewsBlog yapısını set as startup project dedikten sonra çalıştırarak siteye ulaşabilirsiniz.
