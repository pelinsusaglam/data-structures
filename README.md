GitHub Linki: https://github.com/pelinsusaglam/data-structures.git

# Hastane Acil Müdahale ve Hasta Yönetim Sistemi

Bu proje, bir hastanenin acil servisinde gerçekleşen hasta kabul, önceliklendirme ve doktor atama süreçlerini modelleyen bir yönetim sistemidir. Proje, çeşitli veri yapıları (AVL Ağaçları, Hash Tablosu, Kuyruk, Min-Heap) kullanılarak tasarlanmış olup, kritik ve normal hastaların önceliklerine göre yönetilmesini sağlar.

## Özellikler

- 🏥 **Hasta Kabul Sistemi:** Hastalar sistemde kaydedilir ve yatak müsaitliğine göre yatırılır. Kayıt bir hash tablosu içerisine yapılır.
- ⏱️ **Gerçek Zamanlı Öncelik Sıralama:** Kritik hastalar min-heap ile, normal hastalar kuyruk ile yönetilir.
- 🧠 **Doktor Atama Mekanizması:** Hastanın, hastalığının ait olduğu branşa göre o branştaki en az hastaya bakan doktor yatırılacak hastaya atanır (Min-Heap).
- 🌲 **AVL Ağaçlı Hash Tablo:** Hastalar, TC Kimlik No’ya göre yerleştirilen hash tablosunda çakışmaların önlenmesi amacıyla AVL ağacıyla saklanır.
- 🧾 **Vaka (Case) Takibi:** Hastalar, vaka numaraları ve branşlara göre kategorize edilir. Hastanın vaka numarasına göre hastaya hastalık ataması yapılır.

## Kullanılan Veri Yapıları

- `HashTable<AVLTree>`: Hastaların TC numaralarına göre saklandığı yapı. İçerisinde ekleme, silme ve arama işlemleri yapılmakta.
- `MinHeap`: Kritik durumdaki hastaların ve doktorların yönetimi.
- `Queue`: Normal öncelikli hastalar için sıralı kabul sistemi.
- `CaseTable<AVL Tree>`: Vakaların numaralarına göre saklandığı yapı.

## Nasıl Çalışır?

1. Hastanın adı, soyadı, önceliği ve hastalığına ait vaka numarası girilir.
2. Sistem TC kimlik numarasının hastalar arasında kayıtlı olup olmadığını ve vaka numarasının tanımlı olup olmadığını kontrol eder.
3. Eğer şartlar sağlanıyorsa hasta, mevcut yatak kapasitesi dolu değilse direkt yatırılır. Hastaya, vaka numarasına karşılık gelen hastalık atanır ve doktor ataması yapılır.
4. Eğer yataklar doluysa sistem hastaya vaka numarasına göre hastalık ataması yapar  ve hastanın önceliğine göre hastayı sıraya sokar.
5. Hastalardan biri taburcu edildiği zaman önce kritik bekleyen yani öncelikli hastalar kontrol edilir. Öncelikli hasta varsa bu hasta yatırılır ve doktor ataması yapılır. Öncelikli hasta yoksa normal bekleyen hastalara bakılır ve normal bekleyen hasta varsa ilk gelen hasta yatırılır. Bu hastanın doktor ataması yapılır.

## Kurulum ve Çalıştırma

### Gereksinimler

- .Net 9 SDK
- Visual Studio 2022 veya üzeri (veya Visual Studio Code)
- git (isteğe bağlı)

### Projeyi Klonlayın

```bash
git clone https://github.com/pelinsusaglam/data-structures.git
cd 'data-structures/Final Version/HospitalSystem'
```

### Gereksinimleri Yükleyin

```bash
dotnet restore
```

### Uygulamayı Başlatın

```bash
dotnet run
```

### Tarayıcıda Şu Adresi Açın

http://localhost:5049/

## Geliştirici Notları

Bu simülasyon, veritabanı kullanmadan sadece C# veri yapılarıyla oluşturulmuştur. Amaç, gerçek zamanlı görev önceliğine göre çalışan bir görev yöneticisi yapmak ve veri yapılarını etkili kullanmaktır.

## Katkı Verenler

- **Ertuğrul Berk Kargın** – 032290044  
- **Zeynep Buse Can** – 032290055  
- **Berat Çakır** – 032290054  
- **Pelinsu Sağlam** – 032290048  
- **Zeynep Sude Kalkan** – 032290056

