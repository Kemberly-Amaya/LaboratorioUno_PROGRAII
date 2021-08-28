CREATE DATABASE Estudiante
Use Estudiante
Go

CREATE TABLE TblNotasEstudiante(
Id_Estudiante int primary key identity not null,
Nombre varchar(50),
Lab1 varchar(10),
Lab2 varchar(10),
Lab3 varchar(10),
Par1 varchar(10),
Par2 varchar(10),
Par3 varchar(10),

);

Select *from TblNotasEstudiante