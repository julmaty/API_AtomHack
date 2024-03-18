CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `ReportDescription` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_ReportDescription` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `ReportDescription` (`Id`, `Description`)
VALUES (1, 'Здоровье'),
(2, 'Климат, параметры атмосферы'),
(3, 'Исследования, научная база'),
(4, 'Ресурсы');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240316205207_Initial', '8.0.3');

COMMIT;

