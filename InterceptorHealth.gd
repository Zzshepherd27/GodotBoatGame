extends Area2D

var hp = 1

func take_damage(damage):
	hp -= damage
	if hp <= 0:
		get_parent().queue_free()

func _on_Area2D_area_entered(area):
	if area.is_in_group("Enemy"):
		area.take_damage(1)
		#area.setDeath(true)
		take_damage(1)
		
func _on_VisibilityNotifier2D_screen_exited():
	queue_free()

