# WebAppForTrackingLaboratoryActivity

The application is a Web Application for tracking the laboratory activity for the Software Design laboratory. The application has two types of users (student and teacher) which provide a username and a password to use the application. The teacher has control over the student’s information,  over laboratory classes and over assignments. The student can view a list of laboratory classes, a list of assignments for a laboratory class and create an assignment submission.

The teacher can perform the following operations:
- Login
- CRUD on students. For each student we should track: email address, full name, group (ex. 30434) and hobby.
- Can add/edit/delete Laboratory classes (Subjects of lab classes- eg. Software design, Maths) is out of scope). For each class we should track: Laboratory number (#1-#14), date, title, objectives (string) and a long description with the laboratory text.
- CRUD on assignments. Some of the laboratory will have assignments: for each assignment we must track the name, deadline, and a long description with the assignment text.
- Grade the submitted assignments individually.
- Calculate the final grade as an average of all marks. Also store if a student has passed or failed the exam by the following rules:
Passed: - all assignments submitted; grades > 5, average > 6.
Failed: - condition from passed is not satisfied

The student can perform the following operations:
- Login with the username and password.
- View a list of laboratory classes.
- View the assignments for a laboratory class.
- Create an assignment submission. Here, students should be able to insert a link to a git repository and a short comment (optional) for the teacher.
