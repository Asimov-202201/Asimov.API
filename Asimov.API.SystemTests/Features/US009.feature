

Feature: US009
	Como director
	deseo tener una lista de los docentes
	para buscarlos de manera más sencilla

	Background: 
		Given el director se encuentra el menú de la aplicación
		When seleccione ver listado de docentes
@mytag
Scenario: Visualiza la lista de docentes
	Then podrá visualizar la información de todos los docentes de su institución

Scenario: No hay docentes registrados
	Then aparecerá un mensaje “no existen docentes registrados para esta institución”

Scenario: No se puede acceder a la información
	Then aparecerá un mensaje “error interno: no se ha podido acceder a esta información”