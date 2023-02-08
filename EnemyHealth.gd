extends Area2D

var hp = 1

func _ready():
	if self.get_name() == "Bomber1Area":
		hp = 3
	if self.get_name() == "Bomber2Area":
		hp = 2


func take_damage(damage):
	print(hp)
	hp -= damage
	if hp <= 0:
		get_parent().queue_free()

