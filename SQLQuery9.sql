USE [FuhrparkContext]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[InsertIndexUebersicht]
		@Kennzeichen = N'k',
		@Marke = N'k',
		@Modell = N'k',
		@Fahrzeughalter = N'k',
		@Niederlassung = N'k',
		@Kraftstoff = N'k',
		@Neuwagen = true,
		@Status = N'k',
		@Erstzulassung = N'15.05.2020',
		@ListenpreisB = 20,
		@EKPreisB = 20

SELECT	@return_value as 'Return Value'

GO
