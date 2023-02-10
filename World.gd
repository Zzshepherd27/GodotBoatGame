extends Node2D

var Missle = preload("res://PlayerInterceptor.tscn")

var Cloud = preload("res://DayCloud.tscn")

onready var cloudSpawnOne = $CloudSpawn1
onready var cloudSpawnTwo = $CloudSpawn2

onready var cloudSpawnTimer = $CloudSpawnTimer
var cloudDelay: float = 0.5

func _on_Battlecrip_spawn_missle(location):
	var m = Missle.instance()
	m.global_position = location
	add_child(m)

#func _on_CloudDay_spawn_cloud(location):
	
func _ready():
	var c = Cloud.instance()
	c.global_position = cloudSpawnOne.global_position
	add_child(c)
	var d = Cloud.instance()
	d.global_position = cloudSpawnTwo.global_position
	add_child(d)
	
	#while(true):
	#	if(cloudSpawnTimer.is_stopped()):
	#		spawn_cloud()
			
func spawn_cloud():
	var d = Cloud.instance()
	d.global_position = cloudSpawnTwo.global_position
	add_child(d)
	

