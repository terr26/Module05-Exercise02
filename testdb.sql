-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 30, 2024 at 02:49 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `testdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblpersonal`
--

CREATE TABLE `tblpersonal` (
  `ID` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Gender` varchar(10) DEFAULT NULL,
  `ContactNo` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblpersonal`
--

INSERT INTO `tblpersonal` (`ID`, `Name`, `Gender`, `ContactNo`) VALUES
(1, 'John Doe', 'Male', '09999999999'),
(2, 'John Doe', 'Female', '09191919919'),
(3, 'asda', 'asda', 'asdasd'),
(4, 'dasda', 'sda', 'asdasd'),
(5, 'anne', 'adasd', 'asdadad');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblpersonal`
--
ALTER TABLE `tblpersonal`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblpersonal`
--
ALTER TABLE `tblpersonal`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
