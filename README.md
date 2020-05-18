
# HiPages Tech Challenge
This is a tech challenge for Fullstack .Net Engineer at HiPages. Click [here](https://github.com/hipages/tech-test-dot-net-engineer) for more details.

## Screenshots
![enter image description here](https://github.com/markglibres/job-app-hipages/blob/master/assets/invited.png?raw=true)

![enter image description here](https://github.com/markglibres/job-app-hipages/blob/master/assets/accepted2.png?raw=true)
## Project Structure / Architecture
The architecture used on this project is based on a project template that I created. More info can be found [here](https://github.com/markglibres/dotnetcore-service-template).
It demonstrates the following patterns /  architecture:
* dependency injection (IoC)
* mediator pattern (with MediatR)
* service layer pattern
* repository pattern
* event-driven design
* clean architecture
* CQRS (with separate databases for command and queries)
* domain driven design
* event sourcing (with own separate database)
	* *Note: I just had a quick 15-min read about event sourcing, which means, this is my first time to implement it and pardon me if it wasn't implemented correctly / completely*

### SPA
* react
* react-redux
* redux-saga
* material-ui

### Web API
 * REST
 * dotnetcore 3.1 with C#
 * HAL response
 
 ### Other tools / libraries
 *  MySql 8.x (because the sample given was on MySql, so I assume this is what's used by hipages)
 * docker
 * Entity Framework Core

## Solutions
* Invited and Accepted leads data are taken from a separate database (queries) and with flat structure.

* Buttons or "Actions" per job lead, such as "Accept" / "Decline", are dynamically populated from the UI and dictated by the backend with the use of HAL json specification.
* The fake Notification service (email sending) is logging the subject and job reference id in console.
* Discounts are injected as `IEnumerable<IDiscountRules>` . For other discount scenarios, just implement a new class that inherits this type.
	* Above500Discount - the class used to compute 10% discount if price is greater than $500.
* Seed data: created classes for seeding data. Auto-migration and  seeding of data only happens when environment is "Development". 
	* SeedCategory - a class used to seed the categories
	* SeedSuburbs - a class used to seed the suburbs
	* SeedJobs - a class used to seed the job leads
* Databases:
	* hipages - The main database with relational models. "Commands" are reading and writing on this database.
	* hipages_query - This is where "Queries" will read data from. 
	* hipages_events - This serves as the event store (event sourcing). Have implemented this on the last minute because this is my first time doing it. (not even sure if it was done correctly)
* Domain Events:
	* JobCreatedEvent 
		* when inserting new job to the database, this event will be emitted
		* one consumer (SaveToQueryOnJobCreatedEventHandler) is writing to the query database
		* one consumer (SaveToStoreOnJobCreatedEventHandler) is writing to the event store
	* JobAcceptedEvent
		* this event will be emitted upon acceptance of a job lead
		* one consumer (NotifyOnJobAcceptedEventHandler) is sending notification to sales
		* one consumer (SaveToStoreOnJobAcceptedEventHandler) is saving to event store
	* JobUpdatedEvent
		* emitted when a job has been updated. for now, it's only when updating the status
		* one consumer (SaveToQueryOnJobUpdatedEventHandler) is writing to the query database
		* one consumer (SaveToStoreOnJobUpdatedEventHandler) is saving to event store
	* JobDeclinedEvent
		* emitted when a job has been declined.
		* one consumer (SaveToStoreOnJobDeclinedEventHandler) is saving to the event store
		
## What could have been improved
With limited time, I wasn't able to implement other technologies / patterns / practicies, such as:
* Unit testing - should have domain unit testing at the very least and SPA services / components
* E2E testing - should have done end-to-end testing with the use of Cypress
* Integration testing- should have done api tests using Jest
* State Machine - should have implemented to handle states and actions for jobs using C# Stateless library.
* gRPC - the services under Application Layer (JobQueryService & EventSourcingService) should have been on a separate microservice either using messages queues / event bus OR gRPC. I prefer gRPC for internal communication. See my sample implementation on this [link](https://github.com/markglibres/job-app-deltatre)
* Hybrid microservice pattern - where the API is the centralized microservice that communicates with 3 internal microservices:
	* Jobs service - add / update / accept / decline job leads. Send messages (either queues or gRPC) 
	* Jobs query service - for read queries. Subscribes messages from jobs service
	* Jobs events - for the eventsourcing store. Subscribes messages from jobs service
* Swagger - can be used as reference by developers and execute endpoints.
* Databases:
	* Probably use NoSQL for the queries

## How to run
#### Prerequisites:
* docker
* docker-compose

#### Steps
1. clone this repository 
	```
	git clone git@github.com:markglibres/job-app-hipages.git
	```
	OR
	```
	git clone https://github.com/markglibres/job-app-hipages.git
	```
2. change directory to src
	```
	cd job-app-hipages/src
	```
3. build docker
	```
	docker-compose build
	```
4. run docker
	```
	docker-compose up
	```
5. it may take a while to spin up services and seed data. so just have a little patience until you see in console that the webapi and webapp are ready

#### Urls
* [http://localhost:3000/](http://localhost:3000/) - for the SPA. 
* [http://localhost:5000/api](http://localhost:5000/api) - for the web api
* [http://localhost:8080/](http://localhost:8080/) - for the database admin ui. 
	* server: techchallenge.mysql
	* user: root
	* password: hipages
	*	databases admin UI:
		* hipages db admin: click [here](http://localhost:8080/?server=techchallenge.mysql&username=root&db=hipages&select=jobs)
		* hipages_query db admin: click [here](http://localhost:8080/?server=techchallenge.mysql&username=root&db=hipages_query&select=jobs_info)
		* hipages_events db admin: click [here](http://localhost:8080/?server=techchallenge.mysql&username=root&db=hipages_events&select=job_events)
