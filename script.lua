function findHosts()
	if (ed >= 0 and ed <= 30) then
		return (2^(32 - ed) - 2);
    else
		return 0;
	end
end

mask = {0, 0, 0, 0}

function findMask()
	if (ed <= 32 and ed >= 24) then
		for i = 1, 3, 1 do
			mask[i] = 255
		end
		mask[4] = 256 - 2^(32 - ed)
	end
	if (ed < 24 and ed >= 16) then
		mask[1] = 255
		mask[2] = 255
		mask[3] = 256 - 2^(24 - ed)
		mask[4] = 0
	end
	if (ed < 16 and ed >= 9) then
		mask[1] = 255
		mask[2] = 256 - 2^(16 - ed)
	end
	if (ed > 0 and ed < 9) then
		mask[1] = 256 - 2^(8 - ed)
	end
	return mask
end

function findNetwork(ip1, ip2, ip3, ip4)
	ip = {ip1, ip2, ip3, ip4}
	for i = 1, 4, 1 do
		if (mask[i] ~= 255) then
			l = 2^((32 - ed) % 8)
			ip[i] = l * (ip[i] // l)
		end
		if (mask[i] == 0) then
			ip[i] = 0
		end
	end
	return ip
end

function findBroadcast()
	for i = 1, 4, 1 do
		if (mask[i] == 0) then
			ip[i] = 255
		end
		if (mask[i] ~= 255 and mask[i] ~= 0) then
			ip[i] = ip[i] + l - 1;
		end
	end
	return ip
end