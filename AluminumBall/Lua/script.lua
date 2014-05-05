local color = { r = 0, g = 100, b = 100 }
local trajectory = { x = 0, y = 0 }

function incrementor(start, inc)
	local value = start

	return function()
		value = value + inc
		return value
	end
end

local theta = incrementor(0, 0.50)

function Run (ticks)
    ChangeTrajectory(trajectory.x, trajectory.y)
    trajectory:Update()
end

function trajectory.Update(self)
	if (self.y > 1) then
		self.y = -1
	else
		self.y = math.sin(theta())
	end
end

SetClearColor(color.r, color.g, color.b)
SetBallColor(255, 255, 255)