-- Инициализация устройств.
-- Таблица устройств devices в файле проекта main.io.lua
DevicesInit = function ()
	if devices == nil then
		return 1
	end

	for _, device_table in pairs(devices) do
		local device = DeviceManager:AddDevice(device_table.name, device_table.subtype)
		rawset(device, "Description", device_table.descr)
		return device.ArticleName
		--device.Parameters[1] = 5
	end

	return 0
end

SetProperty = function (table, key, value)
	table.__newindex = function(table, key, value)
		if key == "Name" then
			return rawset(tbl, "name", value)
		end
	end
end
