extends Area2D

func _on_Area2D_area_entered(area):
	if area.is_in_group("Enemy"):
		area.get_parent().queue_free()
		get_parent().queue_free()
