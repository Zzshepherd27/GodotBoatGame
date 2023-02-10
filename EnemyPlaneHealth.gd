extends Area2D

var hp = 1
var explode = preload("res://smokeexplode.tscn")
var pointLow = preload("res://2000Point.tscn")
var pointMedium = preload("res://4000Point.tscn")
var pointHigh = preload("res://8000Point.tscn")
onready var world = get_node("/root/Stage")
var pointShow

func _ready():
	if (self.get_name() == "Bomber1Area"):
		#hp = 3
		pointShow = pointLow.instance()
	elif (self.get_name() == "Bomber2Area"):
		#hp = 2
		pointShow = pointMedium.instance()
	else:
		pointShow = pointHigh.instance()


func take_damage(damage):
	print(hp)
	hp -= damage
	if hp <= 0:
		$CollisionShape2D.queue_free()
		$"../BomberSprite".queue_free()
		$"../CollisionPolygon2D".queue_free()
		
		var blowup = explode.instance()
		add_child(blowup)
		blowup.global_position = get_global_position()
		
		pointShow.position = self.position
		world.add_child(pointShow)
		pointShow.global_position = get_global_position()
		pointShow.global_position.y -= 50
		
		yield(get_tree().create_timer(.9), "timeout")
		blowup.queue_free()
		pointShow.queue_free()
		get_parent().queue_free()

