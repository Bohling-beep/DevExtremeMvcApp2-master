USE [FuhrparkContext]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[InsertIndexUebersicht]
		@Kennzeichen = N'm',
		@Marke = N'm',
		@Modell = N'm',
		@Fahrzeughalter = N'm',
		@Niederlassung = N'm',
		@Kraftstoff = N'm',
		@Neuwagen = true,
		@Status = N'm',
		@Erstzulassung = N'm',
		@KMDatum = N'm',
		@Kaufdatum = N'm',
		@KMStand = N'm',
		@ListenpreisB = N'm',
		@EKPreisB = N'm'

SELECT	@return_value as 'Return Value'

GO
