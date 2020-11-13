-- phpMyAdmin SQL Dump
-- version 4.5.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 01-06-2020 a las 21:44:33
-- Versión del servidor: 5.7.11
-- Versión de PHP: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `vet-soft`
--
CREATE DATABASE IF NOT EXISTS `vet-soft` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `vet-soft`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bonos`
--

CREATE TABLE `bonos` (
  `id_bono` int(10) NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `status` int(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `bonos`
--

INSERT INTO `bonos` (`id_bono`, `telefono`, `status`) VALUES
(1000, '3356789587', 1),
(1001, '3356789587', 0),
(1002, '3356789587', 0),
(1003, '3356789587', 0),
(1004, '3356789587', 0),
(1005, '3356897421', 0),
(1006, '3384567156', 1),
(1007, '3384567156', 0),
(1008, '3040404040', 1),
(1009, '3040404040', 1),
(1010, '3040404040', 0),
(1011, '3040404040', 0),
(1012, '3040404040', 0),
(1013, '3040404040', 0),
(1014, '3040404040', 0),
(1015, '3040404040', 0),
(1016, '3040404040', 0),
(1017, '3040404040', 0),
(1018, '3040404040', 0),
(1019, '3040404040', 0),
(1020, '3040404040', 0),
(1021, '3040404040', 0),
(1022, '3040404040', 0),
(1023, '3040404040', 0),
(1024, '3040404040', 0),
(1025, '3040404040', 0),
(1026, '3040404040', 0),
(1027, '3040404040', 0),
(1028, '3040404040', 0),
(1029, '3040404040', 0),
(1030, '3040404040', 0),
(1031, '3040404040', 0),
(1032, '3040404040', 0),
(1033, '3040404040', 0),
(1034, '3040404040', 0),
(1035, '3040404040', 0),
(1036, '3040404040', 0),
(1037, '3040404040', 0),
(1038, '3040404040', 0),
(1039, '3040404040', 0),
(1040, '3040404040', 0),
(1041, '3040404040', 0),
(1042, '3040404040', 0),
(1043, '3040404040', 0),
(1044, '3040404040', 0),
(1045, '3040404040', 0),
(1046, '3040404040', 0),
(1047, '3040404040', 0),
(1048, '3040404040', 0),
(1049, '3040404040', 0),
(1050, '3040404040', 0),
(1051, '3040404040', 0),
(1052, '3040404040', 0),
(1053, '3040404040', 0),
(1054, '3040404040', 0),
(1055, '3040404040', 0),
(1056, '3040404040', 0),
(1057, '3040404040', 0),
(1058, '3040404040', 0),
(1059, '3040404040', 0),
(1060, '3040404040', 0),
(1061, '3040404040', 0),
(1062, '3040404040', 0),
(1063, '3040404040', 0),
(1064, '3040404040', 0),
(1065, '3040404040', 0),
(1066, '3040404040', 0),
(1067, '3040404040', 0),
(1068, '3040404040', 0),
(1069, '3040404040', 0),
(1070, '3041414141', 0),
(1071, '3040404040', 0),
(1072, '3040404040', 0),
(1073, '3040404040', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `nombre` varchar(40) NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `rfc` varchar(30) NOT NULL,
  `correo` varchar(30) NOT NULL,
  `acumulado` float(10,2) NOT NULL DEFAULT '0.00'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`nombre`, `telefono`, `direccion`, `rfc`, `correo`, `acumulado`) VALUES
('fernando rodriguez', '3356897421', 'Historiadores 100', 'ffrr010203rgz', 'fer@gmail.com', 580.00),
('angel perez', '3384567156', 'revolucion120', 'aapp020406prz', 'angel@gmail.com', 378.00),
('luis ramirez', '3389451265', 'rio nilo 60', 'llrr050901rmz', 'luis@gmail.com', 0.00),
('Martin Zamora', '3356897455', 'Rosales 250', 'mmzz010908zmr', 'martin@gmail.com', 0.00),
('Luis Perez', '3356789587', 'Historiadores 500', 'llpp050405prz', 'luis@gmail.com', 696.00),
('Pedro', '3040404040', '1', '1', '1', 308.00),
('ana', '3041414141', '2', '2', '2', 113.60);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detallev`
--

CREATE TABLE `detallev` (
  `folio` varchar(5) NOT NULL,
  `id producto` int(4) NOT NULL,
  `cantidad` int(3) NOT NULL,
  `precio` float(10,2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `detallev`
--

INSERT INTO `detallev` (`folio`, `id producto`, `cantidad`, `precio`) VALUES
('1', 1, 2, 500.00),
('1', 2, 1, 100.00),
('2', 1, 1, 500.00),
('2', 3, 5, 200.00),
('3', 3, 2, 200.00),
('4', 1, 3, 500.00),
('6', 1, 2, 500.00),
('7', 2, 2, 100.00),
('8', 2, 2, 100.00),
('9', 2, 2, 100.00),
('10', 2, 4, 100.00),
('11', 2, 2, 100.00),
('11', 1, 3, 500.00),
('11', 3, 1, 200.00),
('12', 1, 2, 500.00),
('12', 2, 1, 100.00),
('13', 1, 4, 500.00),
('14', 1, 4, 500.00),
('15', 1, 1, 500.00),
('16', 1, 1, 500.00),
('17', 1, 1, 500.00),
('17', 1000, 1, -50.00),
('18', 1, 1, 500.00),
('18', 2, 1, 100.00),
('19', 1, 1, 500.00),
('19', 2, 1, 100.00),
('20', 1, 1, 500.00),
('21', 1, 3, 500.00),
('21', 2, 1, 100.00),
('22', 1, 1, 500.00),
('22', 1006, 1, -50.00),
('23', 4, 50, 1000.00),
('23', 5, 40, 100.00),
('24', 6, 10, 80.00),
('25', 6, 2, 80.00),
('26', 6, 30, 80.00),
('26', 1008, 1, -50.00),
('26', 1009, 1, -50.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

CREATE TABLE `empleados` (
  `id_empleado` int(4) NOT NULL,
  `nombre` varchar(40) NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `rfc` varchar(30) NOT NULL,
  `correo` varchar(40) NOT NULL,
  `puesto` varchar(30) NOT NULL,
  `supervisor` varchar(40) NOT NULL,
  `salario` float(10,2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleados`
--

INSERT INTO `empleados` (`id_empleado`, `nombre`, `telefono`, `direccion`, `rfc`, `correo`, `puesto`, `supervisor`, `salario`) VALUES
(1, 'juan gonzalez', '3386954124', 'circuito loma 45', 'jjgg040508glz', 'juan@gmail.com', 'gerente', 'ninguno', 10000.00),
(2, 'diego diaz', '3356842158', 'flor de liz 80', 'dddd060804diz', 'diego@gmail.com', 'veterinario', 'juan gonzales', 8000.00),
(3, 'dario lopez', '3382489621', 'patria 480', 'ddll040609lpz', 'dario@gmail.com', 'cajero', 'juan gonzales', 4000.00),
(4, 'Rodrigo Lopez', '3358969877', 'independencia 300', 'rrll050704lpz', 'rodrigo@gmail.com', 'cajero', 'juan gonzales', 4000.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(4) NOT NULL,
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
  `venta` int(2) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `nombre`, `descripcion`, `marca`, `categoria`, `ubicacion`, `cant_max`, `cant_min`, `precioV`, `precioC`, `stock`, `venta`) VALUES
(1, 'croqueta para perro', 'costal de croqueta de pollo de 50kg', 'purina', 'alimentos', 'almacen', 5, 1, 500.00, 350.00, 22, 0),
(2, 'hueso para morder', 'hueso de hilo blanco para morder', 'purina', 'juguetes', 'piso de venta', 7, 2, 100.00, 75.00, 9, 0),
(3, 'Cojin azul', 'Cojin azul relleno para mascotas', 'petcare', 'muebles', 'almacen', 5, 2, 200.00, 120.00, 10, 0),
(4, '1000', '1000', '1000', '1', '1', 100, 10, 1000.00, 900.00, 0, 0),
(5, '1001', '1001', '1001', '1', '1', 100, 10, 100.00, 90.00, 60, 0),
(6, '1002', '1002', '1002', '1', '1', 100, 10, 80.00, 70.00, 58, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `folio` varchar(5) NOT NULL,
  `fecha` date NOT NULL,
  `telefono` varchar(12) NOT NULL,
  `id_empleado` int(4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`folio`, `fecha`, `telefono`, `id_empleado`) VALUES
('1', '2020-05-20', '3356897421', 1),
('2', '2020-05-20', '3356897421', 1),
('3', '2020-05-20', '3389451265', 1),
('4', '2020-05-20', '3384567156', 2),
('5', '2020-05-20', '3384567156', 3),
('6', '2020-05-20', '3384567156', 2),
('7', '2020-05-20', '3384567156', 2),
('8', '2020-05-20', '3384567156', 2),
('9', '2020-05-20', '3384567156', 2),
('10', '2020-05-20', '3384567156', 3),
('11', '2020-05-20', '3356897421', 1),
('12', '2020-05-29', '3356897421', 1),
('13', '2020-06-01', '3356789587', 1),
('14', '2020-06-01', '3356789587', 1),
('16', '2020-06-01', '3356789587', 1),
('15', '2020-06-01', '3356789587', 1),
('17', '2020-06-01', '3356789587', 1),
('18', '2020-06-01', '3356897421', 2),
('19', '2020-06-01', '3356897421', 2),
('20', '2020-06-01', '3356897421', 2),
('21', '2020-06-01', '3384567156', 3),
('22', '2020-06-01', '3384567156', 3),
('23', '2020-06-01', '3040404040', 2),
('24', '2020-06-01', '3041414141', 2),
('25', '2020-06-01', '3041414141', 2),
('26', '2020-06-01', '3040404040', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `bonos`
--
ALTER TABLE `bonos`
  ADD PRIMARY KEY (`id_bono`);

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`telefono`);

--
-- Indices de la tabla `empleados`
--
ALTER TABLE `empleados`
  ADD PRIMARY KEY (`id_empleado`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`folio`) USING BTREE;

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `bonos`
--
ALTER TABLE `bonos`
  MODIFY `id_bono` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1074;
--
-- AUTO_INCREMENT de la tabla `empleados`
--
ALTER TABLE `empleados`
  MODIFY `id_empleado` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
