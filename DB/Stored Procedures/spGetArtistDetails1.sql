CREATE PROCEDURE dbo.spGetArtistDetails1
	@artistID int = 1
AS
BEGIN
	
    -- Insert statements for procedure here
 SELECT Artist.title, Artist.biography, Artist.imageURL, Artist.heroURL,Song.songID, Song.title, Song.bpm,Album.albumID, Album.title, Album.imageURL
 FROM Artist JOIN Song ON Artist.artistID= Song.artistID JOIN Album ON Artist.artistID = Album.artistID WHERE Artist.artistID = @artistID
END