#include <mysql.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define hospital_capacity 50 //Hastane aynı anda 50 kişi kaldırabilir.

int count = 0; //Yatan hasta sayısını tutar.
typedef struct hasta {
    unsigned long long int tc_no; //Hastanın TC kimlik numarası
    char isim[50]; //Hastanın adı ve soyadı
    int yas;
    char durum[10]; //Hastanın durumu: kritik, stabil, iyi
    int vaka_id;
    struct hasta *next;
}hasta;
typedef hasta* hasta_ptr;

typedef struct list {
    hasta_ptr head;
    hasta_ptr tail;
}list;
typedef list* list_ptr;

list_ptr hash_table2[hospital_capacity]; //Her indeksteki bağlı listelerin başını ve sonunu tutar.
hasta_ptr hash_table[hospital_capacity]; //Acildeki hastaları tutacak olan liste dizisi. Her indekste bir liste tutulacak.

int hash(int id) {
    return id % hospital_capacity; //Hastane kapasitesine göre key oluşturur.
}

MYSQL* mysql_baglan() {
    MYSQL *conn = mysql_init(NULL);
    if (conn == NULL) {
        fprintf(stderr, "MySQL init hatası: %s\n", mysql_error(conn));
        exit(EXIT_FAILURE);
    }

    if (mysql_real_connect(conn, "localhost", "root", "", "HASTANE_OTOMASYONU", 0, NULL, 0) == NULL) {
        fprintf(stderr, "Bağlantı hatası: %s\n", mysql_error(conn));
        mysql_close(conn);
        exit(EXIT_FAILURE);
    }

    printf("MySQL veritabanına başarıyla bağlanıldı.\n");
    return conn;
}

void hasta_veritabani_ekle(MYSQL *conn, hasta_ptr hasta) {
    char sorgu[512];

    snprintf(sorgu, sizeof(sorgu),
             "INSERT INTO hastalar (tc_no, isim, yas, vaka_id, durum) VALUES ('%llu', '%s', %d, %d, '%s')",
             hasta->tc_no, hasta->isim, hasta->yas, hasta->vaka_id, hasta->durum);

    if (mysql_query(conn, sorgu)) {
        fprintf(stderr, "Hasta eklenemedi: %s\n", mysql_error(conn));
    } else {
        printf("Hasta eklendi: %s\n", hasta->isim);
    }
}

void put(MYSQL *conn, unsigned long long int tc_no, char isim[], char durum[], int vaka_id, int yas) {
    if (count != hospital_capacity) {
        int index = hash(tc_no);
        hasta_ptr new = (hasta_ptr) malloc(sizeof(hasta)); //Yeni hasta için düğüm oluşturur.
        new -> yas = yas;
        new->tc_no = tc_no;
        strcpy(new->isim, isim);
        strcpy(new->durum, durum);
        new->vaka_id = vaka_id; //Gerekli atamalar yapıldı.
        new->next = NULL;
        if (hash_table[index] == NULL) { //Karşılık gelen key'e ait indeks hash tablosunda boşsa atama yapar.
            hash_table[index] = new;
            hasta_veritabani_ekle(conn, new);
            hash_table2[index] = (list_ptr) malloc(sizeof(list));
            hash_table2[index]->head = new;
            hash_table2[index]->tail = new;
            count++;
        }
        else {
            new -> next = hash_table[index]; //Boş değilse chaining ile o indeksteki listenin başına ekler.
            hash_table[index] = new;
            hasta_veritabani_ekle(conn, new);
            hash_table2[index]->head = new;
            hasta_ptr temp = hash_table2[index]->head;
            while (temp -> next != NULL) {
                temp = temp -> next;
            }
            hash_table2[index]->tail = temp;
            count++;
        }
    }
    else {
        printf("Yataklar dolu ekleme yapılamaz.");
    }
}

hasta_ptr get(int tc_no) {
    int index = hash(tc_no);
    hasta_ptr iter = hash_table[index];
    while (iter != NULL) {
        if (iter->tc_no == tc_no) {
            return iter;
        }
        iter = iter->next;
    }
    printf("Aranan hasta bulunamadı.");
    return NULL;
}

void update(int tc_no, char* durum, int yeni_vaka_id) {
    hasta_ptr arananHasta = get(tc_no);
    if (arananHasta == NULL) {
        printf("Hastanede böyle bir hasta bulunmamakta.");
    }
    else {
        arananHasta->vaka_id = yeni_vaka_id;
        strcpy(arananHasta->durum, durum);
    }
}

void printer() {
    for (int i = 0; i < hospital_capacity; i++) {
        hasta_ptr iter = hash_table[i];
        if (iter != NULL) {
            printf("[DEBUG] %d. indexte hasta var.\n", i);
        }
        while (iter != NULL) {
            printf("%llu - %s - %s - %d\n", iter->tc_no, iter->isim, iter->durum, iter->vaka_id);
            iter = iter->next;
        }
    }
}

void searchedPrinter(int id) {
    hasta_ptr temp = get(id);
    printf("%llu - %s - %s - %d \n", temp->tc_no, temp->isim, temp->durum,temp->vaka_id);
}

void deletePatient(int tc_no) {
    hasta_ptr temp = get(tc_no); //Eğer hasta bulunursa bulunduğu düğümü bulunamazsa NULL döndürür.
    int index = hash(tc_no);
    if (temp == NULL) {
        printf("Silinecek hasta bulunmamakta.");
    }
    else {
        if (temp == hash_table2[index]->head) { //Aranan hastanın düğümü bulunduğu indeksin baş düğümüyse:
            if (temp -> next != NULL) { //Listede birden çok eleman varsa.
                hash_table2[index]->head = hash_table2[index]->head->next;
                hash_table[index] = temp -> next;
                free(temp);
            }
            else { //Listede tek eleman varsa.
                hash_table[index] = NULL;
                hash_table2[index]->head = NULL;
                hash_table2[index]->tail = NULL;
            }
        }
        else if (temp == hash_table2[index]->tail) { //Silinecek eleman listenin son elemanı.
            if (hash_table2[index]->head == hash_table2[index]->tail) { //Listede tek eleman var.
                hash_table2[index]->head = NULL;
                hash_table2[index]->tail = NULL;
                hash_table[index] = NULL;
            }
            else {
                hasta_ptr iter = hash_table2[index]->head;
                while (iter -> next != hash_table2[index]->tail) {
                    iter = iter -> next;
                }
                hash_table2[index] -> tail = iter;
                iter -> next = NULL;
                free(temp);
            }
        }
        else {//Silinecek eleman listede ortada bir elemansa:
            hasta_ptr iter = hash_table[index];
            while (iter -> next != temp) {
                iter = iter -> next;
            }
            iter -> next = temp -> next;
            free(temp);
        }
    }
}

void deletePatient_info(){
    int tc_no;
    printf("Silinecek hastaya ait id'yi giriniz: ");
    scanf("%llu", &tc_no);
    printf("%llu",tc_no);
    deletePatient(tc_no);
}

void addPatient(MYSQL *conn) {
    char isim[50],durum[50];
    int vaka_id,yas;
    unsigned long long int tc_no;
    printf("Yeni hastaya ait ismi ve soyismi giriniz: ");
    fgets(isim,sizeof(isim),stdin);
    strtok(isim, "\n");
    printf("Hastanin TC Kimlik numarasini giriniz: ");
    scanf("%llu",&tc_no);
    while (getchar() != '\n');
    printf("Hastanin yasini giriniz: ");
    scanf("%d", &yas);
    while (getchar() != '\n');
    printf("Hastanin vaka ID'sini giriniz: ");
    scanf("%d", &vaka_id);
    while (getchar() != '\n');
    printf("Hastanin durumunu giriniz: ");
    fgets(durum,sizeof(durum),stdin);
    strtok(durum, "\n");
    put(conn,tc_no,isim,durum,vaka_id,yas);
    printf("Hasta basariyla eklendi.\n");
}

int main() {
    MYSQL *conn = mysql_baglan();
    addPatient(conn);
    printer();
    mysql_close(conn);
}