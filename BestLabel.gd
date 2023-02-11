extends Label


func _process(delta):
	self.text = "BEST: "+str(Global.best)
