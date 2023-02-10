extends Node2D

var Missle = preload("res://PlayerInterceptor.tscn")

#var Cloud = preload(CloudDay)

func _on_Battlecrip_spawn_missle(location):
	var m = Missle.instance()
	m.global_position = location
	add_child(m)



#func _on_CloudDay_spawn_cloud(location):
#	var c = Cloud.instance()
#	c.global_position = location
#	add_child(c)
