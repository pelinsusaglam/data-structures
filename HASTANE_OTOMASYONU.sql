-- MySQL dump 10.13  Distrib 8.0.42, for macos15 (arm64)
--
-- Host: localhost    Database: HASTANE_OTOMASYONU
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `atananlar`
--

DROP TABLE IF EXISTS `atananlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `atananlar` (
  `atama_id` int NOT NULL AUTO_INCREMENT,
  `hasta_id` int DEFAULT NULL,
  `doktor_id` int DEFAULT NULL,
  `atama_zamani` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`atama_id`),
  KEY `hasta_id` (`hasta_id`),
  KEY `doktor_id` (`doktor_id`),
  CONSTRAINT `atananlar_ibfk_1` FOREIGN KEY (`hasta_id`) REFERENCES `hastalar` (`hasta_id`),
  CONSTRAINT `atananlar_ibfk_2` FOREIGN KEY (`doktor_id`) REFERENCES `doktorlar` (`doktor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atananlar`
--

LOCK TABLES `atananlar` WRITE;
/*!40000 ALTER TABLE `atananlar` DISABLE KEYS */;
/*!40000 ALTER TABLE `atananlar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doktorlar`
--

DROP TABLE IF EXISTS `doktorlar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doktorlar` (
  `doktor_id` int NOT NULL AUTO_INCREMENT,
  `ad_soyad` text NOT NULL,
  `uzmanlik` text NOT NULL,
  `musait` int DEFAULT '1',
  `tc_no` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`doktor_id`),
  CONSTRAINT `doktorlar_chk_1` CHECK ((`musait` in (0,1)))
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doktorlar`
--

LOCK TABLES `doktorlar` WRITE;
/*!40000 ALTER TABLE `doktorlar` DISABLE KEYS */;
INSERT INTO `doktorlar` VALUES (1,'Dr. Ali Yılmaz','Kardiyoloji',1,'10000000001'),(2,'Dr. Aylin Güngör','Kardiyoloji',1,'10000000002'),(3,'Dr. Ayşe Demir','Nöroloji',1,'10000000003'),(4,'Dr. Halil Aydın','Nöroloji',1,'10000000004'),(5,'Dr. Deniz Güneş','Nöroloji',1,'10000000005'),(6,'Dr. Mehmet Kaya','Travma',1,'10000000006'),(7,'Dr. Elvan Coşkun','Travma',1,'10000000007'),(8,'Dr. Zeynep Şahin','Göğüs Hastalıkları',1,'10000000008'),(9,'Dr. Onur Duman','Göğüs Hastalıkları',1,'10000000009'),(10,'Dr. Burak Aslan','Endokrinoloji',1,'10000000010'),(11,'Dr. Nihan Yalçın','Endokrinoloji',1,'10000000011'),(12,'Dr. Ceren Aksoy','Enfeksiyon',1,'10000000012'),(13,'Dr. Eda Karabulut','Enfeksiyon',1,'10000000013'),(14,'Dr. Ahmet Koç','Dahiliye',1,'10000000014'),(15,'Dr. İrem Tan','Dahiliye',1,'10000000015'),(16,'Dr. Selim Arslan','Genel Cerrahi',1,'10000000016'),(17,'Dr. Rüya Bilgin','Genel Cerrahi',1,'10000000017'),(18,'Dr. Merve Aydın','Kadın Doğum',1,'10000000018'),(19,'Dr. Fikret Şen','Kadın Doğum',1,'10000000019'),(20,'Dr. Murat Öztürk','Acil Müdahale',1,'10000000020'),(21,'Dr. Hande Şimşek','Acil Müdahale',1,'10000000021'),(22,'Dr. Volkan Aydın','Acil Müdahale',1,'10000000022'),(23,'Dr. Selda Tekin','Acil Müdahale',1,'10000000023'),(24,'Dr. Okan Kaya','Acil Müdahale',1,'10000000024'),(25,'Dr. Derya Toprak','Psikiyatri',1,'10000000025'),(26,'Dr. Ebru Ersoy','Toksikoloji',1,'10000000026'),(27,'Dr. Hakan Tunç','Üroloji',1,'10000000027'),(28,'Dr. Dilan Karaca','Kulak Burun Boğaz',1,'10000000028'),(29,'Dr. Can Polat','Diş Hekimliği',1,'10000000029'),(30,'Dr. Sinem Şimşek','Fizik Tedavi',1,'10000000030'),(31,'Dr. Levent Bayraktar','Alerji/İmmünoloji',1,'10000000031');
/*!40000 ALTER TABLE `doktorlar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hastalar`
--

DROP TABLE IF EXISTS `hastalar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hastalar` (
  `hasta_id` int NOT NULL AUTO_INCREMENT,
  `tc_no` varchar(11) NOT NULL,
  `isim` varchar(100) NOT NULL,
  `yas` int DEFAULT NULL,
  `vaka_id` int DEFAULT NULL,
  `durum` varchar(50) DEFAULT 'bekliyor',
  PRIMARY KEY (`hasta_id`),
  UNIQUE KEY `tc_no` (`tc_no`),
  KEY `vaka_id` (`vaka_id`),
  CONSTRAINT `hastalar_ibfk_1` FOREIGN KEY (`vaka_id`) REFERENCES `vakalar` (`vaka_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hastalar`
--

LOCK TABLES `hastalar` WRITE;
/*!40000 ALTER TABLE `hastalar` DISABLE KEYS */;
/*!40000 ALTER TABLE `hastalar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personeller`
--

DROP TABLE IF EXISTS `personeller`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personeller` (
  `personel_id` int NOT NULL AUTO_INCREMENT,
  `tc_no` varchar(11) NOT NULL,
  `ad_soyad` text NOT NULL,
  PRIMARY KEY (`personel_id`),
  UNIQUE KEY `tc_no` (`tc_no`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personeller`
--

LOCK TABLES `personeller` WRITE;
/*!40000 ALTER TABLE `personeller` DISABLE KEYS */;
INSERT INTO `personeller` VALUES (1,'20000000001','Ahmet Yılmaz'),(2,'20000000002','Ayşe Demir'),(3,'20000000003','Mehmet Koç'),(4,'20000000004','Zeynep Şahin'),(5,'20000000005','Fatma Kılıç'),(6,'20000000006','Ali Çelik'),(7,'20000000007','Emine Özdemir'),(8,'20000000008','Hasan Arslan'),(9,'20000000009','Elif Kara'),(10,'20000000010','Kemal Yavuz'),(11,'20000000011','Merve Ersoy'),(12,'20000000012','Onur Aydın'),(13,'20000000013','Seda Polat'),(14,'20000000014','Tamer Güneş'),(15,'20000000015','Derya Taş'),(16,'20000000016','İsmail Kurt'),(17,'20000000017','Gülcan Tekin'),(18,'20000000018','Ramazan Bilgin'),(19,'20000000019','Hülya Uçar'),(20,'20000000020','Okan Karaca'),(21,'20000000021','Serap Kaplan'),(22,'20000000022','Tolga Ekinci'),(23,'20000000023','Hande Çetin'),(24,'20000000024','Burak Şahin'),(25,'20000000025','Aysel Erdoğan'),(26,'20000000026','Salih Öztürk'),(27,'20000000027','Nazlı Güler'),(28,'20000000028','Baran Duman'),(29,'20000000029','Melis Koçak'),(30,'20000000030','Yusuf Aksoy'),(31,'20000000031','Pınar Soylu'),(32,'20000000032','Furkan Korkmaz'),(33,'20000000033','Songül Yıldız'),(34,'20000000034','Necati Demirtaş'),(35,'20000000035','Cansu Şimşek'),(36,'20000000036','Murat Dalkıran'),(37,'20000000037','Büşra Gökçe'),(38,'20000000038','Engin Tok'),(39,'20000000039','Selin Yılmaz'),(40,'20000000040','Ömer Faruk Yıldırım'),(41,'20000000041','Dilara Akın'),(42,'20000000042','Hakan Barut'),(43,'20000000043','Sevgi Özkan'),(44,'20000000044','Vedat Güler'),(45,'20000000045','İrem Acar'),(46,'20000000046','Çağatay Ateş'),(47,'20000000047','Yaren Yalçın'),(48,'20000000048','Musa Bal'),(49,'20000000049','Sibel Uysal'),(50,'20000000050','Kerem Tan');
/*!40000 ALTER TABLE `personeller` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vakalar`
--

DROP TABLE IF EXISTS `vakalar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vakalar` (
  `vaka_id` int NOT NULL AUTO_INCREMENT,
  `ad` text NOT NULL,
  `kategori` text,
  `oncelik` int DEFAULT NULL,
  `aciklama` text,
  PRIMARY KEY (`vaka_id`),
  CONSTRAINT `vakalar_chk_1` CHECK ((`oncelik` between 1 and 5))
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vakalar`
--

LOCK TABLES `vakalar` WRITE;
/*!40000 ALTER TABLE `vakalar` DISABLE KEYS */;
INSERT INTO `vakalar` VALUES (1,'Araba Kazası','Travma',1,'Çok acil'),(2,'Bıçaklanma','Travma',1,'Yoğun kan kaybı riski'),(3,'Kalp Krizi','Kardiyoloji',1,'Hemen müdahale gerekir'),(4,'Solunum Yetmezliği','Göğüs Hastalıkları',2,'Ciddi ama orta derecede acil'),(5,'Şeker Koması','Endokrinoloji',2,'Müdahale şart'),(6,'Yüksek Ateş','Enfeksiyon',3,'Takip gerekli'),(7,'Mide Bulantısı','Dahiliye',4,'Düşük öncelikli'),(8,'Baş Ağrısı','Nöroloji',5,'Düşük öncelik'),(9,'Grip','Enfeksiyon',5,'Çok düşük öncelik'),(10,'Boğulma','Acil Müdahale',1,'Anında müdahale'),(11,'Bilinç Kaybı','Nöroloji',1,'Travmaya bağlı olabilir'),(12,'Zehirlenme','Toksikoloji',2,'Hızlı müdahale gerekebilir'),(13,'Felç (İnme)','Nöroloji',1,'Ani müdahale şart'),(14,'Düşme sonucu travma','Ortopedi',2,'Kırık veya iç kanama riski'),(15,'Astım Krizi','Göğüs Hastalıkları',1,'Acil müdahale gerekebilir'),(16,'Hipoglisemi','Endokrinoloji',2,'Bayılma riski'),(17,'Apandisit','Genel Cerrahi',2,'Cerrahi müdahale gerekebilir'),(18,'Migren','Nöroloji',4,'Ağrı kontrolü önemli'),(19,'İdrar Yolu Enfeksiyonu','Üroloji',4,'Antibiyotik gerekebilir'),(20,'Alkol Zehirlenmesi','Acil/Toksikoloji',2,'İzlem ve destek şart'),(21,'Menenjit','Enfeksiyon/Nöroloji',1,'Çok hızlı ilerleyen tehlikeli vaka'),(22,'Gıda Zehirlenmesi','Dahiliye',3,'Sıvı kaybı riski'),(23,'Kulak Enfeksiyonu','Kulak Burun Boğaz',5,'Düşük öncelik'),(24,'Diş Ağrısı','Diş Hekimliği',5,'Acil değil'),(25,'Bel Fıtığı Ağrısı','Fizik Tedavi',4,'Müdahale gerekebilir ama acil değil'),(26,'Doğum Başlangıcı','Kadın Doğum',1,'Anında takip gerekli'),(27,'Panik Atak','Psikiyatri',3,'Kriz halinde destek gerekli'),(28,'Epilepsi Nöbeti','Nöroloji',1,'Hızlı müdahale gerekir'),(29,'Alerjik Reaksiyon','Alerji/İmmünoloji',2,'Şiddetine göre değişir'),(30,'Trafik kazasında bilinç kaybı','Acil/Travma',1,'Çok yüksek öncelik');
/*!40000 ALTER TABLE `vakalar` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-21 18:12:34
