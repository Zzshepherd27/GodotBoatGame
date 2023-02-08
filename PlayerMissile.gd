extends Area2D

var speed = 400

func _ready():
	set_physics_process(true)

func _physics_process(delta):
	global_position.y += -speed * delta
	#var collideObject = move_and_collide(Vector2(0, -(speed * delta)))
	#if (collideObject):
	#	take_damage(1)

	
