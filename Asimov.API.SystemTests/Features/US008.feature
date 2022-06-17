Feature: US008
	Como director
	deseo publicar un anuncio
	para informar algo a todos los docentes
	
	Background: 
		Given el director se encuentra en la sección “Announcements”
	
	Scenario: Publica el anuncio
		When ingresa los datos del formulario de nuevo anuncio
		And presiona el botón submit
		Then recibira un mensaje de publicación exitosa

	Scenario: No hay datos completos
		When no ingresa todos los datos del formulario de nuevo anuncion
		And presiona el botón submit
		Then observara un mensaje de faltan datos requeridos
		
	Scenario: No hay docentes registrados
		When ingresa los datos del formulario de nuevo anuncio
		And presiona el botón submit
		And no hay docentes registrados
		Then aparecerá el mensaje de error