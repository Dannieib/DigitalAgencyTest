CREATE PROCEDURE [dbo].[spGetRegionByCountryCode]
	@countryCode char(3)

AS
	begin
		select * from dbo.Master_Region
		where 
		CountryCode = @countryCode
	end