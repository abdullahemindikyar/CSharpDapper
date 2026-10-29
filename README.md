# NLayerDapper

SQL Server üzerinde ürün kayıtlarını yönetmek için geliştirilmiş, **C# Windows Forms** ve **Dapper** kullanan basit bir CRUD uygulamasıdır.

## Projenin Amacı

Bu projeyi, C# ile Windows Forms uygulaması geliştirirken SQL Server veritabanı işlemlerini öğrenmek ve Dapper kullanımını uygulamalı olarak deneyimlemek amacıyla geliştirdim.

Projenin temel amacı; ürün bilgilerinin veritabanında tutulduğu, kullanıcıların bu bilgiler üzerinde ekleme, listeleme, güncelleme ve silme işlemlerini gerçekleştirebildiği basit ve anlaşılır bir masaüstü uygulaması oluşturmaktır.

Bu proje sayesinde aşağıdaki konularda pratik yapmayı hedefledim:

- Windows Forms ile kullanıcı arayüzü oluşturma
- SQL Server ile veritabanı bağlantısı kurma
- Dapper kullanarak SQL sorguları çalıştırma
- Parametreli sorgularla veritabanı işlemleri yapma
- CRUD işlemlerini uygulama
- DTO sınıflarıyla veri taşıma
- `async` ve `await` kullanarak asenkron veritabanı işlemleri gerçekleştirme
- Projeyi daha düzenli bir klasör yapısıyla geliştirme

## Bu Projede Neler Kullandım?

- Kullanıcı arayüzü için **Windows Forms** kullandım.
- Veritabanı işlemleri için **Microsoft SQL Server** kullandım.
- SQL sorgularını uygulama içerisinde daha kolay ve performanslı çalıştırmak için **Dapper** kütüphanesinden yararlandım.
- Ürün ekleme, listeleme, güncelleme ve silme işlemlerini parametreli SQL sorguları ile gerçekleştirdim.
- Ürün verilerini taşımak için `CreateProductDto`, `ResultProductDto` ve `UpdateProductDto` sınıflarını kullandım.
- Veritabanı işlemlerinin kullanıcı arayüzünü gereksiz yere bloklamaması için asenkron metotlardan yararlandım.
- Kodları daha düzenli tutmak amacıyla DTO, repository ve bağlantı bilgileri için ayrı klasörler oluşturdum.

## Özellikler

- Ürünleri listeleme
- Yeni ürün ekleme
- Ürün güncelleme
- Ürün silme
- Toplam ürün sayısını görüntüleme
- En yüksek fiyatlı ürünü görüntüleme
- Kategori sayısını görüntüleme
- Dapper ile parametreli SQL sorguları kullanma

## Kullanılan Teknolojiler

- C#
- .NET Framework 4.7.2
- Windows Forms
- Dapper 2.1.89
- Microsoft SQL Server
- Visual Studio

## Proje Yapısı

```text
NLayerDapper/
├── ConnectionString/
│   └── DatabaseConnectionString.cs
├── Dtos/
│   ├── CreateProductDto.cs
│   ├── ResultProductDto.cs
│   └── UpdateProductDto.cs
├── Repositories/
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
├── Form1.cs
├── Form1.Designer.cs
├── App.config
├── NLayerDapper.csproj
└── Program.cs
```

## Veritabanı Kurulumu

Uygulama `TblProduct` isimli bir tablo beklemektedir. SQL Server üzerinde aşağıdaki tabloyu oluşturabilirsiniz:

```sql
CREATE DATABASE CSharpDapperDb;
GO

USE CSharpDapperDb;
GO

CREATE TABLE TblProduct
(
	ProductId INT IDENTITY(1,1) PRIMARY KEY,
	ProductName NVARCHAR(100) NOT NULL,
	ProductStock INT NOT NULL,
	ProductPrice DECIMAL(18,2) NOT NULL,
	ProductCategory NVARCHAR(100) NOT NULL
);
GO
```

## Bağlantı Ayarı

`NLayerDapper/Form1.cs` dosyasında kullanılan bağlantı dizesi mevcut bilgisayardaki SQL Server instance'ına göre düzenlenmelidir:

```csharp
Server=YOUR_SERVER;Initial Catalog=CSharpDapperDb;Integrated Security=True
```

Örneğin SQL Server Express için:

```text
Server=.\SQLEXPRESS;Initial Catalog=CSharpDapperDb;Integrated Security=True
```

## Çalıştırma

1. SQL Server'ı ve SQL Server Management Studio'yu yükleyin.
2. `CSharpDapperDb` veritabanını ve `TblProduct` tablosunu oluşturun.
3. Bağlantı dizesini kendi SQL Server ortamınıza göre güncelleyin.
4. `CSharpDapper.slnx` çözümünü Visual Studio ile açın.
5. NuGet paketlerinin geri yüklenmesini bekleyin.
6. Projeyi derleyip çalıştırın.

## Kullanım

Uygulama açıldığında ürün bilgilerini girerek:

- **Ekle** butonuyla yeni ürün ekleyebilir,
- **Listele** butonuyla ürünleri görüntüleyebilir,
- Bir ürün seçerek **Güncelle** veya **Sil** işlemlerini gerçekleştirebilirsiniz.

Uygulama veritabanı işlemlerinde Dapper'ın parametreli sorgu özelliğini kullanır. Bu yaklaşım SQL sorgularının daha güvenli ve okunabilir olmasına yardımcı olur.


