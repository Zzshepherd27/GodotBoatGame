extends Area2D

var hp = 3 setget ,getHealth
var explode = preload("res://smokeexplode.tscn")
var audioStream

func take_damage(damage):
	hp -= damage
	if hp <= 0:
		audioStream = get_node("Ship Explosion")
		var world = get_node("/root/Stage/Audio")
		world.audioBasic(audioStream)
		var blowup = explode.instance()
		add_child(blowup)
		blowup.global_position = get_global_position()
		
		$"../Battlecrip".queue_free()
		$"../Battlecrip/Muzzle".queue_free()
		$"../Battlecrip/FireDelayTimer".queue_free()
		$"../CollisionPolygon2D".queue_free()
		
		
		yield(get_tree().create_timer(.9), "timeout")
		get_parent().queue_free()

func getHealth():
   return hp

func _on_BattleShipArea_area_entered(area):
	if area.is_in_group("Enemy"):
		area.take_damage(1)
		#area.setDeath(true)
		take_damage(1)
		
