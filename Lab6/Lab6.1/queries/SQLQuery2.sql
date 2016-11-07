use EducationRegistryDB
select * from Enrollments
select * from Students
select * from Courses
use ASPNETDemoDB

delete from Enrollments
where EnrollmentID>0
delete from Students
where ID>0
delete from Courses
where CourseID>0