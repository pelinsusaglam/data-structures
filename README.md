#Github Link’i: https://github.com/pelinsusaglam/data-structures

# Hastane Acil Müdahale ve Hasta Yönetim Sistemi

Bu proje, bir hastanenin acil servisinde gerçekleşen hasta kabul, önceliklendirme ve doktor atama süreçlerini modelleyen bir yönetim sistemidir. Proje, çeşitli veri yapıları (AVL Ağaçları, Hash Tablosu, Kuyruk, Min-Heap) kullanılarak tasarlanmış olup, kritik ve normal hastaların önceliklerine göre yönetilmesini sağlar.

## Özellikler

- 🏥 **Hasta Kabul Sistemi:** Hastalar sistemde kaydedilir ve yatak müsaitliğine göre yatırılır.
- ⏱️ **Gerçek Zamanlı Öncelik Sıralama:** Kritik hastalar min-heap ile, normal hastalar kuyruk ile yönetilir.
- 🧠 **Doktor Atama Mekanizması:** Branşlara göre en az hastaya bakan doktora öncelikli hasta atanır (Min-Heap).
- 🌲 **AVL Ağaçlı Hash Tablo:** Hastalar, TC Kimlik No’ya göre yerleştirilen hash tablosunda AVL ağacıyla saklanır.
- 🧾 **Vaka (Case) Takibi:** Hastalar, vaka numaraları ve branşlara göre kategorize edilir. Hastanın vaka numarasına göre hastaya hastalık ataması yapılır.

## Kullanılan Veri Yapıları

- `HashTable<AVLTree>`: Hastaların TC numaralarına göre saklandığı yapı. İçerisinde ekleme, silme ve arama işlemleri yapılmakta.
- `MinHeap`: Kritik durumdaki hastaların ve doktorların yönetimi.
- `Queue`: Normal öncelikli hastalar için sıralı kabul sistemi.
- `CaseTable<AVL Tree>`: Vakaların numaralarına göre saklandığı yapı.  

## Kurulum

1. Bu projeyi klonlayın:

```bash
git clone https://github.com/pelinsusaglam/data-structures.git
cd 'data-structures/Final Version/HospitalSystem'
```

2. Projeyi bir .Net ortamında açın ve çalıştırın:

# Gereksinimleri yükleyin
dotnet restore

# Uygulamayı başlatın
dotnet run
