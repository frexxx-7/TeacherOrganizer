-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 10 2024 г., 09:37
-- Версия сервера: 10.3.22-MariaDB
-- Версия PHP: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `teacherorganizer`
--

-- --------------------------------------------------------

--
-- Структура таблицы `academic_subject`
--

CREATE TABLE `academic_subject` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `academic_subject`
--

INSERT INTO `academic_subject` (`id`, `name`) VALUES
(2, 'dsf'),
(4, 'sdf');

-- --------------------------------------------------------

--
-- Структура таблицы `burder`
--

CREATE TABLE `burder` (
  `id` int(11) NOT NULL,
  `idGroup` int(11) DEFAULT NULL,
  `idTeacher` int(11) DEFAULT NULL,
  `count_hours` int(11) DEFAULT NULL,
  `idAcademicSubject` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `burder`
--

INSERT INTO `burder` (`id`, `idGroup`, `idTeacher`, `count_hours`, `idAcademicSubject`) VALUES
(1, 2, 1, 56, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `education_teacher`
--

CREATE TABLE `education_teacher` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `education_teacher`
--

INSERT INTO `education_teacher` (`id`, `name`) VALUES
(2, 'zxc'),
(3, 'sd');

-- --------------------------------------------------------

--
-- Структура таблицы `events`
--

CREATE TABLE `events` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `events`
--

INSERT INTO `events` (`id`, `name`) VALUES
(2, 'счмчс'),
(3, 'ьпроппро');

-- --------------------------------------------------------

--
-- Структура таблицы `groups`
--

CREATE TABLE `groups` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `receipt_date` date DEFAULT NULL,
  `idSpeciality` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `groups`
--

INSERT INTO `groups` (`id`, `name`, `receipt_date`, `idSpeciality`) VALUES
(2, 'sdf', '2024-01-25', 2),
(4, 'sccxv', '2024-01-08', 2),
(5, 'cxvbxc', '2024-01-18', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `planning`
--

CREATE TABLE `planning` (
  `id` int(11) NOT NULL,
  `idEvent` int(11) DEFAULT NULL,
  `plan_execution_date` date DEFAULT NULL,
  `actual_execution_date` date DEFAULT NULL,
  `idTeacher` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `planning`
--

INSERT INTO `planning` (`id`, `idEvent`, `plan_execution_date`, `actual_execution_date`, `idTeacher`) VALUES
(1, 3, '2024-01-11', '2024-01-27', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `speciality`
--

CREATE TABLE `speciality` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `speciality`
--

INSERT INTO `speciality` (`id`, `name`) VALUES
(2, 'asd'),
(3, 'xcv');

-- --------------------------------------------------------

--
-- Структура таблицы `tasks`
--

CREATE TABLE `tasks` (
  `id` int(11) NOT NULL,
  `title` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `description` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `endDate` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `isComplete` tinyint(1) DEFAULT NULL,
  `idTeacher` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `tasks`
--

INSERT INTO `tasks` (`id`, `title`, `description`, `endDate`, `isComplete`, `idTeacher`) VALUES
(2, '6 января', 'ываываыва', '2024-01-06', 0, NULL),
(3, 'январь 13', 'фвыыаыва', '2024-01-13', 1, NULL),
(4, '11 января', '27 января', '2024-01-27', 0, NULL),
(5, 'йцуйцуй', 'ывафывафывафывафывафывафывафывафывафывафываывафывафыва\r\nфывафыва\r\nфывафыва', '2024-01-19', 0, NULL),
(6, 'qwe qwe qwe qwe qwe', 'sdfsdfas dfasdf', '2024-01-19', 1, NULL),
(7, 'qweqwe', 'assdfasdfsdfadfs', '2024-01-23', 0, NULL),
(8, 'qwe', 'qweqwe', '2024-01-09', 0, NULL),
(10, 'qwe qw eqwe', 'qwe qwe qwe qwe', '2024-01-26', 0, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `teachers`
--

CREATE TABLE `teachers` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `patronymic` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `surname` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `home_number` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone_number` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `address` varchar(200) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `passport` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `id_education` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `teachers`
--

INSERT INTO `teachers` (`id`, `name`, `patronymic`, `surname`, `home_number`, `phone_number`, `address`, `passport`, `password`, `id_education`) VALUES
(1, 'qwe', 'qwe', 'qwe', 'qwes', 'qwes', 'qwe', 'qwe', 'qwe', 3);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `academic_subject`
--
ALTER TABLE `academic_subject`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `burder`
--
ALTER TABLE `burder`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idGroup` (`idGroup`),
  ADD KEY `idTeacher` (`idTeacher`),
  ADD KEY `idAcademicSubject` (`idAcademicSubject`);

--
-- Индексы таблицы `education_teacher`
--
ALTER TABLE `education_teacher`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idSpeciality` (`idSpeciality`);

--
-- Индексы таблицы `planning`
--
ALTER TABLE `planning`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idTeacher` (`idTeacher`),
  ADD KEY `idEvent` (`idEvent`);

--
-- Индексы таблицы `speciality`
--
ALTER TABLE `speciality`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idTeacher` (`idTeacher`);

--
-- Индексы таблицы `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_education` (`id_education`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `academic_subject`
--
ALTER TABLE `academic_subject`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `burder`
--
ALTER TABLE `burder`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `education_teacher`
--
ALTER TABLE `education_teacher`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `events`
--
ALTER TABLE `events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `groups`
--
ALTER TABLE `groups`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `planning`
--
ALTER TABLE `planning`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `speciality`
--
ALTER TABLE `speciality`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `tasks`
--
ALTER TABLE `tasks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `teachers`
--
ALTER TABLE `teachers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `burder`
--
ALTER TABLE `burder`
  ADD CONSTRAINT `burder_ibfk_1` FOREIGN KEY (`idGroup`) REFERENCES `groups` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `burder_ibfk_2` FOREIGN KEY (`idTeacher`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `burder_ibfk_3` FOREIGN KEY (`idAcademicSubject`) REFERENCES `academic_subject` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `groups`
--
ALTER TABLE `groups`
  ADD CONSTRAINT `groups_ibfk_1` FOREIGN KEY (`idSpeciality`) REFERENCES `speciality` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `planning`
--
ALTER TABLE `planning`
  ADD CONSTRAINT `planning_ibfk_1` FOREIGN KEY (`idTeacher`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `planning_ibfk_2` FOREIGN KEY (`idEvent`) REFERENCES `events` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD CONSTRAINT `tasks_ibfk_1` FOREIGN KEY (`idTeacher`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `teachers`
--
ALTER TABLE `teachers`
  ADD CONSTRAINT `teachers_ibfk_1` FOREIGN KEY (`id_education`) REFERENCES `education_teacher` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
