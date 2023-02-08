extends Area2D

var hp = 1

var speed = 400

func _ready():
	set_physics_process(true)

func take_damage(damage):
	print("pp")
	hp -= damage
	if hp <= 0:
		queue_free()

func _physics_process(delta):
	global_position.y += -speed * delta
	#var collideObject = move_and_collide(Vector2(0, -(speed * delta)))
	#if (collideObject):
	#	take_damage(1)

	
