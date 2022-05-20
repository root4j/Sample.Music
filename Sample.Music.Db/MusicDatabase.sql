DROP TABLE IF EXISTS `AlbumGenre`;
DROP TABLE IF EXISTS `AlbumSong`;
DROP TABLE IF EXISTS `Song`;
DROP TABLE IF EXISTS `Album`;
DROP TABLE IF EXISTS `Genre`;
DROP TABLE IF EXISTS `Artist`;

CREATE TABLE `Artist` (
  `ArtistId` int PRIMARY KEY AUTO_INCREMENT,
  `Name` varchar(150) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ModifiedBy` varchar(50),
  `ModifyDate` datetime NOT NULL
);

CREATE TABLE `Genre` (
  `GenreId` int PRIMARY KEY AUTO_INCREMENT,
  `Name` varchar(150) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ModifiedBy` varchar(50),
  `ModifyDate` datetime NOT NULL
);

CREATE TABLE `Album` (
  `AlbumId` int PRIMARY KEY AUTO_INCREMENT,
  `Title` varchar(150) NOT NULL,
  `LaunchDate` datetime,
  `ArtistaId` int,
  `CreatedBy` varchar(50) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ModifiedBy` varchar(50),
  `ModifyDate` datetime NOT NULL
);

CREATE TABLE `Song` (
  `SongId` int PRIMARY KEY AUTO_INCREMENT,
  `Title` varchar(150) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ModifiedBy` varchar(50),
  `ModifyDate` datetime NOT NULL
);

CREATE TABLE `AlbumSong` (
  `AlbumSongId` int PRIMARY KEY AUTO_INCREMENT,
  `AlbumId` int NOT NULL,
  `SongId` int NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ModifiedBy` varchar(50),
  `ModifyDate` datetime NOT NULL
);

CREATE TABLE `AlbumGenre` (
  `AlbumGenreId` int PRIMARY KEY AUTO_INCREMENT,
  `AlbumId` int NOT NULL,
  `GenreId` int NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ModifiedBy` varchar(50),
  `ModifyDate` datetime NOT NULL
);

ALTER TABLE `Album` ADD FOREIGN KEY (`ArtistaId`) REFERENCES `Artist` (`ArtistId`);
ALTER TABLE `AlbumSong` ADD FOREIGN KEY (`AlbumId`) REFERENCES `Album` (`AlbumId`);
ALTER TABLE `AlbumSong` ADD FOREIGN KEY (`SongId`) REFERENCES `Song` (`SongId`);
ALTER TABLE `AlbumSong` ADD UNIQUE(`AlbumId`, `SongId`);
ALTER TABLE `AlbumGenre` ADD FOREIGN KEY (`AlbumId`) REFERENCES `Album` (`AlbumId`);
ALTER TABLE `AlbumGenre` ADD FOREIGN KEY (`GenreId`) REFERENCES `Genre` (`GenreId`);
ALTER TABLE `AlbumGenre` ADD UNIQUE(`AlbumId`, `GenreId`);

INSERT INTO `Artist` (`Name`, `CreatedBy`, `CreateDate`, `ModifiedBy`, `ModifyDate`)
              VALUES ('Gilberto Santa Rosa', 'SYSTEM', NOW(), 'SYSTEM', NOW());
INSERT INTO `Genre` (`Name`, `CreatedBy`, `CreateDate`, `ModifiedBy`, `ModifyDate`)
             VALUES ('Salsa', 'SYSTEM', NOW(), 'SYSTEM', NOW());
INSERT INTO `Album` (`Title`, `CreatedBy`, `CreateDate`, `ModifiedBy`, `ModifyDate`)
             VALUES ('En Vivo Desde El Carnegie Hall', 'SYSTEM', NOW(), 'SYSTEM', NOW()),
                    ('Esencia', 'SYSTEM', NOW(), 'SYSTEM', NOW());
