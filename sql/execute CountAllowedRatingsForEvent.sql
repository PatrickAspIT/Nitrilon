USE [NitrilonDB]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[CountAllowedRatingsForEvent]
		@EventId = 2

SELECT	@return_value as 'Return Value'

GO