﻿delete from T1_Department;
--Acount--
delete from process;
delete from T1_Acount;
select * from T1_Acount;
select * from T1_Department;
insert into [LTDB].[dbo].[T1_Department] (DepartmentCode,Name)
values
('001','경영팀')
,('002','구매팀')
,('003','생산팀');

insert into [LTDB].[dbo].[T1_Acount] (UserId,Name,Position,Authority,PassWord,RegDate,DepartmentCode)
values
('admin1','김건우','팀장',0,'1234',GETDATE(),(SELECT DepartmentCode FROM T1_Department WHERE DepartmentCode = '001'))
,('admin2','박재걸','팀장',0,'1234',GETDATE(),(SELECT DepartmentCode FROM T1_Department WHERE DepartmentCode = '002'))
,('admin3','이용학','팀장',0,'1234',GETDATE(),(SELECT DepartmentCode FROM T1_Department WHERE DepartmentCode = '003'));
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
insert into [LTDB].[dbo].[T1_Acount] (UserId,Name,Position,Authority,PassWord,RegDate,DepartmentCode, DepartmentId)
values
 ('admin1','김건우','팀장',0,'1234',GETDATE(),(SELECT DepartmentCode FROM T1_Department WHERE DepartmentCode = '001'), (SELECT Id FROM T1_Department WHERE DepartmentCode = '001'))
,('admin2','박재걸','팀장',0,'1234',GETDATE(),(SELECT DepartmentCode FROM T1_Department WHERE DepartmentCode = '002'), (SELECT Id FROM T1_Department WHERE DepartmentCode = '002'))
,('admin3','이용학','팀장',0,'1234',GETDATE(),(SELECT DepartmentCode FROM T1_Department WHERE DepartmentCode = '003'), (SELECT Id FROM T1_Department WHERE DepartmentCode = '001'));

SELECT * FROM T1_Acount;
--WareHouse--
delete from T1_WareHouse;

SELECT * FROM T1_WareHouse;
SELECT * FROM T1_OutBound;
insert into [LTDB].[dbo].[T1_WareHouse] (Product,Item,Amount)
values
('RTX1060','GraphicCard',100)
,('RTX2080','GraphicCard',100)
,('RTX3080','GraphicCard',100)
,('RTX4070','GraphicCard',100)

insert into [LTDB].[dbo].[T1_WareHouse] (Product,Item,Amount)
values
('Corei3','CPU',100)
,('Corei5','CPU',100)
,('Corei7','CPU',100)
,('Corei9','CPU',100)


delete from T1_InBound;

INSERT INTO [LTDB].[dbo].[T1_InBound] ( Product,Amount ,Vendor, RegDate, Contact)
VALUES 
((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei9'),20,'다나와', GETDATE(), '김건우')
,((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei7'),20,'다나와', GETDATE(), '김건우')
,((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei5'),20,'다나와', GETDATE(), '김건우')
,((SELECT Product FROM T1_WareHouse WHERE Product = 'Corei3'),20,'다나와', GETDATE(), '김건우')
--Process 추가후 다시---
SELECT * FROM T1_InBound;
SELECT * FROM T1_OutBound;
delete from T1_OutBound;
INSERT INTO [LTDB].[dbo].[T1_OutBound] (Product,Amount,Contact,RegDate)
VALUES
('Corei9',20,'김건우',GETDATE())
,('Corei7',20,'김건우',GETDATE())
,('Corei5',20,'김건우',GETDATE())
,('Corei3',20,'김건우',GETDATE())
------------------------------------------------------------------------------------------------------------
--Factory--
delete from T1_Factory;
insert into [LTDB].[dbo].[T1_Factory] (Code,Name,Constructor,RegDate)
values
('F_COM_001','컴퓨터공장','김건우',GETDATE())
,('F_COM_0012','컴퓨터공장2','김건우',GETDATE())
SELECT * FROM T1_Factory;
--Equiment--
SELECT * FROM T1_Equipment;
delete from T1_Equipment;
insert into [LTDB].[dbo].[T1_Equipment] (Code,Name,Comment,Status,Event,Constructor,RegDate)
values
('Equip01','설비1','','Ready','NON','김건우',GETDATE())
,('Equip02','설비2','','Ready','NON','김건우',GETDATE())
,('Equip03','설비3','','Ready','NON','김건우',GETDATE())
,('Equip04','설비4','','Ready','NON','김건우',GETDATE())

--Item--

delete from T1_Item;
insert into [LTDB].[dbo].[T1_Item] (Code,Name,Type,Constructor,RegDate)
Values
('C_001','컴퓨터corei3','FERT','김건우',GETDATE())
,('C_002','컴퓨터corei5','FERT','김건우',GETDATE())
,('C_003','컴퓨터corei7','FERT','김건우',GETDATE())
,('C_004','컴퓨터corei9','FERT','김건우',GETDATE())

--Process--
delete from t1_MProcess;
insert into [LTDB].[dbo].[T1_MProcess] (Code,Name,Comment,EquipCode,StockUnit1,StockUnit2,Constructor,RegDate)
Values
('P_Test01','테스트1','','Equip01','EA','','김건우',GETDATE())
,('P_Test02','테스트2','','Equip01','EA','','김건우',GETDATE())
,('P_Test03','테스트3','','Equip01','EA','','김건우',GETDATE())
,('P_Test04','테스트4','','Equip01','EA','','김건우',GETDATE())
select * from t1_MProcess;

--Create Lot--
delete from T1_CreateLot;
insert into [LTDB].[dbo].[T1_CreateLot] (Code,Amount1,Amount2,HisNum,ActionCode,ProcessCode,ItemCode,Constructor,RegDate)
Values
('L_Test01','50','50',1,'Create','P_Test01','C_001','김건우',GETDATE())
,('L_Test02','50','50',1,'Create','P_Test02','C_002','김건우',GETDATE())
,('L_Test03','50','50',1,'Create','P_Test03','C_003','김건우',GETDATE())
,('L_Test04','50','50',1,'Create','P_Test04','C_004','김건우',GETDATE());

SELECT DepartmentCode FROM T1_Department WHERE DepartmentCode = '001';

select * from T1_Factory;
select * from T1_Equipment