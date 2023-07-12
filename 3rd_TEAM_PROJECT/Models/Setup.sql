delete from T1_Department;

insert into [LTDB].[dbo].[T1_Department] (DepartmentCode)
values
('001')
,('002')
,('003');

delete from T1_Acount;

insert into [LTDB].[dbo].[T1_Acount] (UserId,Name,Position,Authority,PassWord,RegDate,DepartmentId)
values
('admin1','김건우','팀장',0,'1234',GETDATE(),'001')
,('admin2','박재걸','팀장',0,'1234',GETDATE(),'001')
,('admin3','이용학','팀장',0,'1234',GETDATE(),'001')

SELECT * FROM T1_Acount;