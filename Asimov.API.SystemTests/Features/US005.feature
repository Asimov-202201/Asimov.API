Feature: US005
	Como docente
	deseo registrarme en la plataforma
	para hacer uso del servicio
	
	Background:
		Given el docente se encuentra en el formulario de registro de usuario
	
	Scenario: Un nuevo docente ingresa todos sus datos correctos en el formulario
		Given ingresa toda la información solicitada
		When da click en el botón de registrarse
		Then logra ingresar al dashboard de la aplicación

	Scenario: El nuevo docente ingresa al menos un dato invalido
		Given ingresa al menos un dato invalido
		When intenta dar click en el botón de registrarse
		Then no habrá ninguna respuesta

	Scenario: El docente ya se encuentra registrado
		Given ingresa informacion de un usuario ya registrado
		When da click en el botón de registrarse
		Then no habrá ninguna respuesta