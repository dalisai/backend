-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 07, 2018 at 09:39 AM
-- Server version: 10.1.26-MariaDB
-- PHP Version: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sai`
--
CREATE DATABASE IF NOT EXISTS `sai` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `sai`;

-- --------------------------------------------------------


--
-- Table structure for table `Category`
--
create table category (
 ID int(11) not null auto_increment primary key,
 Description varchar(500) not null
);


--
-- Table structure for table `SubCategory`
--
create table  subCategory (
 ID int(11) not null auto_increment primary key,
 Description varchar(500) not null
);


--
-- Table structure for table `Supplier`
--
create table supplier (
 ID int(11) not null auto_increment primary key,
 Description varchar(500) not null
);

--
-- Table structure for table `attendance`
--

CREATE TABLE `attendance` (
  `id` int(11) NOT NULL,
  `date` date DEFAULT NULL,
  `timein` time DEFAULT NULL,
  `timeout` time DEFAULT NULL,
  `employee_id` int(11) DEFAULT NULL,
  `employee_name` varchar(50) DEFAULT NULL,
  `shiftin` time DEFAULT NULL,
  `shiftout` time DEFAULT NULL,
  `posted` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `backoffice`
--

CREATE TABLE `backoffice` (
  `id` int(11) NOT NULL,
  `date` date DEFAULT NULL,
  `oldgt` float DEFAULT NULL,
  `newgt` float DEFAULT NULL,
  `dailysales` float DEFAULT NULL,
  `oldgt1` float DEFAULT NULL,
  `newgt1` float DEFAULT NULL,
  `dailysales1` float DEFAULT NULL,
  `discount` int(11) DEFAULT NULL,
  `discount_qty` int(11) DEFAULT NULL,
  `addon` int(11) DEFAULT NULL,
  `addon_qty` int(11) DEFAULT NULL,
  `localtax` float DEFAULT NULL,
  `refund` float DEFAULT NULL,
  `refund_qty` int(11) DEFAULT NULL,
  `vat` int(11) DEFAULT NULL,
  `begin_inv` int(11) DEFAULT NULL,
  `end_inv` int(11) DEFAULT NULL,
  `transaction_count` int(11) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `sales_tax` int(11) DEFAULT NULL,
  `no_tax_sales` int(11) DEFAULT NULL,
  `cash_amount` float DEFAULT NULL,
  `cart_amount` float DEFAULT NULL,
  `pax_qty` int(11) DEFAULT NULL,
  `dump` tinyint(4) DEFAULT NULL,
  `service_charge` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `config`
--

CREATE TABLE `config` (
  `id` int(11) NOT NULL,
  `sys_prg` int(11) DEFAULT NULL,
  `sys_dbf` varchar(45) DEFAULT NULL,
  `sys_back` int(11) DEFAULT NULL,
  `plu_drv` varchar(45) DEFAULT NULL,
  `server_drive` varchar(45) DEFAULT NULL,
  `company` varchar(45) DEFAULT NULL,
  `owned1` varchar(45) DEFAULT NULL,
  `owned2` varchar(45) DEFAULT NULL,
  `address1` varchar(45) DEFAULT NULL,
  `address2` varchar(45) DEFAULT NULL,
  `tin` varchar(45) DEFAULT NULL,
  `printer_serial_no` varchar(45) DEFAULT NULL,
  `machine` int(11) DEFAULT NULL,
  `divisible` int(11) DEFAULT NULL,
  `printer_port` varchar(45) DEFAULT NULL,
  `drawer_com` varchar(45) DEFAULT NULL,
  `disp_com` varchar(45) DEFAULT NULL,
  `training_mode` tinyint(4) DEFAULT NULL,
  `drawer_lpt` tinyint(4) DEFAULT NULL,
  `cdisplay` tinyint(4) DEFAULT NULL,
  `receipt` varchar(45) DEFAULT NULL,
  `rem1` varchar(45) DEFAULT NULL,
  `rem2` varchar(45) DEFAULT NULL,
  `rem3` varchar(45) DEFAULT NULL,
  `rem4` varchar(45) DEFAULT NULL,
  `rem5` varchar(45) DEFAULT NULL,
  `marketing` varchar(45) DEFAULT NULL,
  `display1` varchar(45) DEFAULT NULL,
  `display2` varchar(45) DEFAULT NULL,
  `setup_type` varchar(45) DEFAULT NULL,
  `with_remote_prn` tinyint(4) DEFAULT NULL,
  `with_host_prn` tinyint(4) DEFAULT NULL,
  `multi_bar_prn` tinyint(4) DEFAULT NULL,
  `order_type_entry` tinyint(4) DEFAULT NULL,
  `password` tinyint(4) DEFAULT NULL,
  `with_inv` tinyint(4) DEFAULT NULL,
  `receipt_sum` tinyint(4) DEFAULT NULL,
  `dollar` float DEFAULT NULL,
  `xmode` int(11) DEFAULT NULL,
  `zmode` int(11) DEFAULT NULL,
  `last_inv_no` int(11) DEFAULT NULL,
  `batch` int(11) DEFAULT NULL,
  `last_batch` date DEFAULT NULL,
  `auto_cut` tinyint(4) DEFAULT NULL,
  `with_admin` tinyint(4) DEFAULT NULL,
  `admin` varchar(45) DEFAULT NULL,
  `admin_path` varchar(45) DEFAULT NULL,
  `branch` varchar(45) DEFAULT NULL,
  `tenant` varchar(45) DEFAULT NULL,
  `class_code` varchar(45) DEFAULT NULL,
  `trade_code` varchar(45) DEFAULT NULL,
  `outlet_no` varchar(45) DEFAULT NULL,
  `term_no` int(11) DEFAULT NULL,
  `price_type` int(11) DEFAULT NULL,
  `file` varchar(45) DEFAULT NULL,
  `international` tinyint(4) DEFAULT NULL,
  `picture` varchar(45) DEFAULT NULL,
  `with_sc` tinyint(4) DEFAULT NULL,
  `local_tax` int(11) DEFAULT NULL,
  `name_tag` varchar(45) DEFAULT NULL,
  `touch_screen` tinyint(4) DEFAULT NULL,
  `taxable` float DEFAULT NULL,
  `with_clerk` tinyint(4) DEFAULT NULL,
  `bar_pop` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `id` int(11) NOT NULL,
  `customer_name` varchar(45) DEFAULT NULL,
  `credit_limit` int(11) DEFAULT NULL,
  `discount` int(11) DEFAULT NULL,
  `price_type` int(11) DEFAULT NULL,
  `birthday` date DEFAULT NULL,
  `address1` varchar(45) DEFAULT NULL,
  `address2` varchar(45) DEFAULT NULL,
  `tel_no` varchar(45) DEFAULT NULL,
  `fax_no` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `company` varchar(45) DEFAULT NULL,
  `points` int(11) DEFAULT NULL,
  `last_visit` datetime DEFAULT NULL,
  `photo` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `delivery`
--

CREATE TABLE `delivery` (
  `id` int(11) NOT NULL,
  `customer_name` varchar(45) DEFAULT NULL,
  `address1` varchar(45) DEFAULT NULL,
  `address2` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `address_remarks` varchar(45) DEFAULT NULL,
  `delivery_remarks` varchar(45) DEFAULT NULL,
  `first_order_date` date DEFAULT NULL,
  `last_order_date` date DEFAULT NULL,
  `last_invoice` int(11) DEFAULT NULL,
  `phone_no` varchar(45) DEFAULT NULL,
  `birthday` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `deposit`
--

CREATE TABLE `deposit` (
  `id` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `total` tinyint(4) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `cashier` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dept`
--

CREATE TABLE `dept` (
  `id` int(11) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `backcolor` varchar(45) DEFAULT NULL,
  `remote_prn` varchar(45) DEFAULT NULL,
  `group` varchar(45) DEFAULT NULL,
  `open_dept` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `discount_type`
--

CREATE TABLE `discount_type` (
  `id` int(11) NOT NULL,
  `discount_type` varchar(45) DEFAULT NULL,
  `percent` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `entertainer`
--

CREATE TABLE `entertainer` (
  `id` int(11) NOT NULL,
  `entertainer` int(11) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `real_name` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `attendance` tinyint(4) DEFAULT NULL,
  `groupname` varchar(45) DEFAULT NULL,
  `budget` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `eod`
--

CREATE TABLE `eod` (
  `id` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `posted` tinyint(4) DEFAULT NULL,
  `sales` decimal(10,0) DEFAULT NULL,
  `sales_qty` decimal(10,0) DEFAULT NULL,
  `addon` decimal(10,0) DEFAULT NULL,
  `addon_qty` decimal(10,0) DEFAULT NULL,
  `discount` decimal(10,0) DEFAULT NULL,
  `discount_qty` decimal(10,0) DEFAULT NULL,
  `local_tax` decimal(10,0) DEFAULT NULL,
  `cash` decimal(10,0) DEFAULT NULL,
  `cash_qty` decimal(10,0) DEFAULT NULL,
  `card` decimal(10,0) DEFAULT NULL,
  `card_qty` decimal(10,0) DEFAULT NULL,
  `gift` decimal(10,0) DEFAULT NULL,
  `gift_qty` decimal(10,0) DEFAULT NULL,
  `check` decimal(10,0) DEFAULT NULL,
  `check_qty` decimal(10,0) DEFAULT NULL,
  `charge` decimal(10,0) DEFAULT NULL,
  `charge_qty` decimal(10,0) DEFAULT NULL,
  `misc` decimal(10,0) DEFAULT NULL,
  `misc_qty` decimal(10,0) DEFAULT NULL,
  `refund` decimal(10,0) DEFAULT NULL,
  `refund_qty` decimal(10,0) DEFAULT NULL,
  `pax_qty` int(11) DEFAULT NULL,
  `dine_in` int(11) DEFAULT NULL,
  `take_out` int(11) DEFAULT NULL,
  `delivery` int(11) DEFAULT NULL,
  `no_tax_sales` int(11) DEFAULT NULL,
  `no_tax_sales_qty` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `item_details`
--

CREATE TABLE `item_details` (
  `id` int(11) NOT NULL,
  `itemcode` varchar(45) NOT NULL,
  `stockno` varchar(45) DEFAULT NULL,
  `unitid` int(11) DEFAULT NULL,
  `packing` int(11) DEFAULT NULL,
  `ratio` int(11) DEFAULT NULL,
  `stock` int(11) DEFAULT NULL,
  `max_inventory` int(11) DEFAULT NULL,
  `min_inventory` int(11) DEFAULT NULL,
  `beg_quantity` int(11) DEFAULT NULL,
  `postdate` date DEFAULT NULL,
  `listcost` int(11) DEFAULT NULL,
  `netcost` decimal(20,2) DEFAULT NULL,
  `markup1` float DEFAULT NULL,
  `price1` decimal(20,2) DEFAULT NULL,
  `markup2` float DEFAULT NULL,
  `price2` decimal(20,2) DEFAULT NULL,
  `markup3` float DEFAULT NULL,
  `price3` decimal(20,2) DEFAULT NULL,
  `markup4` float DEFAULT NULL,
  `price4` decimal(20,2) DEFAULT NULL,
  `lastupdate` datetime DEFAULT NULL,
  `discountp` int(11) DEFAULT NULL,
  `discounta` int(11) DEFAULT NULL,
  `sdate` date DEFAULT NULL,
  `stime` date DEFAULT NULL,
  `edate` date DEFAULT NULL,
  `etime` date DEFAULT NULL,
  `lastdateso` date DEFAULT NULL,
  `notactive` int(11) DEFAULT NULL,
  `xitem` int(11) DEFAULT NULL,
  `opendept` int(11) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `items`
--
CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `itemcode` varchar(45) NOT NULL,
  `longdescription` varchar(45) DEFAULT NULL,
  `shortdescription` varchar(20) NOT NULL,
  `departmentid` bigint(20) DEFAULT NULL,
  `categoryid` bigint(20) DEFAULT NULL,
  `subcategoryid` bigint(20) DEFAULT NULL,
  `supplierid` bigint(20) DEFAULT NULL,
  `largepacking` varchar(50) DEFAULT NULL,
  `withserial` int(11) DEFAULT NULL,
  `withexpiry` int(11) DEFAULT NULL,
  `vatable` tinyint(4) DEFAULT NULL,
  `OpenDept` tinyint(4) DEFAULT NULL,
  `isOpenDept` tinyint(4) DEFAULT NULL,
  `isOpenPrice` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `zmode`
--

CREATE TABLE `zmode` (
  `id` int(11) NOT NULL,
  `sales` decimal(10,0) DEFAULT NULL,
  `salesqty` decimal(10,0) DEFAULT NULL,
  `surcharge` decimal(10,0) DEFAULT NULL,
  `surcharge_qty` decimal(10,0) DEFAULT NULL,
  `discount` decimal(10,0) DEFAULT NULL,
  `discount_qty` decimal(10,0) DEFAULT NULL,
  `local_tax` decimal(10,0) DEFAULT NULL,
  `cash` decimal(10,0) DEFAULT NULL,
  `cash_qty` decimal(10,0) DEFAULT NULL,
  `card` decimal(10,0) DEFAULT NULL,
  `card_qty` decimal(10,0) DEFAULT NULL,
  `gift` decimal(10,0) DEFAULT NULL,
  `gift_qty` decimal(10,0) DEFAULT NULL,
  `check` decimal(10,0) DEFAULT NULL,
  `check_qty` decimal(10,0) DEFAULT NULL,
  `charge` decimal(10,0) DEFAULT NULL,
  `charge_qty` decimal(10,0) DEFAULT NULL,
  `misc` decimal(10,0) DEFAULT NULL,
  `misc_qty` decimal(10,0) DEFAULT NULL,
  `refund` decimal(10,0) DEFAULT NULL,
  `refund_qty` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `order1`
--

CREATE TABLE `order1` (
  `id` int(11) NOT NULL,
  `order_no` int(11) DEFAULT NULL,
  `seq_no` int(11) DEFAULT NULL,
  `machine` int(11) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `discount` int(11) DEFAULT NULL,
  `discount_percentage` int(11) DEFAULT NULL,
  `discount_type` varchar(45) DEFAULT NULL,
  `discount_ref` varchar(45) DEFAULT NULL,
  `supervisor` varchar(45) DEFAULT NULL,
  `clerk` varchar(45) DEFAULT NULL,
  `customer` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `order2`
--

CREATE TABLE `order2` (
  `id` int(11) NOT NULL,
  `order_no` int(11) DEFAULT NULL,
  `clerk` varchar(45) DEFAULT NULL,
  `itemcode` varchar(45) DEFAULT NULL,
  `othercode` varchar(45) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `sell` decimal(10,0) DEFAULT NULL,
  `orig_sell_price` decimal(10,0) DEFAULT NULL,
  `cost` decimal(10,0) DEFAULT NULL,
  `item_discount_p` varchar(45) DEFAULT NULL,
  `item_discount` decimal(10,0) DEFAULT NULL,
  `discount_type` varchar(45) DEFAULT NULL,
  `discount_ref` varchar(45) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `supervisor` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `order_remarks`
--

CREATE TABLE `order_remarks` (
  `id` int(11) NOT NULL,
  `order_remarks` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pay_type`
--

CREATE TABLE `pay_type` (
  `id` int(11) NOT NULL,
  `payment_code` int(11) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `type` int(11) DEFAULT NULL,
  `backcolor` varchar(45) DEFAULT NULL,
  `discount` decimal(10,0) DEFAULT NULL,
  `rate` int(11) DEFAULT NULL,
  `picture` blob,
  `picture_path` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `payment_entry`
--

CREATE TABLE `payment_entry` (
  `id` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `payment` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `reference1` varchar(45) DEFAULT NULL,
  `reference2` varchar(45) DEFAULT NULL,
  `reference3` varchar(45) DEFAULT NULL,
  `reference4` varchar(45) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `inv_no` int(11) DEFAULT NULL,
  `paid_amount` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `payment_entry_temp`
--

CREATE TABLE `payment_entry_temp` (
  `id` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `payment` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `reference1` varchar(45) DEFAULT NULL,
  `reference2` varchar(45) DEFAULT NULL,
  `reference3` varchar(45) DEFAULT NULL,
  `reference4` varchar(45) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `inv_no` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `receipt_temp`
--

CREATE TABLE `receipt_temp` (
  `id` int(11) NOT NULL,
  `qty` int(11) DEFAULT NULL,
  `sdesc` varchar(45) DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `discount_percent` decimal(10,0) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `group` varchar(45) DEFAULT NULL,
  `entertainer` varchar(45) DEFAULT NULL,
  `time_in` datetime DEFAULT NULL,
  `time_out` datetime DEFAULT NULL,
  `not_in_mc` tinyint(4) DEFAULT NULL,
  `duration` varchar(45) DEFAULT NULL,
  `groupcheck` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales1`
--

CREATE TABLE `sales1` (
  `id` int(11) NOT NULL,
  `inv_no` int(11) DEFAULT NULL,
  `seq_no` int(11) DEFAULT NULL,
  `machine` int(11) DEFAULT NULL,
  `cashier` varchar(45) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `total` tinyint(4) DEFAULT NULL,
  `posted` tinyint(4) DEFAULT NULL,
  `sales` varchar(45) DEFAULT NULL,
  `total_amount` decimal(10,0) DEFAULT NULL,
  `refund_amount` decimal(10,0) DEFAULT NULL,
  `refund_qty` int(11) DEFAULT NULL,
  `discount` decimal(10,0) DEFAULT NULL,
  `discount_p` decimal(10,0) DEFAULT NULL,
  `discount_qty` int(11) DEFAULT NULL,
  `addon` decimal(10,0) DEFAULT NULL,
  `addon_p` decimal(10,0) DEFAULT NULL,
  `addon_qty` int(11) DEFAULT NULL,
  `service_charge_p` varchar(45) DEFAULT NULL,
  `service_charge` int(11) DEFAULT NULL,
  `service_charge_qty` int(11) DEFAULT NULL,
  `local_tax` int(11) DEFAULT NULL,
  `payment_code` int(11) DEFAULT NULL,
  `card_amount` decimal(10,0) DEFAULT NULL,
  `card_qty` int(11) DEFAULT NULL,
  `gift_amount` decimal(10,0) DEFAULT NULL,
  `gift_qty` int(11) DEFAULT NULL,
  `check_amount` decimal(10,0) DEFAULT NULL,
  `check_qty` int(11) DEFAULT NULL,
  `charge_amount` decimal(10,0) DEFAULT NULL,
  `charge_qty` int(11) DEFAULT NULL,
  `cash_amount` decimal(10,0) DEFAULT NULL,
  `cash_qty` int(11) DEFAULT NULL,
  `misc` decimal(10,0) DEFAULT NULL,
  `paid` tinyint(4) DEFAULT NULL,
  `table_no` varchar(45) DEFAULT NULL,
  `order_type` varchar(45) DEFAULT NULL,
  `guest_qty` int(11) DEFAULT NULL,
  `discount_type` varchar(45) DEFAULT NULL,
  `sc_qty` int(11) DEFAULT NULL,
  `discount_reference` varchar(45) DEFAULT NULL,
  `supervisor` varchar(45) DEFAULT NULL,
  `clerk` varchar(45) DEFAULT NULL,
  `customer` varchar(45) DEFAULT NULL,
  `grm` varchar(45) DEFAULT NULL,
  `mc` int(11) DEFAULT NULL,
  `open` tinyint(4) DEFAULT NULL,
  `last_user` varchar(45) DEFAULT NULL,
  `last_machine` tinyint(4) DEFAULT NULL,
  `archived` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales2`
--

CREATE TABLE `sales2` (
  `id` int(11) NOT NULL,
  `inv_no` int(11) DEFAULT NULL,
  `seq_no` int(11) DEFAULT NULL,
  `os_number` varchar(45) DEFAULT NULL,
  `clerk` varchar(45) DEFAULT NULL,
  `grm` varchar(45) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `itemcode` varchar(45) DEFAULT NULL,
  `othercode` varchar(45) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `sell` decimal(10,0) DEFAULT NULL,
  `orig_sell_price` decimal(10,0) DEFAULT NULL,
  `cost` decimal(10,0) DEFAULT NULL,
  `item_discount_p` decimal(10,0) DEFAULT NULL,
  `item_discount` decimal(10,0) DEFAULT NULL,
  `discount_type` varchar(45) DEFAULT NULL,
  `discount_ref` varchar(45) DEFAULT NULL,
  `item_discount_qty` int(11) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `sales` varchar(45) DEFAULT NULL,
  `supervisor` varchar(45) DEFAULT NULL,
  `entertainer` varchar(45) DEFAULT NULL,
  `time_in` datetime DEFAULT NULL,
  `realtime_in` datetime DEFAULT NULL,
  `time_out` datetime DEFAULT NULL,
  `realtime_out` datetime DEFAULT NULL,
  `duration` varchar(45) DEFAULT NULL,
  `xitem` tinyint(4) DEFAULT NULL,
  `machine` int(11) DEFAULT NULL,
  `ordering_terminal` int(11) DEFAULT NULL,
  `post_2_inv` tinyint(4) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `group_check` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `shift_sched`
--

CREATE TABLE `shift_sched` (
  `id` int(11) NOT NULL,
  `employee_id` int(11) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `day_off` tinyint(4) DEFAULT NULL,
  `shift_in1` datetime DEFAULT NULL,
  `shift_out1` datetime DEFAULT NULL,
  `shift_in2` datetime DEFAULT NULL,
  `shift_out2` datetime DEFAULT NULL,
  `shift_in3` datetime DEFAULT NULL,
  `shift_out3` datetime DEFAULT NULL,
  `shift_in4` datetime DEFAULT NULL,
  `shift_out4` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `suspend`
--

CREATE TABLE `suspend` (
  `id` int(11) NOT NULL,
  `qty` int(11) DEFAULT NULL,
  `description` text,
  `price` decimal(10,0) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `discount_p` decimal(10,0) DEFAULT NULL,
  `cost` decimal(10,0) DEFAULT NULL,
  `itemcode` text,
  `remarks` text,
  `discount_type` varchar(45) DEFAULT NULL,
  `seq_no` int(11) DEFAULT NULL,
  `clerk` varchar(45) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `supervisor` varchar(45) DEFAULT NULL,
  `xitem` tinyint(4) DEFAULT NULL,
  `orig_item_desc` varchar(45) DEFAULT NULL,
  `long_desc` varchar(45) DEFAULT NULL,
  `other_code` varchar(45) DEFAULT NULL,
  `with_serial` tinyint(4) DEFAULT NULL,
  `customer` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `time_in_out`
--

CREATE TABLE `time_in_out` (
  `id` int(11) NOT NULL,
  `inv_no` int(11) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `time_in` datetime DEFAULT NULL,
  `time_out` datetime DEFAULT NULL,
  `itemcode` varchar(45) DEFAULT NULL,
  `discount_p` int(11) DEFAULT NULL,
  `discount` int(11) DEFAULT NULL,
  `addon_p` int(11) DEFAULT NULL,
  `addon` int(11) DEFAULT NULL,
  `no_of_hour` int(11) DEFAULT NULL,
  `no_of_min` int(11) DEFAULT NULL,
  `total_amount` int(11) DEFAULT NULL,
  `entertainer_name` varchar(45) DEFAULT NULL,
  `clerk` varchar(45) DEFAULT NULL,
  `supervisor` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user_access`
--

CREATE TABLE `user_access` (
  `id` int(11) NOT NULL,
  `user` int(11) DEFAULT NULL,
  `module` int(11) DEFAULT NULL,
  `can_add` tinyint(4) DEFAULT NULL,
  `can_edit` tinyint(4) DEFAULT NULL,
  `can_erase` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL COMMENT 'User code',
  `name` varchar(45) DEFAULT NULL COMMENT 'User''s name',
  `password` varchar(45) DEFAULT NULL COMMENT 'Password',
  `description` varchar(45) DEFAULT NULL COMMENT 'User Description',
  `type` varchar(45) DEFAULT NULL COMMENT '1=Cashier;2= Waiter; 3=GRM; 4=Server Supervisor; 5=cashier supervisor ; 9=ADMIN; 8=OIC;7=Flr.Manager'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `voided_items`
--

CREATE TABLE `voided_items` (
  `id` int(11) NOT NULL,
  `seq_no` int(11) DEFAULT NULL,
  `os_number` varchar(45) DEFAULT NULL,
  `cashier` varchar(45) DEFAULT NULL,
  `clerk` varchar(45) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `table_no` varchar(45) DEFAULT NULL,
  `supervisor` varchar(45) DEFAULT NULL,
  `order_type` varchar(45) DEFAULT NULL,
  `itemcode` varchar(45) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `reason` varchar(45) DEFAULT NULL,
  `grm` varchar(45) DEFAULT NULL,
  `archived` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `withdraw`
--

CREATE TABLE `withdraw` (
  `id` int(11) NOT NULL,
  `date` datetime DEFAULT NULL,
  `total` tinyint(4) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  `cashier` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `backoffice`
--
ALTER TABLE `backoffice`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `config`
--
ALTER TABLE `config`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `delivery`
--
ALTER TABLE `delivery`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `deposit`
--
ALTER TABLE `deposit`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dept`
--
ALTER TABLE `dept`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `discount_type`
--
ALTER TABLE `discount_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `entertainer`
--
ALTER TABLE `entertainer`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `eod`
--
ALTER TABLE `eod`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `item_details`
--
ALTER TABLE `item_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ItemCode_UNIQUE` (`itemcode`);

--
-- Indexes for table `zmode`
--
ALTER TABLE `zmode`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `order1`
--
ALTER TABLE `order1`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `order2`
--
ALTER TABLE `order2`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `order_remarks`
--
ALTER TABLE `order_remarks`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `pay_type`
--
ALTER TABLE `pay_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payment_entry`
--
ALTER TABLE `payment_entry`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payment_entry_temp`
--
ALTER TABLE `payment_entry_temp`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `receipt_temp`
--
ALTER TABLE `receipt_temp`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sales1`
--
ALTER TABLE `sales1`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sales2`
--
ALTER TABLE `sales2`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shift_sched`
--
ALTER TABLE `shift_sched`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `suspend`
--
ALTER TABLE `suspend`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `time_in_out`
--
ALTER TABLE `time_in_out`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user_access`
--
ALTER TABLE `user_access`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `voided_items`
--
ALTER TABLE `voided_items`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `withdraw`
--
ALTER TABLE `withdraw`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `attendance`
--
ALTER TABLE `attendance`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `backoffice`
--
ALTER TABLE `backoffice`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `config`
--
ALTER TABLE `config`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `delivery`
--
ALTER TABLE `delivery`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `deposit`
--
ALTER TABLE `deposit`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `dept`
--
ALTER TABLE `dept`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `discount_type`
--
ALTER TABLE `discount_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `entertainer`
--
ALTER TABLE `entertainer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `eod`
--
ALTER TABLE `eod`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `item_details`
--
ALTER TABLE `item_details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `zmode`
--
ALTER TABLE `zmode`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `order1`
--
ALTER TABLE `order1`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `order2`
--
ALTER TABLE `order2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `order_remarks`
--
ALTER TABLE `order_remarks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `pay_type`
--
ALTER TABLE `pay_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `payment_entry`
--
ALTER TABLE `payment_entry`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `payment_entry_temp`
--
ALTER TABLE `payment_entry_temp`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `receipt_temp`
--
ALTER TABLE `receipt_temp`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `sales1`
--
ALTER TABLE `sales1`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `sales2`
--
ALTER TABLE `sales2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `shift_sched`
--
ALTER TABLE `shift_sched`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `suspend`
--
ALTER TABLE `suspend`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `time_in_out`
--
ALTER TABLE `time_in_out`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `user_access`
--
ALTER TABLE `user_access`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'User code';
--
-- AUTO_INCREMENT for table `voided_items`
--
ALTER TABLE `voided_items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `withdraw`
--
ALTER TABLE `withdraw`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

CREATE TABLE `branch` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
