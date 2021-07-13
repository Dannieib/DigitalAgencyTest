CREATE PROCEDURE [dbo].[spGetAllCities]
@regionCode char(3)

AS
begin
	SELECT * from dbo.Master_City
	where RegionCode = @regionCode
end

