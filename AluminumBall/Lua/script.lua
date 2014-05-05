local color = { r = 0, g = 100, b = 100 }

function Run (ticks)
    SetBallColor(color.r, color.g, color.b)
    color:Update()
end

function color.Update(self)
	if (self.r > 250) then
		self.r = 0
	else
		self.r = self.r + 10
	end
end

SetClearColor(color.r, color.g, color.b)