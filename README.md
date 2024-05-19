Event Management 

This project manages event registration and booking. 
Organizers can create events and users can register to participate in said events.



How to run:

- Open TAPProject.sln in Visual Studio
- Right click on the solution and click on "Restore NuGet Packages"
- Right click on Frontend project and select "Configure Startup Projects..."\
- Select "Multiple startup projects" and set "Frontend" and "WebAPI" to "Start"
- Click "OK"
- Run the solution

Note: 
	Some features will be available only after logging in with Microsoft. 
	The database is seeded with an organizer profile and a few events, but to be able to view data in MyEvents, MyTickets, a ticket reservation after login is needed.

	Ideal flow:
		- Login with Microsoft
		- Go to Events
		- Click on an event to see details
		- Reserve a ticket
		- Go to MyTickets (Profile menu) to see the reservation
		- Go to MyEvents to see the event you registered for
		- Go to Logout to logout