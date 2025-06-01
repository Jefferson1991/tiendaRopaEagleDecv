-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: mainline.proxy.rlwy.net    Database: railway
-- ------------------------------------------------------
-- Server version	9.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Categorias`
--

DROP TABLE IF EXISTS `Categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Categorias` (
  `IdCategoria` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `IdCategoriaPadre` int DEFAULT NULL,
  PRIMARY KEY (`IdCategoria`),
  KEY `IdCategoriaPadre` (`IdCategoriaPadre`),
  CONSTRAINT `Categorias_ibfk_1` FOREIGN KEY (`IdCategoriaPadre`) REFERENCES `Categorias` (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Categorias`
--

LOCK TABLES `Categorias` WRITE;
/*!40000 ALTER TABLE `Categorias` DISABLE KEYS */;
INSERT INTO `Categorias` VALUES (1,'Cuadernos',NULL);
/*!40000 ALTER TABLE `Categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Inventario`
--

DROP TABLE IF EXISTS `Inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Inventario` (
  `IdInventario` int NOT NULL AUTO_INCREMENT,
  `IdProducto` int DEFAULT NULL,
  `Stock` int DEFAULT '0',
  PRIMARY KEY (`IdInventario`),
  KEY `IdProducto` (`IdProducto`),
  CONSTRAINT `Inventario_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `Productos` (`IdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Inventario`
--

LOCK TABLES `Inventario` WRITE;
/*!40000 ALTER TABLE `Inventario` DISABLE KEYS */;
/*!40000 ALTER TABLE `Inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductoColores`
--

DROP TABLE IF EXISTS `ProductoColores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductoColores` (
  `IdProductoColor` int NOT NULL AUTO_INCREMENT,
  `IdProducto` int DEFAULT NULL,
  `Color` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdProductoColor`),
  KEY `IdProducto` (`IdProducto`),
  CONSTRAINT `ProductoColores_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `Productos` (`IdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductoColores`
--

LOCK TABLES `ProductoColores` WRITE;
/*!40000 ALTER TABLE `ProductoColores` DISABLE KEYS */;
/*!40000 ALTER TABLE `ProductoColores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductoTallas`
--

DROP TABLE IF EXISTS `ProductoTallas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductoTallas` (
  `IdProductoTalla` int NOT NULL AUTO_INCREMENT,
  `IdProducto` int DEFAULT NULL,
  `Talla` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`IdProductoTalla`),
  KEY `IdProducto` (`IdProducto`),
  CONSTRAINT `ProductoTallas_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `Productos` (`IdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductoTallas`
--

LOCK TABLES `ProductoTallas` WRITE;
/*!40000 ALTER TABLE `ProductoTallas` DISABLE KEYS */;
/*!40000 ALTER TABLE `ProductoTallas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Productos`
--

DROP TABLE IF EXISTS `Productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Productos` (
  `IdProducto` int NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(50) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` text,
  `Precio` decimal(10,2) DEFAULT NULL,
  `Marca` varchar(100) DEFAULT NULL,
  `ImagenUrl` varchar(255) DEFAULT NULL,
  `IdCategoria` int DEFAULT NULL,
  `FechaCreacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdProducto`),
  UNIQUE KEY `Codigo` (`Codigo`),
  KEY `IdCategoria` (`IdCategoria`),
  CONSTRAINT `Productos_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `Categorias` (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Productos`
--

LOCK TABLES `Productos` WRITE;
/*!40000 ALTER TABLE `Productos` DISABLE KEYS */;
INSERT INTO `Productos` VALUES (1,'CUADERNOS001221','CUADERNOS001231','CUADERNO UNA LINEA',1.80,'ESCOLAR','http://tiendaonlinedevops/cuaderno002522.jpg',1,'2025-06-01 04:59:05'),(3,'CUADERNOS00121','CUADERNOS00121','CUADERNO CUADROS',1.50,'NORMA','http://tiendaonlinedevops/cuaderno002.jpg',1,'2025-06-01 05:01:01');
/*!40000 ALTER TABLE `Productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Roles`
--

DROP TABLE IF EXISTS `Roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Roles` (
  `IdRol` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`IdRol`),
  UNIQUE KEY `Nombre` (`Nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Roles`
--

LOCK TABLES `Roles` WRITE;
/*!40000 ALTER TABLE `Roles` DISABLE KEYS */;
INSERT INTO `Roles` VALUES (1,'Administrador'),(3,'Cliente'),(2,'Vendedor');
/*!40000 ALTER TABLE `Roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Usuarios`
--

DROP TABLE IF EXISTS `Usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Usuarios` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `NombreUsuario` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `ContrasenaHash` varchar(255) NOT NULL,
  `IdRol` int DEFAULT NULL,
  `Activo` tinyint(1) DEFAULT '1',
  `FechaCreacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `NombreUsuario` (`NombreUsuario`),
  UNIQUE KEY `Email` (`Email`),
  KEY `IdRol` (`IdRol`),
  CONSTRAINT `Usuarios_ibfk_1` FOREIGN KEY (`IdRol`) REFERENCES `Roles` (`IdRol`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Usuarios`
--

LOCK TABLES `Usuarios` WRITE;
/*!40000 ALTER TABLE `Usuarios` DISABLE KEYS */;
INSERT INTO `Usuarios` VALUES (1,'jvasconez@uisrael.edu.ec','jvasconez@uisrael.edu.ec','$2a$11$xfpSKU8se2p/el7h1aYp1eEQ7UT3OwW2EOt4Jb/ONLVJACN1H/iA.',1,1,'2025-06-01 01:02:47'),(3,'vendedor1@uisrael.edu.ec','vendedor1@uisrael.edu.ec','$2a$11$XqcO588e.S/jcLVEgOhioe7uJLJow4DH.O7Ze.z844NFBZ3E9/gYG',2,1,'2025-06-01 05:09:09'),(4,'cliente@maxweel','cliente@maxweel','$2a$11$R0hbF48cuA04LtX8crTfLO33t5TLeXYR4Q22LycRzOU3VT4hWO/Na',3,1,'2025-06-01 05:09:42');
/*!40000 ALTER TABLE `Usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-01  0:33:34
