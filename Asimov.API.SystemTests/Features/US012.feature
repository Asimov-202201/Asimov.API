Feature: US012
	Como director
	deseo guardar un historial de planificación de competencias
	para evaluar los cambios realizados de previas planificaciones

	Background: 
		Given el director se encuentra en el menú de la aplicación
		And hace click al apartado de historial de planificación de competencias
		When haga click en la opción de agregar una planificación
@mytag
Scenario: Crea una planificación de competencias.
	Then podrá elegir una planificación de competencias para agregarlo 

Scenario: No existen competencias.
	Then se mostrará el mensaje “Actualmente no existen competencias a planificar”

Scenario: No se ha podido acceder a la información
	Then se mostrará el mensaje “Error interno: no se ha podido acceder a la información”