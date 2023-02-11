extends Label


func _process(delta):
	
	if Global.score < 10:
		self.text = "00000"+str(Global.score)
	elif Global.score < 100:
		self.text = "0000"+str(Global.score)
	elif Global.score < 1000:
		self.text = "000"+str(Global.score)
	elif Global.score < 10000:
		self.text = "00"+str(Global.score)
	elif Global.score < 100000:
		self.text = "0"+str(Global.score)
	else:
		self.text = str(Global.score)
