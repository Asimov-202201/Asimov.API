Feature: US001
	Como director
	deseo ver el resumen del avance todos los docentes
	para conocer el desarrollo de los docentes
	
	Background:
		Given el director ingresa correctamente en la plataforma
	
	Scenario: El director visualiza el resumen general de los docentes durante el año escolar
		When seleccione para ver el resumen general
		Then visualizará los diferentes gráficos sobre el progreso de los profesores.
		
	Scenario: El director visualiza al inicio del año escolar el resumen general de los docentes
		When seleccione para ver el resumen general
		And es el inicio del año escolar
		Then todos los datos estadísticos comienzan en 0.
	
	Scenario: El director visualiza el resumen general de los docentes al finalizar el año escolar
		When seleccione para ver el resumen general
		And el año escolar ya ha concluído
		Then visualizará los diferentes gráficos sobre las metas logradas por los profesores.