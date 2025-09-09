-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Мар 16 2025 г., 19:26
-- Версия сервера: 10.4.32-MariaDB
-- Версия PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `hockey_championship`
--

-- --------------------------------------------------------

--
-- Структура таблицы `arenas`
--

CREATE TABLE `arenas` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `city` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `arenas`
--

INSERT INTO `arenas` (`id`, `name`, `city`) VALUES
(1, 'Riga Arena', 'Riga'),
(2, 'Stockholm Ice Hall', 'Stockholm'),
(3, 'Helsinki Ice Dome', 'Helsinki');

-- --------------------------------------------------------

--
-- Структура таблицы `games`
--

CREATE TABLE `games` (
  `id` int(11) NOT NULL,
  `game_date` date DEFAULT NULL,
  `game_time` time DEFAULT NULL,
  `team1_id` int(11) DEFAULT NULL,
  `team2_id` int(11) DEFAULT NULL,
  `arena_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `games`
--

INSERT INTO `games` (`id`, `game_date`, `game_time`, `team1_id`, `team2_id`, `arena_id`) VALUES
(1, '2025-06-10', '18:00:00', 1, 2, 1),
(2, '2025-06-11', '19:30:00', 3, 4, 2),
(3, '2025-06-12', '20:00:00', 5, 6, 3),
(4, '2025-06-13', '17:45:00', 7, 8, 1),
(5, '2025-06-14', '19:00:00', 2, 3, 2),
(6, '2025-06-15', '18:30:00', 4, 5, 3),
(7, '2025-06-16', '21:00:00', 6, 7, 1),
(8, '2025-06-17', '16:00:00', 8, 1, 2),
(9, '2025-06-18', '20:15:00', 2, 5, 3),
(10, '2025-06-19', '19:45:00', 3, 6, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `teams`
--

CREATE TABLE `teams` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `country` varchar(100) DEFAULT NULL,
  `coach` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `teams`
--

INSERT INTO `teams` (`id`, `name`, `country`, `coach`) VALUES
(1, 'Riga Lions', 'Latvia', 'John Smith'),
(2, 'Stockholm Vikings', 'Sweden', 'Karl Johansson'),
(3, 'Helsinki Bears', 'Finland', 'Mikko Korhonen'),
(4, 'Oslo Icebreakers', 'Norway', 'Erik Hansen'),
(5, 'Berlin Eagles', 'Germany', 'Thomas Müller'),
(6, 'Prague Knights', 'Czech Republic', 'Jan Novak'),
(7, 'Warsaw Wolves', 'Poland', 'Adam Kowalski'),
(8, 'Vienna Capitals', 'Austria', 'Franz Schneider');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `arenas`
--
ALTER TABLE `arenas`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`id`),
  ADD KEY `team1_id` (`team1_id`),
  ADD KEY `team2_id` (`team2_id`),
  ADD KEY `arena_id` (`arena_id`);

--
-- Индексы таблицы `teams`
--
ALTER TABLE `teams`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `arenas`
--
ALTER TABLE `arenas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `games`
--
ALTER TABLE `games`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `teams`
--
ALTER TABLE `teams`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `games`
--
ALTER TABLE `games`
  ADD CONSTRAINT `games_ibfk_1` FOREIGN KEY (`team1_id`) REFERENCES `teams` (`id`),
  ADD CONSTRAINT `games_ibfk_2` FOREIGN KEY (`team2_id`) REFERENCES `teams` (`id`),
  ADD CONSTRAINT `games_ibfk_3` FOREIGN KEY (`arena_id`) REFERENCES `arenas` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
