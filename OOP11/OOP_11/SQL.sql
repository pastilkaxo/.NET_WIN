Create database Company

use Company;


CREATE TABLE Course (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Hours INT NOT NULL,
	StudCount INT NOT NULL,
    LecturerId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Course_Lecturer FOREIGN KEY (LecturerId) REFERENCES Lecturer (Id)
);

CREATE TABLE Student (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(100) NOT NULL
);

CREATE TABLE Lecturer (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(100) NOT NULL
);
-- Insert Lecturers
INSERT INTO Lecturers (Id, Name, ContactInfo)
VALUES
(NEWID(), 'Мущук А.Н.', 'mysh@example.com'),
(NEWID(), 'Блинова Е.А.', 'blinova@example.com'),
(NEWID(), 'Кантарович В.С.', 'kanta@example.com'),
(NEWID(), 'Бурмакова А.В.', 'byrm@example.com')
;

-- Insert Courses
INSERT INTO Courses (Id, Title, Hours, LecturerId)
VALUES
(NEWID(), 'ООП', 40, (SELECT Id FROM Lecturers WHERE Name = 'Мущук А.Н.')),
(NEWID(), 'Базы Данных', 60, (SELECT Id FROM Lecturers WHERE Name = 'Блинова Е.А.')),
(NEWID(), 'Дизайн пользовательских интерфейсов', 50, (SELECT Id FROM Lecturers WHERE Name = 'Кантарович В.С.')),
(NEWID(), 'Математическое Программирование', 70, (SELECT Id FROM Lecturers WHERE Name = 'Бурмакова А.В.'));

-- Insert Students
INSERT INTO Students (Id, Name, ContactInfo)
VALUES
(NEWID(), 'Влад', 'vlad@example.com'),
(NEWID(), 'Никита', 'nikita@example.com'),
(NEWID(), 'Света', 'sveta@example.com'),
(NEWID(), 'Алексей', 'alexey@example.com');



-- Insert course-student relationships
delete from Students

select * from CourseStudents
INSERT INTO CourseStudents (CourseId, StudentId)
VALUES
((SELECT Id FROM Courses WHERE Title = 'ООП'), (SELECT Id FROM Students WHERE Name = 'Влад')),
((SELECT Id FROM Courses WHERE Title = 'ООП'), (SELECT Id FROM Students WHERE Name = 'Никита')),
((SELECT Id FROM Courses WHERE Title = 'Базы Данных'), (SELECT Id FROM Students WHERE Name = 'Света')),
((SELECT Id FROM Courses WHERE Title = 'Дизайн пользовательских интерфейсов'), (SELECT Id FROM Students WHERE Name = 'Алексей')),
((SELECT Id FROM Courses WHERE Title = 'Дизайн пользовательских интерфейсов'), (SELECT Id FROM Students WHERE Name = 'Света')),
((SELECT Id FROM Courses WHERE Title = 'Математическое Программирование'), (SELECT Id FROM Students WHERE Name = 'Влад')),
((SELECT Id FROM Courses WHERE Title = 'Математическое Программирование'), (SELECT Id FROM Students WHERE Name = 'Алексей'));


select * from Courses
select * from Students
select * from Lecturers