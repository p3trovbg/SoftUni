CREATE DATABASE [CINEMA]
USE [CINEMA];

CREATE TABLE [Movies] 
(
[MovieID] INT IDENTITY PRIMARY KEY,
[Title] NVARCHAR(100) NOT NULL,
[Description] nvarchar(255),
[ProducerName] nvarchar(50),
[ReleaseDate] date NOT NULL,
[Language] nvarchar(20) NOT NULL,
[Rating] tinyint CHECK ([Rating] BETWEEN 1 AND 6)
)


INSERT 
  INTO [Movies] ([Title], [Description], [ProducerName], [ReleaseDate], [Language], [Rating]) VALUES
 ('Monte Carlo', 'Curabitur convallis.', 'Randolph Grissett', '2021-03-27', 'Croatian', 3)
,('Voyager', 'Duis mattis egestas metus. Aenean fermentum.', 'Letizia Lorans', '2020-11-22', 'Gujarati', 2)
,('Big City', 'Sed accumsan felis.', 'Tiffie Mathet', '2021-04-23', 'Papiamento', 6)
,('Tenderness', 'Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo.', 'Dunc Hawler', '2020-12-13', 'Dzongkha', 6)
,('Fighting Prince of Donegal, The', 'Vestibulum ante ipsum primis in faucibus orci.', 'Allsun Woolmington', '2020-06-05', 'Swati', 6)
,('Murder on a Honeymoon', 'Cras mi pede, malesuada in, imperdiet et.', 'Layton Attenburrow', '2020-07-09', 'English', 3)
,('All the President''s Men', 'Curabitur in libero ut massa volutpat convallis.', 'Bron World', '2020-12-13', 'Nepali', 1)
,('Sisters', 'Vestibulum ante ipsum primis in faucibus orci.', 'Ilario Steptowe', '2020-09-29', 'Hiri Motu', 4)
,('Girls Can''t Swim', 'Mauris ullamcorper purus sit amet nulla.', 'Allie Gorgler', '2020-12-12', 'English', 5)
,('Outlaw', 'Duis bibendum.', 'Marcellus Camier', '2020-11-26', 'Norwegian', 6)

CREATE TABLE [Actors] 
(
[ActorID] INT IDENTITY PRIMARY KEY,
[FirstName] nvarchar(30) NOT NULL,
[LastName] nvarchar(30) NOT NULL,
[Gender] char(1) check ([Gender] in ('f','m'))
);

INSERT 
  INTO [Actors] ([FirstName], [LastName], [Gender]) VALUES
('Shae', 'Jezzard', 'm'),
('Aimee', 'Blankett', 'f'),
('Ursula', 'Ramiro', 'f'),
('Patrice', 'Erdely', 'm'),
('Christian', 'Gisbye', 'm'),
('Grannie', 'Vicar', 'm'),
('Wang', 'Crabbe', 'm'),
('Tanner', 'Niesegen', 'm'),
('Marja', 'Vanichkin', 'f'),
('Bunny', 'Connerry', 'm')


CREATE TABLE [MoviesActors]
(
  [MovieID] INT FOREIGN KEY REFERENCES [Movies]([MovieID]),
  [ActorID] INT FOREIGN KEY REFERENCES [Actors]([ActorID])
)

INSERT 
  INTO [MoviesActors]([MovieID], [ActorID]) VALUES
(5, 9),
(7, 5),
(3, 10),
(6, 10),
(2, 8),
(9, 9),
(8, 4),
(3, 1),
(6, 9),
(2, 3),
(1, 3),
(4, 9),
(2, 4),
(3, 5),
(4, 7),
(1, 4),
(8, 6),
(6, 5),
(8, 6),
(3, 4)


SELECT *
  FROM [Actors]
 WHERE [Gender] = 'f'

SELECT * 
  FROM [Movies]
 WHERE [Language] = 'English'

SELECT 
     [Title]
   FROM [Movies]
  WHERE [Description] LIKE '%ipsum%'

UPDATE [MoviesActors]
   SET [ActorID] = 5
 WHERE [ActorID] = 1;

ALTER TABLE [Movies]
ADD [Genre] NVARCHAR(20) DEFAULT(NULL)


--Delete all records
DELETE FROM [MoviesActors]