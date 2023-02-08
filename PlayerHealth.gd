extends Area2D

var hp = 3

func take_damage(damage):
	hp -= damage
	if hp <= 0:
		get_parent().queue_free()

func _on_BattleShipArea_area_entered(area):
	if area.is_in_group("Enemy"):
		print("enemyOuch")
		area.take_damage(1)
		print("playerOuch")
		take_damage(1)
		
