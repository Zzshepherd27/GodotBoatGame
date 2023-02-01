extends Area2D

var speed = 500

func _physics_process(delta):
	global_position.y += -speed * delta
