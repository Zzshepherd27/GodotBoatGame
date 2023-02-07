extends CollisionShape2D

var hp = 1

func take_damage(damage):
	hp -= damage
	if hp <= 0:
		queue_free()

func _physics_process(delta):
	var collideObject = move_and_collide(Vector2(0, speed * delta))
	if(collideObject):
		take_damage(1)

