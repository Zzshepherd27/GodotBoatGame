extends CollisionShape2D

var hp = 1

func take_damage(damage):
	hp -= damage
	if hp <= 0:
		queue_free()

func _on_CollisionShape2D_child_entered_tree(node):
	take_damage(1)
