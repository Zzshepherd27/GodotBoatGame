extends Sprite

signal spawn_missle(location)

onready var muzzle = $Muzzle

onready var fireDelayTimer = $FireDelayTimer
var fireDelay: float = 0.5

func _physics_process(delta):
	if Input.is_action_pressed("shoot") and fireDelayTimer.is_stopped():
		fireDelayTimer.start(fireDelay)
		shoot_missle()

func shoot_missle():
	emit_signal("spawn_missle", muzzle.global_position)
