Feature: US002
	Como director
	deseo ver el progreso de un docente en particular
	para saber el desempeño por cada competencia
	
	Background:
		Given el director ingresa correctamente en la plataforma	
	
	Scenario: El director visualiza el progreso de un docente.
		When ingresa la lista de profesores en su institución
		And selecciona a uno de los docentes
		Then ve el desarrollo y progreso del docente con detalle. 

	Scenario: El director pierde la conexión durante la visualización del progreso de un docente.
		When ingresa la lista de profesores en su institución
		And selecciona a uno de los docentes
		And  pierde la conexión a internet
		Then verá un mensaje de “hubo un error al establecer conexión con la red”

	Scenario: El director visualiza el progreso de un docente como concluido
		When ingresa la lista de profesores en su institución
		And selecciona a uno de los docentes
		And  el docente ha concretado su progreso anual
		Then verá un mensaje de “el docente ha concluido los logros anuales”