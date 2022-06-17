Feature: US015
	Como director
	deseo registrarme en la aplicación
	para facilitar el control a los docentes
	
	Background: 
		Given el director se encuentra en el formulario de registro de usuario
	
	Scenario: Un nuevo director ingresa todos sus datos correctos en el formulario
		When ingresa toda la información solicitada
		And selecciona que es un director
		And el director da click en el botón de registrarse
		Then logra ingresar al dashboard de la aplicación

	Scenario: El nuevo director ingresa al menos un dato invalido
		When ingresa al menos un dato invalido
		And el director intenta dar click en el botón de registrarse
		Then no habrá ninguna respuesta

	Scenario: El docente ya se encuentra registrado
		When ingresa información de un usuario ya registrado
		And el director da click en el botón de registrarse
		Then no habrá ninguna respuesta