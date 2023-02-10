extends Area2D

var hp = 1
var explode = preload("res://smokeexplode.tscn")

func _ready():
	if self.get_name() == "Bomber1Area":
		hp = 3
	if self.get_name() == "Bomber2Area":
		hp = 2


func take_damage(damage):
	print(hp)
	hp -= damage
	if hp <= 0:
		
		var blowup = explode.instance()
		add_child(blowup)
		blowup.global_position = get_global_position()
		$"../SmokeParticles".queue_free()
		$"../FireParticles".queue_free()
		$"../Sprite".queue_free()
		$"../CollisionShape2D".queue_free()
		
		
		yield(get_tree().create_timer(.9), "timeout")
		get_parent().queue_free()

