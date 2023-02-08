extends Area2D

var hp = 1

func take_damage(damage):
	hp -= damage
	if hp <= 0:
		get_parent().queue_free()

func _on_Area2D_area_entered(area):
	if area.is_in_group("Enemy"):
		print("enemyOuch")
		area.take_damage(1)
		print("playerOuch")
		take_damage(1)
		
		
