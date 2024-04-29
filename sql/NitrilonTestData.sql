/* INSERT
-- Insert data into the Events table in the Date and Name columns.
INSERT INTO Events (Date, Name)
-- Values to be inserted into the Events table.
VALUES 
	('04/04/2024', 'Patrick Sean Lange-Nielsen');
*/

/* UPDATE
-- Update data in the Events table in the Date and Name columns.
UPDATE Events
-- Set the Date and Name columns to the following values.
SET Date = '05/04/2024', Name = 'Patrick Sean Lange-Nielsen æ ø å'
-- Update the row where the EventID is 1.
WHERE EventID = 1;
*/

/* SELECT
-- Select all data from the Events table
SELECT EventId, Date, Name, Attendees, Description
-- From the Events table
FROM Events;
*/

/* DELETE
-- Delete data from the table Events where the EventID is 2.
DELETE FROM Events WHERE EventID = 2;
*/

-- Delete all data from the tables EventRatings, Events and Users.
DELETE FROM EventRatings;
DELETE FROM Events;
DELETE FROM Ratings;

-- Reset the identity seed for the tables EventRatings, Events and Users.
-- This resets the ids to 1.
DBCC CHECKIDENT (EventRatings, RESEED, 0);
DBCC CHECKIDENT (Events, RESEED, 0);
DBCC CHECKIDENT (Ratings, RESEED, 0);


-- Insert data into the Events table in the Date, Name, Attendees and Description columns.
INSERT INTO Events (Date, Name, Attendees, Description)
VALUES 
	('04/04/2024', 'Patrick', 4, 'This is a test event.'),
	('05/04/2024', 'Søren', 0, 'Testing.'),
	('06/04/2024', 'Mikkel', 2, 'event.'),
	('07/04/2024', 'Lotte', 1, 'Aalborg event.'),
	('08/04/2024', 'Jensen', 3, 'Vejle.');

-- Insert data into the Ratings table in the Value and Description columns.
INSERT INTO Ratings (Value, Description)
VALUES 
	(1, 'Forfærdelig oplevelse.'),
	(2, 'Dårlig oplevelse.'),
	(3, 'Okay oplevelse.'),
	(4, 'God oplevelse.'),
	(5, 'Fantastisk oplevelse.');

-- Insert data into the EventRatings table in the EventId and RatingId columns.
INSERT INTO EventRatings (EventId, RatingId)
VALUES 
	(1, 3), -- Event 1 has a rating of 3/5.
	(2, 2), -- Event 2 has a rating of 2/5.
	(3, 4), -- Event 3 has a rating of 4/5.
	(4, 1), -- Event 4 has a rating of 1/5.
	(5, 5); -- Event 5 has a rating of 5/5.