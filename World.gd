extends Node2D

var Missle = preload("res://PlayerMissle.tscn")

func _on_Battlecrip_spawn_missle(location):
	print("pp")
	var m = Missle.instance()
	m.global_position = location
	add_child(m)

