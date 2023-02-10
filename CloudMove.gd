extends Sprite


#var speed = 100

#signal spawn_cloud(location)

#onready var spawn = $CloudSpawn

#onready var spawnDelayTimer = $SpawnDelayTimer
#var spawnDelay: float = 0.5

#func spawn_cloud():
#	emit_signal("spawn_cloud", spawn.global_position)

#Movement
#func _ready():
#	set_physics_process(true)

#func _physics_process(delta):
#	global_position.x += -speed * delta
#	if spawnDelayTimer.is_stopped():
#		spawnDelayTimer.start(spawnDelay)
#		spawn_cloud()



#Delete Cloud when offscreen
#func _on_VisibilityNotifier2D_screen_exited():
#	queue_free()

