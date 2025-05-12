GitHub Linki: https://github.com/pelinsusaglam/data-structures.git

# Hastane Acil Müdahale ve Hasta Yönetim Sistemi

Bu proje, bir hastanenin acil servisinde gerçekleşen hasta kabul, önceliklendirme ve doktor atama süreçlerini modelleyen bir yönetim sistemidir. Proje, çeşitli veri yapıları (AVL Ağaçları, Hash Tablosu, Kuyruk, Min-Heap) kullanılarak tasarlanmış olup, kritik ve normal hastaların önceliklerine göre yönetilmesini sağlar.

## Özellikler

- **Hasta Kabul Sistemi:** Hastalar sistemde kaydedilir ve yatak müsaitliğine göre yatırılır. Yataklar müsait değilse hastalar önceliğine göre ya kritik bekleyenler sırasına ya da normal bekleyenler sırasına aktarılır. Tüm hastalar hash tablosu içerisinde tutulur.
- **Gerçek Zamanlı Öncelik Sıralama:** Kritik hastalar min-heap ile, normal hastalar kuyruk ile yönetilir.
- **Doktor Atama Mekanizması:** Hastanın, hastalığının ait olduğu branşa göre o branştaki en az hastaya bakan doktor yatırılacak hastaya atanır (Min-Heap).
- **AVL Ağaçlı Hash Tablo:** Hastalar, TC Kimlik No’ya göre yerleştirilen hash tablosunda çakışmaların önlenmesi amacıyla AVL ağacıyla saklanır.
- **Vaka (Case) Takibi:** Hastalara, hastanın vaka numarasına göre CaseTable<AVL Tree> yapısından vaka ataması yapılır. Hasta, hastalığının ait olduğu branşa göre kategorize edilir.

## Kullanılan Veri Yapıları

- `HashTable<AVLTree>`: Hastaların TC numaralarına göre saklandığı yapı. TC numarası primary key. İçerisinde ekleme, silme ve arama işlemleri yapılmakta.
- `MinHeap`: Kritik durumdaki hastaların ve doktorların en az hastalığa sahip bir şekilde sıralanmasının yönetimi.
- `Queue`: Önceliği düşük hastaların sıralı kabul sistemi.
- `CaseTable<AVL Tree>`: Vakaların numaralarına göre belirlenmiş indekslerde saklandığı yapı. Vaka eklemeleri veya düzenlemeleri dışarıdan yapılmamakta.

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

Bu simülasyonda sadece C# veri yapıları kullanılmıştır. Amaç, gerçek zamanlı görev önceliğine göre çalışan bir görev yöneticisi yapmak ve bu esnada veri yapılarını etkili kullanmaktır.

## Algoritma Analizleri

Bu projede kullanılan temel işlemler ve veri yapılarının zaman karmaşıklıkları aşağıda özetlenmiştir:

### Hasta Ekleme

- **Yatak boşsa:**  
  - AVL ağacına ekleme (Hash tablosundaki ilgili indeks) → `O(log n)`
  - Doktor atama için min-heap kullanımı → `O(log d)`  
- **Yatak doluysa:**  
  - Kritik hasta → Kritik hasta min-heap’ine ekleme → `O(log k)`  
  - Normal hasta → Kuyruğa ekleme → `O(1)`

### Hasta Silme

- AVL ağacından silme → `O(log n)`  
- Silinen hasta kritik veya normal sıralardansa, ilgili yapıdan çıkarılır ve yeni hasta yatırılır:
  - Öncelikli hastayı min-heap’ten çıkarma → `O(log k)` 
  - Kuyruktan hasta çıkarma → `O(1)`
  - Yeni hastaya doktor atama ve heap güncelleme → `O(log d)`

### Hasta Arama

- TC Kimlik numarasına göre → Hash (`O(1)`) + AVL (`O(log m)`) ≈ `O(log m)` 
- Vaka numarasına göre vaka tablosu → `O(log v)`  

### Doktor Atama

- En az yüke sahip doktoru seçme (min-heap.peek) → `O(1)`
- Doktor hasta sayısını artırdıktan sonra heap güncelleme → `O(log d)`

---

> Not:  
> - `n`: toplam hasta sayısı  
> - `m`: bir hash indeksindeki hasta sayısı  
> - `k`: kritik hasta sayısı  
> - `d`: doktor sayısı (branş içi)  
> - `v`: vaka sayısı  
> AVL ağaçları sayesinde Hash tablolarında çakışma önlenmiş ve optimizasyon yapılmıştır. Ekleme/silme/arama işlemleri hızlı bir şekilde gerçekleşmektedir.

## Katkı Verenler

- **Ertuğrul Berk Kargın** – 032290044  
- **Zeynep Buse Can** – 032290055  
- **Berat Çakır** – 032290054  
- **Pelinsu Sağlam** – 032290048  
- **Zeynep Sude Kalkan** – 032290056

