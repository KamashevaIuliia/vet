-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Май 06 2020 г., 17:21
-- Версия сервера: 10.4.11-MariaDB
-- Версия PHP: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `hockey`
--

-- --------------------------------------------------------

--
-- Структура таблицы `gamerspol`
--

CREATE TABLE `gamerspol` (
  `ID` int(11) NOT NULL,
  `gamer` varchar(30) NOT NULL,
  `nationality` varchar(15) NOT NULL,
  `pos` varchar(1) NOT NULL,
  `gp` int(4) NOT NULL,
  `g` int(3) NOT NULL,
  `a` int(3) NOT NULL,
  `p` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `gamerspol`
--

INSERT INTO `gamerspol` (`ID`, `gamer`, `nationality`, `pos`, `gp`, `g`, `a`, `p`) VALUES
(1, 'Сергей Фёдоров', 'Россия', 'С', 1248, 483, 696, 1179),
(2, 'Александр Могильный', 'Россия', 'R', 990, 473, 559, 1032),
(3, 'Алексей Ковалёв', 'Россия', 'R', 1316, 430, 599, 1029),
(4, 'Александр Овечкин', 'Россия', 'L', 760, 475, 420, 895),
(5, 'Павел Дацюк', 'Россия', 'C', 887, 298, 571, 869),
(6, 'Вячеслав Козлов', 'Россия', 'L', 1182, 356, 497, 853),
(7, 'Алексей Горбин', 'Россия', 'R', 888, 345, 486, 856);

-- --------------------------------------------------------

--
-- Структура таблицы `gamersvrat`
--

CREATE TABLE `gamersvrat` (
  `ID` int(11) NOT NULL,
  `gamer` varchar(30) NOT NULL,
  `nationality` varchar(15) NOT NULL,
  `gp` int(3) NOT NULL,
  `gs` int(11) NOT NULL,
  `w` int(11) NOT NULL,
  `l` int(11) NOT NULL,
  `t` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `gamersvrat`
--

INSERT INTO `gamersvrat` (`ID`, `gamer`, `nationality`, `gp`, `gs`, `w`, `l`, `t`) VALUES
(1, 'Евгений Набоков', 'Россия', 697, 681, 353, 227, 29),
(2, 'Николай Хабибулин', 'Россия', 799, 632, 333, 334, 58),
(3, 'Илья Брызгалов', 'Россия', 465, 445, 221, 162, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `statistic`
--

CREATE TABLE `statistic` (
  `ID` int(11) NOT NULL,
  `gamervrat` int(11) NOT NULL,
  `gamerpol` int(11) NOT NULL,
  `timetabe` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `statistic`
--

INSERT INTO `statistic` (`ID`, `gamervrat`, `gamerpol`, `timetabe`) VALUES
(1, 3, 7, 13);

-- --------------------------------------------------------

--
-- Структура таблицы `status`
--

CREATE TABLE `status` (
  `ID` int(11) NOT NULL,
  `status` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `status`
--

INSERT INTO `status` (`ID`, `status`) VALUES
(0, 'Пользователь'),
(1, 'Менеджер');

-- --------------------------------------------------------

--
-- Структура таблицы `timetable`
--

CREATE TABLE `timetable` (
  `ID` int(11) NOT NULL,
  `date` date NOT NULL,
  `time` time(6) NOT NULL,
  `first_club` varchar(20) NOT NULL,
  `second_club` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `timetable`
--

INSERT INTO `timetable` (`ID`, `date`, `time`, `first_club`, `second_club`) VALUES
(1, '2020-04-15', '17:00:00.000000', 'СКА', 'Витязь'),
(2, '2020-04-24', '18:30:00.000000', 'Витязь', 'СКА'),
(3, '2020-04-15', '17:30:00.000000', 'Динамо МСК', 'Авангард'),
(4, '2020-04-20', '17:30:00.000000', 'Авангард', 'Динамо МСК'),
(5, '2020-04-21', '22:00:00.000000', 'Локомотив', 'Авангард'),
(6, '2020-04-15', '22:00:00.000000', 'Авангард', 'Локомотив'),
(7, '2020-04-22', '18:00:00.000000', 'Локомотив', 'СКА'),
(8, '2020-04-13', '18:00:00.000000', 'Локомотив', 'СКА'),
(9, '2020-04-16', '17:00:00.000000', 'СКА', 'Авангард'),
(10, '2020-04-12', '18:00:00.000000', 'Витязь', 'Авангард'),
(11, '2020-04-17', '17:00:00.000000', 'Авангард', 'Витязь'),
(12, '2020-04-11', '17:00:00.000000', 'СКА', 'Локомотив'),
(13, '2020-04-23', '17:00:00.000000', 'Локомотив', 'Авангард');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `login` varchar(15) NOT NULL,
  `password` varchar(10) NOT NULL,
  `name` varchar(15) NOT NULL,
  `type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`ID`, `login`, `password`, `name`, `type`) VALUES
(1, 'Yulechka', 'Bat!2263', 'Юлия', 1),
(2, 'Andrew228', 'Arr!10', 'Андрей', 0);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `gamerspol`
--
ALTER TABLE `gamerspol`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `gamersvrat`
--
ALTER TABLE `gamersvrat`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `statistic`
--
ALTER TABLE `statistic`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `gamervrat` (`gamervrat`,`gamerpol`,`timetabe`),
  ADD KEY `gamerpol` (`gamerpol`),
  ADD KEY `timetabe` (`timetabe`);

--
-- Индексы таблицы `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `timetable`
--
ALTER TABLE `timetable`
  ADD PRIMARY KEY (`ID`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `type` (`type`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `gamerspol`
--
ALTER TABLE `gamerspol`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `gamersvrat`
--
ALTER TABLE `gamersvrat`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `status`
--
ALTER TABLE `status`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `timetable`
--
ALTER TABLE `timetable`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `statistic`
--
ALTER TABLE `statistic`
  ADD CONSTRAINT `statistic_ibfk_1` FOREIGN KEY (`gamerpol`) REFERENCES `gamerspol` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `statistic_ibfk_2` FOREIGN KEY (`timetabe`) REFERENCES `timetable` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `statistic_ibfk_3` FOREIGN KEY (`gamervrat`) REFERENCES `gamersvrat` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`type`) REFERENCES `status` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
