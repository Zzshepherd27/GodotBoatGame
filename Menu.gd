extends Control

# Called when the node enters the scene tree for the first time.
func _ready():
	$VBoxContainer/Start.grab_focus()



func _on_Start_pressed():
	get_tree().change_scene("res://Node2D.tscn")


func _on_Quit_pressed():
	get_tree().quit()
