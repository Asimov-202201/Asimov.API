Feature: US029
	Como docente
	deseo marcar como realizado un ítem
	para completar parte de un curso

	Background: 
		Given el docente se encuentra en un curso
	
@mytag
Scenario: Completar item 
	When le da click al botón completar de un ítem
	Then el ítem se completará y el progreso de un curso aumenta

Scenario: No se completa el ítem 
	When no le da click al botón completar de un ítem
	Then el ítem quedará incompleto y el progreso del curso no aumentará

Scenario: El profesor olvida completar el ítem. 
	When el docente haya abierto un ítem
	And olvide dar click al botón completar de un ítem
	Then se le enviará una notificación preguntando si completo el ítem.