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
		@ListenpreisB = 20,
		@EKPreisB = 20

SELECT	@return_value as 'Return Value'

GO
