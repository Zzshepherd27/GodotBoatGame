extends Area2D

var hp = 1

var speed = 500

func _ready():
	set_physics_process(true)

func take_damage(damage):
	print("pp")
	hp -= damage
	if hp <= 0:
		queue_free()

func _physics_process(delta):
	var collideObject = move_and_collide(Vector2(0, -(speed * delta)))
	if (collideObject):
		take_damage(1)

#global_position.y += -speed * delta
	
