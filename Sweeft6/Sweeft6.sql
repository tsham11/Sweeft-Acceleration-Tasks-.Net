create database Sweeftask
use Sweeftask

-- create Teacher table
create table Teacher_tbl (
	Teacher_ID INT PRIMARY KEY,
	FName VARCHAR(20),
	LName VARCHAR(50),
	Gender VARCHAR(10),
	Subject VARCHAR(30)
);

-- create Pupil table
create table Pupil_tbl(
	Pupil_ID INT PRIMARY KEY,
	FName VARCHAR(20),
	LName VARCHAR(50),
	Gender VARCHAR(10),
	Class VARCHAR(20)
);

-- Create Teacher_Pupil table (junction table)
create table Teacher_Pupil(
    Teacher_ID INT,
    Pupil_ID INT,
    PRIMARY KEY (Teacher_ID, Pupil_ID),
    FOREIGN KEY (Teacher_ID) REFERENCES Teacher_tbl(Teacher_ID),
    FOREIGN KEY (Pupil_ID) REFERENCES Pupil_tbl(Pupil_ID)
);

-- Insert data into Teacher_tbl
INSERT INTO Teacher_tbl (Teacher_ID, FName, LName, Gender, Subject)
VALUES
    (1, 'Tamar', 'Shamugia', 'Female', 'Math'),
    (2, 'Ilia', 'Samkharadze', 'Male', 'English'),
    (3, 'Misha', 'Maisuradze', 'Male', 'Science');

-- Insert data into Pupil_tbl
INSERT INTO Pupil_tbl (Pupil_ID, FName, LName, Gender, Class)
VALUES
    (1, 'Keso', 'Rurua', 'Female', 'Grade 10'),
    (2, 'Ana', 'Barbaqadze', 'Female', 'Grade 11'),
    (3, 'Giorgi', 'Davitadze', 'Male', 'Grade 9'),
	(4, 'Giorgi', 'Kaladze', 'Male', 'Grade 8');

-- Insert data into Teacher_Pupil (Junction) table to establish relationships
INSERT INTO Teacher_Pupil (Teacher_ID, Pupil_ID)
VALUES
    (1, 1), -- Tamar Shamugia teaches Keso Rurua
    (2, 2), -- Ilia Samkharadze teaches Ana Barbaqadze
    (3, 3), -- Misha Maisuradze teaches Giorgi Davitadze
    (1, 4); -- Tamar Shamugia teaches Giorgi Kaladze

-- Retrieve all teachers who teach a student named "George"
SELECT DISTINCT t.*
FROM Teacher_tbl t
JOIN Teacher_Pupil tp ON t.Teacher_ID = tp.Teacher_ID
JOIN Pupil_tbl p ON tp.Pupil_ID = p.Pupil_ID
WHERE p.FName = 'Giorgi'; 


