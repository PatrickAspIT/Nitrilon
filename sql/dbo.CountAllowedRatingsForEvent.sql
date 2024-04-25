CREATE PROCEDURE CountAllowedRatingsForEvent
    @EventId INT
AS
BEGIN
    DECLARE @Count1 INT, @Count2 INT, @Count3 INT, @Count4 INT, @Count5 INT;

    SELECT @Count1 = COUNT(CASE WHEN RatingId = 1 THEN 1 ELSE NULL END),
           @Count2 = COUNT(CASE WHEN RatingId = 2 THEN 1 ELSE NULL END),
           @Count3 = COUNT(CASE WHEN RatingId = 3 THEN 1 ELSE NULL END),
		   @Count4 = COUNT(CASE WHEN RatingId = 4 THEN 1 ELSE NULL END),
		   @Count5 = COUNT(CASE WHEN RatingId = 5 THEN 1 ELSE NULL END)
    FROM EventRatings
    WHERE EventId = @EventId;

    SELECT @Count1 AS RatingId1Count,
           @Count2 AS RatingId2Count,
           @Count3 AS RatingId3Count,
		   @Count4 AS RatingId4Count,
		   @Count5 AS RatingId5Count;
END