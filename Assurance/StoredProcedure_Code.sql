
CREATE PROCEDURE [dbo].[GetNbrContratParClient] -- EXEC GetNbrContratParClient 2
(
	@IdClient INT
)
AS
BEGIN
	DECLARE @FirstDate DATE
			,@LastDate DATE

	SELECT @FirstDate = MIN(DateCreation)
			,@LastDate = MAX(DateCreation)  
	FROM Contrat WHERE Contrat.ClientIdClient = @IdClient
	

	;WITH Dates AS
	(
		SELECT DATEADD(DAY, -(DAY(@FirstDate) - 1), @FirstDate) AS [Date]
		UNION ALL
		SELECT DATEADD(MONTH, 1, [Date])
		FROM Dates
		WHERE [Date] < DATEADD(DAY, -(DAY(@LastDate) - 1), @LastDate)
	)
	SELECT	CONCAT(CAST(MONTH([Date]) AS nvarchar(10)) , '/', CAST(YEAR([Date]) AS nvarchar(10)) ) AS [date]
			,COUNT(IdContrat) AS NombreContrat
	FROM Dates
	LEFT JOIN Contrat ON  MONTH([Date]) = MONTH(Contrat.DateCreation) AND YEAR([Date]) = YEAR(Contrat.DateCreation) AND ClientIdClient = @IdClient
	
	GROUP BY [Date]
END

GO


CREATE PROCEDURE [dbo].[SPR_GetContratByClient] -- EXEC SPR_GetContratByClient 3
(
	@IdClient INT
)
AS 
BEGIN
	SELECT IdContrat			AS IdContrat
			,NContrat			AS NumContrat
			,DateCreation		AS DateCreation
			,DateAffect			AS DateAffectation
			,DateEcheance		AS DateEcheance
			,LibeleBranche		AS Branche
	FROM Contrat
	INNER JOIN Branche ON Branche.IdBranche = BrancheIdBranche
	INNER JOIN Client ON Client.IdClient = ClientIdClient
	
	WHERE Client.IdClient = @IdClient
END


GO
CREATE PROCEDURE [dbo].[SPR_GetListGarantieByContrat] --  EXEC SPR_GetListGarantieByContrat 5
(
	@IdContrat INT
)
AS 
BEGIN
	SELECT LibeleGarantie AS Libele
			,CodeGarantie AS Code
	FROM Garantie
	INNER JOIN BrancheGarantie ON Garantie.IdGarantie = BrancheGarantie.garantieIdGarantie
	INNER JOIN Branche ON Branche.IdBranche = BrancheGarantie.brancheIdBranche
	INNER JOIN Contrat ON Contrat.BrancheIdBranche = Branche.IdBranche

	WHERE Contrat.IdContrat = @IdContrat
END