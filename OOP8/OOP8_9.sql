
use BANK

create table Owner (
Name nvarchar(50) primary key,
Surname nvarchar(50) ,
Fathername nvarchar(50) ,
Birth date not null,
PassportSeries nvarchar(4) ,
PassportNumber nvarchar(10) ,
Person_Photo varbinary(max)
);

drop table Owner;

create table ClientCheck (
Number int primary key,
CheckType nvarchar(50) not null,
Balance float not null,
Open_Date date not null,
BankServices nvarchar(20) ,
Client_Name nvarchar(50) not null foreign key references Owner(Name)
);

drop table Owner;
drop table ClientCheck



CREATE PROCEDURE

select * from Owner;
select * from ClientCheck;
delete from Owner where Name = 'Владислав'


CREATE PROCEDURE DeleteOwner 
    @Name nvarchar(50) = NULL
AS
BEGIN
    DELETE FROM ClientCheck 
    WHERE Client_Name IN (
        SELECT Name FROM Owner
        WHERE (@Name IS NULL OR Owner.Name = @Name)
    )
    DELETE FROM Owner 
    WHERE (@Name IS NULL OR Owner.Name = @Name)
END
GO

drop procedure DeleteOwner


CREATE VIEW ALL_CHECKS AS
SELECT C.Number , C.CheckType, C.Balance , C.Open_Date , C.BankServices, C.Client_Name, O.Surname ,O.PassportSeries, O.PassportNumber FROM ClientCheck C
inner join Owner O on O.Name = C.Client_Name;


select * from ALL_CHECKS;

drop view ALL_CHECKS;


CREATE PROCEDURE UpdateOwner
(
    @Name nvarchar(50),
    @Surname nvarchar(50),
    @Fathername nvarchar(50),
    @Birth date,
    @PassportSeries nvarchar(4),
    @PassportNumber nvarchar(10),
    @Person_Photo varbinary(max)
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Owner
    SET 
        Surname = @Surname,
        Fathername = @Fathername,
        Birth = @Birth,
        PassportSeries = @PassportSeries,
        PassportNumber = @PassportNumber,
        Person_Photo = @Person_Photo
    WHERE
        Name = @Name;
END;


drop procedure UpdateOwner


CREATE PROCEDURE UpdateClientCheck
(
    @Number int,
    @CheckType nvarchar(50),
    @Balance float,
    @Open_Date date,
    @BankServices nvarchar(20),
    @Client_Name nvarchar(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ClientCheck
    SET 
        CheckType = @CheckType,
        Balance = @Balance,
        Open_Date = @Open_Date,
        BankServices = @BankServices,
        Client_Name = @Client_Name
    WHERE
        Number = @Number
        AND EXISTS (
            SELECT 1 FROM Owner WHERE Name = @Client_Name
        );
END;

drop procedure UpdateClientCheck;


select O.Birth from Owner O
inner join ClientCheck C on C.Client_Name = O.Name;










create table Owners (
ID int identity primary key,
Name nvarchar(50) ,
Surname nvarchar(50) ,
Fathername nvarchar(50) ,
Birth date not null,
PassportSeries nvarchar(4) ,
PassportNumber nvarchar(10) 
);


create table ClientChecks (
Number int identity primary key,
CheckType nvarchar(50) not null,
Balance float not null,
ClientID int not null foreign key references Owner(ID)
);

drop table _MigrationHistory
drop table Owners;
drop table ClientChecks


insert into Owners VALUES('Vlad','Lemiasheusky','Olegovich','25-04-2004','MP','1234567');
insert into ClientChecks VALUES('кредитный',-123.12,1,1);



select * from Owners
select * from ClientChecks



CREATE PROCEDURE DeleteOwner 
    @ownerID int = NULL
AS
BEGIN
    DELETE FROM ClientChecks 
    WHERE ClientID IN (
        SELECT ID FROM Owners
        WHERE (@ownerID IS NULL OR Owners.ID = @ownerID)
    )
    DELETE FROM Owners 
    WHERE (@ownerID IS NULL OR Owners.ID = @ownerID)
END
GO

drop procedure DeleteOwner



CREATE PROCEDURE UpdateOwner
(
    @Name nvarchar(50),
    @Surname nvarchar(50),
    @Fathername nvarchar(50),
    @Birth date,
    @PassportSeries nvarchar(4),
    @PassportNumber nvarchar(10),
    @Person_Photo varbinary(max)
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Owner
    SET 
        Surname = @Surname,
        Fathername = @Fathername,
        Birth = @Birth,
        PassportSeries = @PassportSeries,
        PassportNumber = @PassportNumber,
        Person_Photo = @Person_Photo
    WHERE
        Name = @Name;
END;


drop procedure UpdateOwner


CREATE PROCEDURE UpdateClientCheck
(
    @Number int,
    @CheckType nvarchar(50),
    @Balance float,
    @Open_Date date,
    @BankServices nvarchar(20),
    @Client_Name nvarchar(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ClientCheck
    SET 
        CheckType = @CheckType,
        Balance = @Balance,
        Open_Date = @Open_Date,
        BankServices = @BankServices,
        Client_Name = @Client_Name
    WHERE
        Number = @Number
        AND EXISTS (
            SELECT 1 FROM Owner WHERE Name = @Client_Name
        );
END;