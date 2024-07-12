# Eventino 
 
A .NET + Blazor project created for the Advanced Techniques of Programming course I took in college.

This project manages event registration and booking. 
Organizers can create events and users can register to participate in said events.

![image](https://github.com/user-attachments/assets/5f6011e4-9c1c-475b-97f1-445ed2a74254)

## Features
- **Microsoft login**: The project is secured with Microsoft Entra ID, enabling users to login with their Microsoft account.
- **Admin zone**: Only admins can create events.
- **Event and ticket reservation**: Users can reserve tickets for an event, then view their tickets in the account menu.
- **Event date viewer**: After reserving an event, users can view the events they will attend to in a calendar page

## API features
- **Logging**
- **Rate limiting**
- **Response caching**
- **SOLID principles**
- **Authorization + Authentication**
- **Documented API endpoints**

## How to run:

- Open TAPProject.sln in Visual Studio
- Right click on the solution and click on "Restore NuGet Packages"
- Right click on Frontend project and select "Configure Startup Projects..."\
- Select "Multiple startup projects" and set "Frontend" and "WebAPI" to "Start"
- Click "OK"
- Run the solution

## Note: 
Some features will be available only after logging in with Microsoft. 
The database is seeded with an organizer profile and a few events, but to be able to view data in MyEvents, MyTickets, a ticket reservation after login is needed.
 
## Ideal Frontend flow:
- Login with Microsoft
- Go to Events
- Click on an event to see details
- Reserve a ticket
- Go to MyTickets (Profile menu) to see the reservation
- Go to MyEvents to see the event you registered for
- Go to Logout to logout
