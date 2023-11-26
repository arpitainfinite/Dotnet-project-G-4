Select * from Department_Details
Select * from Employee_Details
Select * from Grade_Details

select GETDATE()

truncate table Department_Details

set identity_insert [dbo].[Grade_Details] on
go
insert into [Grade_Details] (Grade_Id,Grade,Min_Salary,Max_Salary,Description) 
Values (1,'M1',30000,80000,'lalalallala')

set identity_insert [dbo].[Employee_Details] on
go
insert into [Employee_Details] (Emp_ID,Emp_First_Name,Emp_Last_Name,Emp_Date_of_Birth,Emp_Date_of_Joining,Emp_Designation,Emp_Grade,Emp_Basic,Emp_Dept_Name,Emp_Gender,Emp_Marital_Status,Emp_Home_Address,Emp_Contact_Num) 
Values (2,'Adithya','Kumar','2023-11-25 13:02:59.180','2023-11-25 13:02:59.180','Software Engineer','M1','20000-30000','Hmsa','Male','Single','lalaal',1111111111)


