extends Area2D

var hp = 1
var explode = preload("res://smokeexplode.tscn")
onready var world = get_node("/root/Stage")

var pointLow = preload("res://250Point.tscn")
var pointMedium = preload("res://500Point.tscn")
var pointHigh = preload("res://1000Point.tscn")

func take_damage(damage):
	hp -= damage
	if hp <= 0:
		$CollisionShape2D.queue_free()
		$"../SmokeParticles".queue_free()
		$"../FireParticles".queue_free()
		$"../Sprite".queue_free()
		$"../CollisionShape2D".queue_free()
				
		var blowup = explode.instance()
		var pointShow
		

		if ($"..".getPoints() == 250):
			pointShow = pointLow.instance()
		if ($"..".getPoints() == 500):
			pointShow = pointMedium.instance()
		if ($"..".getPoints() == 1000):
			pointShow = pointHigh.instance()
		
		blowup.position = self.position
		world.add_child(blowup)
		blowup.global_position = get_global_position()
		
		pointShow.position = self.position
		world.add_child(pointShow)
		pointShow.global_position = get_global_position()
		pointShow.global_position.y -= 30
		
		
		yield(get_tree().create_timer(.9), "timeout")
		blowup.queue_free()
		pointShow.queue_free()
		get_parent().queue_free()

