extends Sprite

signal spawn_missle(location)

onready var muzzle = $Muzzle

func _physics_process(delta):
	if Input.is_action_just_pressed("shoot"):
		shoot_missle()

func shoot_missle():
	emit_signal("spawn_missle", muzzle.global_position)
