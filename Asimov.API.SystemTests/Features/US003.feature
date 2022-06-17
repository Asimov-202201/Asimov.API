Feature: US003
	Como docente
	deseo ver cómo va mi progreso
	para conocer cuánto me falta para completar el total
	
	Background: 
		Given el docente ingresa correctamente en la plataforma

	Scenario: El docente visualiza su progreso personal
		When está en el menú principal
		Then visualizará un resumen de su progreso en el año escolar hasta la actualidad

	Scenario: El docente pierde la conexion durante la consulta
		When está en el menú principal
		And pierde conexión a internet
		Then un mensaje aconseja volver a cargar la página

	Scenario: El docente visualiza que ha concluido con las metas del año escolar
		When está en el menú principal
		And ha concluido las metas del año
		Then observará un mensaje de felicitaciones por el cumplimientos de las metas