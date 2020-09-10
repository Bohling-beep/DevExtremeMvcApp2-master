USE [FuhrparkContext]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[InsertIndexUebersicht]
		@Kennzeichen = N'l',
		@Marke = N'l',
		@Modell = N'l',
		@Fahrzeughalter = N'l',
		@Niederlassung = N'l',
		@Kraftstoff = N'l',
		@Neuwagen = true,
		@Status = N'l',
		@Erstzulassung = N'15.05.2020',
		@KMDatum = N'15.05.2020',
		@Kaufdatum = N'15.05.2020',
		@KMStand = 20,
		@ListenpreisB = 20,
		@EKPreisB = 20

SELECT	@return_value as 'Return Value'

GO
