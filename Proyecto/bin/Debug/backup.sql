-- MySqlBackup.NET 2.3.1
-- Dump Time: 2020-11-24 18:40:43
-- --------------------------------------
-- Server version 5.7.24 MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of bonos
-- 

DROP TABLE IF EXISTS `bonos`;
CREATE TABLE IF NOT EXISTS `bonos` (
  `id_bono` int(10) NOT NULL AUTO_INCREMENT,
  `telefono` varchar(12) NOT NULL,
  `status` int(1) NOT NULL,
  PRIMARY KEY (`id_bono`)
) ENGINE=MyISAM AUTO_INCREMENT=1074 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table bonos
-- 

/*!40000 ALTER TABLE `bonos` DISABLE KEYS */;
INSERT INTO `bonos`(`id_bono`,`telefono`,`status`) VALUES
(1000,'3356789587',1),
(1001,'3356789587',0),
(1002,'3356789587',0),
(1003,'3356789587',0),
(1004,'3356789587',0),
(1005,'3356897421',0),
(1006,'3384567156',1),
(1007,'3384567156',0),
(1008,'3040404040',1),
(1009,'3040404040',1),
(1010,'3040404040',0),
(1011,'3040404040',0),
(1012,'3040404040',0),
(1013,'3040404040',0),
(1014,'3040404040',0),
(1015,'3040404040',0),
(1016,'3040404040',0),
(1017,'3040404040',0),
(1018,'3040404040',0),
(1019,'3040404040',0),
(1020,'3040404040',0),
(1021,'3040404040',0),
(1022,'3040404040',0),
(1023,'3040404040',0),
(1024,'3040404040',0),
(1025,'3040404040',0),
(1026,'3040404040',0),
(1027,'3040404040',0),
(1028,'3040404040',0),
(1029,'3040404040',0),
(1030,'3040404040',0),
(1031,'3040404040',0),
(1032,'3040404040',0),
(1033,'3040404040',0),
(1034,'3040404040',0),
(1035,'3040404040',0),
(1036,'3040404040',0),
(1037,'3040404040',0),
(1038,'3040404040',0),
(1039,'3040404040',0),
(1040,'3040404040',0),
(1041,'3040404040',0),
(1042,'3040404040',0),
(1043,'3040404040',0),
(1044,'3040404040',0),
(1045,'3040404040',0),
(1046,'3040404040',0),
(1047,'3040404040',0),
(1048,'3040404040',0),
(1049,'3040404040',0),
(1050,'3040404040',0),
(1051,'3040404040',0),
(1052,'3040404040',0),
(1053,'3040404040',0),
(1054,'3040404040',0),
(1055,'3040404040',0),
(1056,'3040404040',0),
(1057,'3040404040',0),
(1058,'3040404040',0),
(1059,'3040404040',0),
(1060,'3040404040',0),
(1061,'3040404040',0),
(1062,'3040404040',0),
(1063,'3040404040',0),
(1064,'3040404040',0),
(1065,'3040404040',0),
(1066,'3040404040',0),
(1067,'3040404040',0),
(1068,'3040404040',0),
(1069,'3040404040',0),
(1070,'3041414141',0),
(1071,'3040404040',0),
(1072,'3040404040',0),
(1073,'3040404040',0);
/*!40000 ALTER TABLE `bonos` ENABLE KEYS */;

-- 
-- Definition of clientes
-- 

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE IF NOT EXISTS `clientes` (
  `nombre` varchar(40) NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `rfc` varchar(30) NOT NULL,
  `correo` varchar(30) NOT NULL,
  `acumulado` float(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`telefono`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table clientes
-- 

/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes`(`nombre`,`telefono`,`direccion`,`rfc`,`correo`,`acumulado`) VALUES
('fernando rodriguez','3356897421','Historiadores 100','ffrr010203rgz','fer@gmail.com',580),
('angel perez','3384567156','revolucion120','aapp020406prz','angel@gmail.com',378),
('luis ramirez','3389451265','rio nilo 60','llrr050901rmz','luis@gmail.com',0),
('Martin Zamora','3356897455','Rosales 250','mmzz010908zmr','martin@gmail.com',0),
('Luis Perez','3356789587','Historiadores 500','llpp050405prz','luis@gmail.com',696),
('Pedro','3040404040','1','1','1',308),
('ana','3041414141','2','2','2',113.6);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;

-- 
-- Definition of detallev
-- 

DROP TABLE IF EXISTS `detallev`;
CREATE TABLE IF NOT EXISTS `detallev` (
  `folio` varchar(5) NOT NULL,
  `id producto` int(4) NOT NULL,
  `cantidad` int(3) NOT NULL,
  `precio` float(10,2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table detallev
-- 

/*!40000 ALTER TABLE `detallev` DISABLE KEYS */;
INSERT INTO `detallev`(`folio`,`id producto`,`cantidad`,`precio`) VALUES
('1',1,2,500),
('1',2,1,100),
('2',1,1,500),
('2',3,5,200),
('3',3,2,200),
('4',1,3,500),
('6',1,2,500),
('7',2,2,100),
('8',2,2,100),
('9',2,2,100),
('10',2,4,100),
('11',2,2,100),
('11',1,3,500),
('11',3,1,200),
('12',1,2,500),
('12',2,1,100),
('13',1,4,500),
('14',1,4,500),
('15',1,1,500),
('16',1,1,500),
('17',1,1,500),
('17',1000,1,-50),
('18',1,1,500),
('18',2,1,100),
('19',1,1,500),
('19',2,1,100),
('20',1,1,500),
('21',1,3,500),
('21',2,1,100),
('22',1,1,500),
('22',1006,1,-50),
('23',4,50,1000),
('23',5,40,100),
('24',6,10,80),
('25',6,2,80),
('26',6,30,80),
('26',1008,1,-50),
('26',1009,1,-50);
/*!40000 ALTER TABLE `detallev` ENABLE KEYS */;

-- 
-- Definition of empleados
-- 

DROP TABLE IF EXISTS `empleados`;
CREATE TABLE IF NOT EXISTS `empleados` (
  `id_empleado` int(4) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `rfc` varchar(30) NOT NULL,
  `correo` varchar(40) NOT NULL,
  `puesto` varchar(30) NOT NULL,
  `supervisor` varchar(40) NOT NULL,
  `salario` float(10,2) NOT NULL,
  `User` varchar(30) NOT NULL,
  `Pass` varchar(50) NOT NULL,
  PRIMARY KEY (`id_empleado`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table empleados
-- 

/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados`(`id_empleado`,`nombre`,`telefono`,`direccion`,`rfc`,`correo`,`puesto`,`supervisor`,`salario`,`User`,`Pass`) VALUES
(1,'juan gonzalez','3386954124','circuito loma 45','jjgg040508glz','juan@gmail.com','gerente','ninguno',10000,'juang','827ccb0eea8a706c4c34a16891f84e7b'),
(2,'diego diaz','3356842158','flor de liz 80','dddd060804diz','diego@gmail.com','veterinario','juan gonzales',8000,'diego','81dc9bdb52d04dc20036dbd8313ed055'),
(3,'dario lopez','3382489621','patria 480','ddll040609lpz','dario@gmail.com','cajero','juan gonzales',4000,'dariol','81dc9bdb52d04dc20036dbd8313ed055'),
(4,'Rodrigo Lopez','3358969877','independencia 300','rrll050704lpz','rodrigo@gmail.com','cajero','juan gonzales',4000,'rodrigol','81dc9bdb52d04dc20036dbd8313ed055'),
(5,'Juan Rodriguez','3369858475','flor de liz 20','jjrr201095rdz','juan@gmail.com','veterinario','juan gonzales',5000,'juanr','81dc9bdb52d04dc20036dbd8313ed055');
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;

-- 
-- Definition of productos
-- 

DROP TABLE IF EXISTS `productos`;
CREATE TABLE IF NOT EXISTS `productos` (
  `id_producto` int(4) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `marca` varchar(30) NOT NULL,
  `categoria` varchar(30) NOT NULL,
  `ubicacion` varchar(20) NOT NULL,
  `cant_max` int(4) NOT NULL,
  `cant_min` int(4) NOT NULL,
  `precioV` float(10,2) NOT NULL,
  `precioC` float(10,2) NOT NULL,
  `stock` int(4) NOT NULL,
  `venta` int(2) NOT NULL,
  PRIMARY KEY (`id_producto`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table productos
-- 

/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos`(`id_producto`,`nombre`,`descripcion`,`marca`,`categoria`,`ubicacion`,`cant_max`,`cant_min`,`precioV`,`precioC`,`stock`,`venta`) VALUES
(1,'croqueta para perro','costal de croqueta de pollo de 50kg','purina','alimentos','almacen',5,1,500,350,22,0),
(2,'hueso para morder','hueso de hilo blanco para morder','purina','juguetes','piso de venta',7,2,100,75,9,0),
(3,'Cojin azul','Cojin azul relleno para mascotas','petcare','muebles','almacen',5,2,200,120,10,0),
(4,'1000','1000','1000','1','1',100,10,1000,900,0,0),
(5,'1001','1001','1001','1','1',100,10,100,90,60,0),
(6,'1002','1002','1002','1','1',100,10,80,70,58,0);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;

-- 
-- Definition of ventas
-- 

DROP TABLE IF EXISTS `ventas`;
CREATE TABLE IF NOT EXISTS `ventas` (
  `folio` varchar(5) NOT NULL,
  `fecha` date NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `id_empleado` int(4) NOT NULL,
  PRIMARY KEY (`folio`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table ventas
-- 

/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas`(`folio`,`fecha`,`telefono`,`id_empleado`) VALUES
('1','2020-05-20 00:00:00','3356897421',1),
('2','2020-05-20 00:00:00','3356897421',1),
('3','2020-05-20 00:00:00','3389451265',1),
('4','2020-05-20 00:00:00','3384567156',2),
('5','2020-05-20 00:00:00','3384567156',3),
('6','2020-05-20 00:00:00','3384567156',2),
('7','2020-05-20 00:00:00','3384567156',2),
('8','2020-05-20 00:00:00','3384567156',2),
('9','2020-05-20 00:00:00','3384567156',2),
('10','2020-05-20 00:00:00','3384567156',3),
('11','2020-05-20 00:00:00','3356897421',1),
('12','2020-05-29 00:00:00','3356897421',1),
('13','2020-06-01 00:00:00','3356789587',1),
('14','2020-06-01 00:00:00','3356789587',1),
('16','2020-06-01 00:00:00','3356789587',1),
('15','2020-06-01 00:00:00','3356789587',1),
('17','2020-06-01 00:00:00','3356789587',1),
('18','2020-06-01 00:00:00','3356897421',2),
('19','2020-06-01 00:00:00','3356897421',2),
('20','2020-06-01 00:00:00','3356897421',2),
('21','2020-06-01 00:00:00','3384567156',3),
('22','2020-06-01 00:00:00','3384567156',3),
('23','2020-06-01 00:00:00','3040404040',2),
('24','2020-06-01 00:00:00','3041414141',2),
('25','2020-06-01 00:00:00','3041414141',2),
('26','2020-06-01 00:00:00','3040404040',1);
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2020-11-24 18:40:44
-- Total time: 0:0:0:0:117 (d:h:m:s:ms)
