-- Инициализация устройств.
-- Таблица устройств devices в файле проекта main.io.lua
function DevicesInit()
	if not devices then
		return
	end

	for _, device_table in pairs(devices) do
		local device = DeviceManager:AddDevice(device_table.name, device_table.dtype, device_table.subtype, device_table.descr, device_table.article)
		if not device then
			return
		end
		
		device:SetParameters(device_table.par or nil)
		
		SetChannels(device, "DO", device_table.DO or nil)
		SetChannels(device, "DI", device_table.DI or nil)
		SetChannels(device, "AO", device_table.AO or nil)
		SetChannels(device, "AI", device_table.AI or nil)

	end
end

function  SetChannels(device, channel_type, channels)
	if not channels then
		return
	end

	for index, channel in pairs(channels) do
		device:SetChannel(channel_type, index - 1, channel.node, channel.offset, channel.physical_port, channel.logical_port, channel.module_offset)
	end
end