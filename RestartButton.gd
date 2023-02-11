extends Button


func _on_RestartButton_pressed():
	Global.score = 0
	get_tree().reload_current_scene()
	pass # Replace with function body.


func _on_MenuButton_pressed():
	Global.score = 0
	get_tree().change_scene("res://Menu.tscn")
	pass # Replace with function body.
