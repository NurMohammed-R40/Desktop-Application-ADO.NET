/*
			   Project work
			      Made by
			    Nur Mohammed
			    ID: 1248604
		Batch: ESAD-CS/PNTL-M/40/01
		

			     Project on
			   HR Management
*/
USE master
GO

IF EXISTS(Select name from sys.sysdatabases where name='HR_DB')
DROP DATABASE HR_DB
GO
CREATE DATABASE HR_DB
GO
USE HR_DB
GO




CREATE TABLE tblDepartment
(
	DepartmentId INT PRIMARY KEY IDENTITY,
	Department VARCHAR(30) NOT NULL
)
GO

CREATE TABLE tblDesignation
(
	DesignationId INT PRIMARY KEY IDENTITY,
	Designation VARCHAR(30) NOT NULL
)
GO

CREATE TABLE tblSection
(
	SectionId INT PRIMARY KEY IDENTITY,
	Section VARCHAR(30) NOT NULL
)
GO

CREATE TABLE tblCountry
(
	CountryId INT PRIMARY KEY IDENTITY,
	Country VARCHAR(30) NOT NULL
)
GO

CREATE TABLE tblCity
(
	CityId INT PRIMARY KEY IDENTITY,
	CountryId INT REFERENCES tblCountry(CountryId),
	City VARCHAR(30) NOT NULL
)
GO

CREATE TABLE tblEmployee
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	DepartmentId INT REFERENCES tblDepartment(DepartmentId),
	DesignationId INT REFERENCES tblDesignation(DesignationId),
	SectionId INT REFERENCES tblSection(SectionId),
	JoiningDate DATE NOT NULL,
	Salary MONEY NOT NULL,
	DateOfBirth DATE NOT NULL,
	Gender VARCHAR(15) NOT NULL,
	Religion VARCHAR(15) NOT NULL,
	CountryId INT REFERENCES tblCountry(CountryId),
	CityId INT REFERENCES tblCity(CityId),
	Address VARCHAR(100) NOT NULL,
	Contact VARCHAR(15) NOT NULL,
	Email VARCHAR(30) NOT NULL
)
GO

CREATE TABLE tblUser
(
	UserId INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(15) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	Contact VARCHAR(15) NOT NULL
)
GO


CREATE PROC spEmployeeList
AS
SELECT e.EmployeeId AS ID, e.Name, d.Department,dg.Designation,s.Section,e.JoiningDate AS [Joining Date],CAST(e.Salary AS NUMERIC(10,2)) AS Salary, e.DateOfBirth AS [Date Of Birth] ,co.Country,ci.City,e.Address,e.Email,e.Contact AS [Mobile No.],e.Gender,e.Religion FROM tblEmployee e
INNER JOIN tblCountry co ON e.CountryId=co.CountryId
INNER JOIN tblCity ci ON e.CityId=ci.CityId
INNER JOIN tblDepartment d ON e.DepartmentId=d.DepartmentId
INNER JOIN tblDesignation dg ON e.DesignationId=dg.DesignationId
INNER JOIN tblSection s ON e.SectionId=s.SectionId
GO


CREATE PROC spDesignationWiseEmployeeList
			@departmentId INT,
			@designationId INT
AS
SELECT e.EmployeeId AS ID, e.Name, d.Department,dg.Designation,s.Section,e.JoiningDate AS [Joining Date],CAST(e.Salary AS NUMERIC(10,2)) AS Salary, e.DateOfBirth AS [Date Of Birth] ,co.Country,ci.City,e.Address,e.Email,e.Contact AS [Mobile No.],e.Gender,e.Religion FROM tblEmployee e
INNER JOIN tblCountry co ON e.CountryId=co.CountryId
INNER JOIN tblCity ci ON e.CityId=ci.CityId
INNER JOIN tblDepartment d ON e.DepartmentId=d.DepartmentId
INNER JOIN tblDesignation dg ON e.DesignationId=dg.DesignationId
INNER JOIN tblSection s ON e.SectionId=s.SectionId
WHERE d.DepartmentId=@departmentId AND dg.DesignationId=@designationId
GO


CREATE PROC spDepartmentWiseEmployeeList
			@departmentId INT
AS
SELECT e.EmployeeId AS ID, e.Name, d.Department,dg.Designation,s.Section,e.JoiningDate AS [Joining Date],CAST(e.Salary AS NUMERIC(10,2)) AS Salary, e.DateOfBirth AS [Date Of Birth] ,co.Country,ci.City,e.Address,e.Email,e.Contact AS [Mobile No.],e.Gender,e.Religion FROM tblEmployee e
INNER JOIN tblCountry co ON e.CountryId=co.CountryId
INNER JOIN tblCity ci ON e.CityId=ci.CityId
INNER JOIN tblDepartment d ON e.DepartmentId=d.DepartmentId
INNER JOIN tblDesignation dg ON e.DesignationId=dg.DesignationId
INNER JOIN tblSection s ON e.SectionId=s.SectionId
WHERE d.DepartmentId=@departmentId
GO


-------=======*******=======-------
--Some Data Insertation For Test

INSERT INTO tblUser VALUES('Nur','321','nurmohammedbd24@gmail.com','01977197710')
SELECT * FROM tblUser

INSERT INTO tblDepartment VALUES('Production'),('Accounts'),('Marketing'),('Sales'),('Management')
SELECT * FROM tblDepartment

INSERT INTO tblDesignation VALUES('Senior Officer'),('Executive Officer'),('Officer'),('Junior Officer'),('Clerk')
SELECT * FROM tblDesignation

INSERT INTO tblSection VALUES('A'),('B'),('C'),('D')
SELECT * FROM tblSection

INSERT INTO tblCountry VALUES('Bangladesh'),('India'),('China'),('Nepal'),('Bhutan')
SELECT * FROM tblCountry

INSERT INTO tblCity VALUES
(1,'Dhaka'),
(1,'Barishal'),
(1,'Chittagong'),
(1,'Khulna'),
(1,'Mymenshingh'),
(1,'Rajshahi'),
(1,'Rangpur'),
(1,'Sylhet'),
(2,'Delhi'),
(2,'Kolkata'),
(2,'Mumbai'),
(3,'Beijing'),
(3,'Shanghai'),
(3,'Shenzhen'),
(4,'Kathmandu'),
(4,'Pokhara'),
(4,'Lalitpur'),
(5,'Thimpu'),
(5,'Phuntsholing'),
(5,'Paro')
SELECT * FROM tblCity

INSERT INTO tblEmployee VALUES
('Nur Mohammed',2,1,1,'10/10/2018',32000,'12/12/1993','Male','Islam',1,1,'South Donia, Kadamtoli','01977197710','nurmohammedbd24@gmail.com'),
('Azman Ali',5,1,1,'12/12/2012',65000,'10/10/1984','Male','Islam',1,1,'Mirpur','01911311076','azman6364@gmail.com'),
('Emarat Ali',1,3,2,'05/05/2017',30000,'10/10/1993','Male','Islam',2,10,'Kolkata Jora Sako','01935031121','mdemaratali@gmail.com'),
('Mahfuz Ayub',1,1,3,'02/02/2016',48000,'07/07/1992','Male','Islam',3,12,'Beijin','01677070201','mahfuzayub@gmail.com'),
('Md. Kamal Hosen',3,2,3,'06/06/2018',28000,'07/07/1994','Male','Islam',4,15,'Kathmandu','01751196168','kpsgc5544@gmail.com'),
('Md. Imran Haque',4,2,4,'06/06/2018',28000,'07/07/1994','Male','Islam',5,18,'Thimpu','01774409230','md.haqueimran@gmail.com'),
('Nayeem Bhuiyan',1,3,4,'02/02/2015',35000,'05/05/1991','Male','Islam',1,2,'Bakergonj','01755391672','nayeembhuiyan30@gmail.com'),
('Md. Imran Khan',1,4,2,'02/02/2018',25000,'03/03/1994','Male','Islam',1,3,'Comilla','01980000865','imran500official@gmail.com'),
('Emdadul Haque',2,2,2,'11/11/2016',35000,'01/01/1992','Male','Islam',1,4,'Bagerhat','01721760389','emdadulhaque585@gmail.com'),
('Md. Akram Khan',4,2,2,'11/11/2017',30000,'03/03/1993','Male','Islam',1,5,'Trisal','01789000288','hkakram99@gmail.com'),
('Md. Monir Alam',3,1,2,'12/12/2018',30000,'04/04/1995','Male','Islam',1,6,'Rajshahi','01675886948','md.moniralam210100@gmail.com'),
('Md. Ibrahim Faraji',4,2,1,'12/12/2018',25000,'08/08/1994','Male','Islam',1,7,'Rangpur','01754830456','munshiebu@gmail.com'),
('Omar Faruk Munna',5,3,1,'10/10/2016',45000,'08/08/1994','Male','Islam',1,8,'Sylhet','01985101569','omarmunna67@gmail.com'),
('Nur Mohammed',1,2,1,'10/10/2018',32000,'12/12/1993','Male','Islam',1,1,'South Donia, Kadamtoli','01977197710','nurmohammedbd24@gmail.com'),
('Azman Ali',1,1,1,'12/12/2012',65000,'10/10/1984','Male','Islam',1,1,'Mirpur','01911311076','azman6364@gmail.com'),
('Emarat Ali',1,5,2,'05/05/2017',30000,'10/10/1993','Male','Islam',2,10,'Kolkata Jora Sako','01935031121','mdemaratali@gmail.com'),
('Mahfuz Ayub',2,3,3,'02/02/2016',48000,'07/07/1992','Male','Islam',3,12,'Beijin','01677070201','mahfuzayub@gmail.com'),
('Md. Kamal Hosen',2,4,3,'06/06/2018',28000,'07/07/1994','Male','Islam',4,15,'Kathmandu','01751196168','kpsgc5544@gmail.com'),
('Md. Imran Haque',2,5,4,'06/06/2018',28000,'07/07/1994','Male','Islam',5,18,'Thimpu','01774409230','md.haqueimran@gmail.com'),
('Nayeem Bhuiyan',3,3,4,'02/02/2015',35000,'05/05/1991','Male','Islam',1,2,'Bakergonj','01755391672','nayeembhuiyan30@gmail.com'),
('Md. Imran Khan',3,4,2,'02/02/2018',25000,'03/03/1994','Male','Islam',1,3,'Comilla','01980000865','imran500official@gmail.com'),
('Emdadul Haque',3,5,2,'11/11/2016',35000,'01/01/1992','Male','Islam',1,4,'Bagerhat','01721760389','emdadulhaque585@gmail.com'),
('Md. Akram Khan',5,2,2,'11/11/2017',30000,'03/03/1993','Male','Islam',1,5,'Trisal','01789000288','hkakram99@gmail.com'),
('Md. Monir Alam',5,4,2,'12/12/2018',30000,'04/04/1995','Male','Islam',1,6,'Rajshahi','01675886948','md.moniralam210100@gmail.com'),
('Md. Ibrahim Faraji',5,5,1,'12/12/2018',25000,'08/08/1994','Male','Islam',1,7,'Rangpur','01754830456','munshiebu@gmail.com'),
('Omar Faruk Munna',4,1,1,'10/10/2016',45000,'08/08/1994','Male','Islam',1,8,'Sylhet','01985101569','omarmunna67@gmail.com'),
('Nayeem Bhuiyan',4,3,4,'02/02/2015',35000,'05/05/1991','Male','Islam',1,2,'Bakergonj','01755391672','nayeembhuiyan30@gmail.com'),
('Md. Imran Khan',4,4,2,'02/02/2018',25000,'03/03/1994','Male','Islam',1,3,'Comilla','01980000865','imran500official@gmail.com'),
('Emdadul Haque',4,5,2,'11/11/2016',35000,'01/01/1992','Male','Islam',1,4,'Bagerhat','01721760389','emdadulhaque585@gmail.com'),
('Emdadul Haque',3,2,2,'11/11/2016',35000,'01/01/1992','Male','Islam',1,4,'Bagerhat','01721760389','emdadulhaque585@gmail.com'),
('Md. Akram Khan',3,4,2,'11/11/2017',30000,'03/03/1993','Male','Islam',1,5,'Trisal','01789000288','hkakram99@gmail.com'),
('Md. Monir Alam',2,1,2,'12/12/2018',30000,'04/04/1995','Male','Islam',1,6,'Rajshahi','01675886948','md.moniralam210100@gmail.com'),
('Md. Ibrahim Faraji',1,2,1,'12/12/2018',25000,'08/08/1994','Male','Islam',1,7,'Rangpur','01754830456','munshiebu@gmail.com'),
('Omar Faruk Munna',4,3,1,'10/10/2016',45000,'08/08/1994','Male','Islam',1,8,'Sylhet','01985101569','omarmunna67@gmail.com'),
('Nur Mohammed',4,2,1,'10/10/2018',32000,'12/12/1993','Male','Islam',1,1,'South Donia, Kadamtoli','01977197710','nurmohammedbd24@gmail.com'),
('Azman Ali',3,1,1,'12/12/2012',65000,'10/10/1984','Male','Islam',1,1,'Mirpur','01911311076','azman6364@gmail.com'),
('Emarat Ali',2,5,2,'05/05/2017',30000,'10/10/1993','Male','Islam',2,10,'Kolkata Jora Sako','01935031121','mdemaratali@gmail.com'),
('Mahfuz Ayub',4,3,3,'02/02/2016',48000,'07/07/1992','Male','Islam',3,12,'Beijin','01677070201','mahfuzayub@gmail.com'),
('Md. Kamal Hosen',4,4,3,'06/06/2018',28000,'07/07/1994','Male','Islam',4,15,'Kathmandu','01751196168','kpsgc5544@gmail.com'),
('Md. Imran Haque',3,5,4,'06/06/2018',28000,'07/07/1994','Male','Islam',5,18,'Thimpu','01774409230','md.haqueimran@gmail.com'),
('Nayeem Bhuiyan',2,3,4,'02/02/2015',35000,'05/05/1991','Male','Islam',1,2,'Bakergonj','01755391672','nayeembhuiyan30@gmail.com')
SELECT * FROM tblEmployee
