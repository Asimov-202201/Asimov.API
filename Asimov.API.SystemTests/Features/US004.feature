Feature: US004
	Como docente
	deseo ver cuántos puntos voy realizando
	para estar al tanto de mi progreso anual
	
	Background: 
		Given el docente se encuentra en su perfil
	
	Scenario: El docente visualiza su puntaje personal al inicio del año
		When no ha comenzado sus cursos
		Then visualizará un mensaje “por comenzar” en vez de visualizar un puntaje
 
	Scenario: El docente visualiza su puntaje personal durante el transcurso del año
		When ya ha avanzado parte de sus cursos
		Then visualiza todo el puntaje obtenido hasta la actualidad

	Scenario: El docente visualiza su puntaje personal al final del año
		When ha completado todos sus cursos
		Then visualiza todo el puntaje obtenido