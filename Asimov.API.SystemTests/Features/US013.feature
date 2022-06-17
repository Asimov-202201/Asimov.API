Feature: US013
	Como director
	deseo ver el top de los docentes
	para comparar el rendimiento con los demás docentes
	
	Background: 
		Given el director ingresa correctamente a su cuenta
	
	Scenario: La tabla de posiciones aún no está disponible
		When selecciona la opción “Top Teachers” de la barra izquierda
		Then aparece el mensaje “Tabla de posiciones no disponible”

	Scenario: El director visualiza la tabla de posición
		When selecciona la opción “Top Teachers” de la barra izquierda
		Then visualiza la tabla de posiciones de los docentes