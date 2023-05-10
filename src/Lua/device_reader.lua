-- Инициализация устройств.
-- Таблица устройств devices в файле проекта main.io.lua
function DevicesInit()
	if not devices then
		return
	end

	for _, device_table in pairs(devices) do
		local device = DeviceManager:AddDevice(device_table.name, device_table.dtype, device_table.subtype, device_table.descr, device_table.article)
		device:SetParameters(device_table.par or nil)
		--SetChannels(device:GetChannels("DO"), device_table.DO or nil)
		--SetChannels(device:GetChannels("DI"), device_table.DI or nil)
		--SetChannels(device:GetChannels("AO"), device_table.AO or nil)
		--SetChannels(device:GetChannels("AI"), device_table.AI or nil)
	end
end