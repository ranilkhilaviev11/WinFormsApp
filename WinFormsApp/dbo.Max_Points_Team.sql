CREATE PROCEDURE Max_Points_Team
AS
SELECT *
FROM Players 
WHERE TeamId =
(SELECT Id FROM Teams WHERE point = (SELECT MAX(point) AS point FROM Teams))