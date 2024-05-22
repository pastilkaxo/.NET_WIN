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
(NEWID(), '����� �.�.', 'mysh@example.com'),
(NEWID(), '������� �.�.', 'blinova@example.com'),
(NEWID(), '���������� �.�.', 'kanta@example.com'),
(NEWID(), '��������� �.�.', 'byrm@example.com')
;

-- Insert Courses
INSERT INTO Courses (Id, Title, Hours, LecturerId)
VALUES
(NEWID(), '���', 40, (SELECT Id FROM Lecturers WHERE Name = '����� �.�.')),
(NEWID(), '���� ������', 60, (SELECT Id FROM Lecturers WHERE Name = '������� �.�.')),
(NEWID(), '������ ���������������� �����������', 50, (SELECT Id FROM Lecturers WHERE Name = '���������� �.�.')),
(NEWID(), '�������������� ����������������', 70, (SELECT Id FROM Lecturers WHERE Name = '��������� �.�.'));

-- Insert Students
INSERT INTO Students (Id, Name, ContactInfo)
VALUES
(NEWID(), '����', 'vlad@example.com'),
(NEWID(), '������', 'nikita@example.com'),
(NEWID(), '�����', 'sveta@example.com'),
(NEWID(), '�������', 'alexey@example.com');



-- Insert course-student relationships
delete from Students

select * from CourseStudents
INSERT INTO CourseStudents (CourseId, StudentId)
VALUES
((SELECT Id FROM Courses WHERE Title = '���'), (SELECT Id FROM Students WHERE Name = '����')),
((SELECT Id FROM Courses WHERE Title = '���'), (SELECT Id FROM Students WHERE Name = '������')),
((SELECT Id FROM Courses WHERE Title = '���� ������'), (SELECT Id FROM Students WHERE Name = '�����')),
((SELECT Id FROM Courses WHERE Title = '������ ���������������� �����������'), (SELECT Id FROM Students WHERE Name = '�������')),
((SELECT Id FROM Courses WHERE Title = '������ ���������������� �����������'), (SELECT Id FROM Students WHERE Name = '�����')),
((SELECT Id FROM Courses WHERE Title = '�������������� ����������������'), (SELECT Id FROM Students WHERE Name = '����')),
((SELECT Id FROM Courses WHERE Title = '�������������� ����������������'), (SELECT Id FROM Students WHERE Name = '�������'));


select * from Courses
select * from Students
select * from Lecturers