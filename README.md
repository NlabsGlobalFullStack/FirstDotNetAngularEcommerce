# E-Commerce Projesi

Bu depo, bir e-ticaret uygulamasının iki bileşenini içerir: biri C# ve ASP.NET Core kullanılarak geliştirilen Web API (back-end), diğeri ise Angular kullanılarak geliştirilen bir web istemcisi (front-end).

## Kurulum

### Web API (Back-end)

1. `eCommerceServer` klasörüne gidin:

    ```bash
    cd eCommerceServer
    ```

2. `AppDbContext.cs` dosyasında veritabanı bağlantı dizesini belirtin:

    ```csharp
    optionsBuilder.UseSqlServer("your_connection_string_here");
    ```

3. Proje kök dizininde terminali açın ve aşağıdaki komutları çalıştırarak Web API'yi başlatın:

    ```bash
    dotnet restore
    dotnet run
    ```

4. Web API, varsayılan olarak `https://localhost:5001` adresinde çalışacaktır.

### Angular Web İstemcisi (Front-end)

1. `eCommerceClient` klasörüne gidin:

    ```bash
    cd eCommerceClient
    ```

2. Terminalde aşağıdaki komutları çalıştırarak bağımlılıkları yükleyin:

    ```bash
    npm install
    ```

3. Aşağıdaki komutu çalıştırarak Angular uygulamasını başlatın:

    ```bash
    ng serve
    ```

4. Web tarayıcınızda `http://localhost:4200` adresine giderek uygulamayı görüntüleyin.

## Kullanım

1. Tarayıcınızdan [https://localhost:4200](https://localhost:4200) adresine gidin.
2. Kullanıcı kaydı yapmak için "Register" sayfasını ziyaret edin.
3. Giriş yapmak için "Login" sayfasını ziyaret edin.
4. Ürünleri görüntülemek ve sepete eklemek için "Home" sayfasını kullanın.

## Geliştirme

- Web API'yi geliştirmek için `eCommerceServer` klasörü içindeki C# kodlarını düzenleyin.
- Angular uygulamasını geliştirmek için `eCommerceClient` klasörü içindeki TypeScript ve HTML dosyalarını düzenleyin.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır - Daha fazla bilgi için [LICENSE.md](LICENSE.md) dosyasına bakın.
