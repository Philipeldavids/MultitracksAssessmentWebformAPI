CREATE PROCEDURE [dbo].[GetArtistDetails]
	@artistID INT = -1
	
AS
BEGIN
	SELECT * FROM [dbo].Artist WHERE artistID = @artistID

END