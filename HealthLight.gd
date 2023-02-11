extends Sprite

var green = preload("res://Sprites/Health_Light-01.png")
var yellow = preload("res://Sprites/Health_Light-02.png")
var red = preload("res://Sprites/Health_Light-03.png")
var off = preload("res://Sprites/Health_Light-04.png")

onready var this_sprite = get_node(".")

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	
	if get_node("../BattleShip/BattleShipArea") == null:
		if Global.score > Global.best:
			Global.best = Global.score
		$"../RestartButton".visible = true
		this_sprite.set_texture(off)
	elif $"../BattleShip/BattleShipArea".getHealth() == 3:
		this_sprite.set_texture(green)
	elif $"../BattleShip/BattleShipArea".getHealth() == 2:
		this_sprite.set_texture(yellow)
	elif $"../BattleShip/BattleShipArea".getHealth() == 1:
		this_sprite.set_texture(red)
	
	pass
