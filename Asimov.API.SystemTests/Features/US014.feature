Feature: US014
	Como docente
	deseo ver los cursos que debo completar en la semana
	para completarlos de manera correcta

@mytag
Scenario: El docente visualiza la lista de cursos de la semana.
	Given el docente está ubicado en el Dash Board de la aplicación
	When seleccione la opción de cursos en la barra izquierda
	Then  visualiza los cursos que llevará a cabo en la semana. 

Scenario: El docente ingresa a los detalles de un curso
	Given el docente se encuentra en la sección de cursos
	When seleccione la opción “ver detalle” de algún curso
	Then visualiza el contenido de la semana de dicho curso.