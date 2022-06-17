Feature: US030
	Como docente
	deseo culminar un curso
	para aumentar el progreso personal
	
@mytag
Scenario: culminar curso 
	Given el docente esté desarrollando un curso
	When haya completado todos los ítems del curso
	Then el progreso del profesor aumentará

Scenario: no se puede culminar el curso 
	Given el docente esté desarrollando algún curso
	When no haya completado todos los ítems del curso
	Then el progreso del profesor no aumentará

Scenario: se culmina el curso satisfactoriamente 
	Given el docente esté desarrollando cierto curso
	When haya completado cada uno de los ítems del curso
	Then el curso aparecerá como completado en la lista de cursos del docente.