Feature: US010
	Como director
	deseo visualizar el horario de los docentes
	para facilitar su monitoreo
	
	Background: 
		Given el director se encuentra en el apartado de Teachers
	
	Scenario: Existen docentes registrados con horario
		When seleccione un docente de la lista de docentes
		Then podrá ver la información del docente junto con su horario

	Scenario: Existen docentes registrados sin horario
		When seleccione un docente de la lista de docentes
		Then podrá ver la información del docente, pero no encontrará su horario

	Scenario: No existen docentes registrados
		When seleccione un docente de la lista de docentes
		Then se mostrará el mensaje “no existen docentes registrados para esta institución”