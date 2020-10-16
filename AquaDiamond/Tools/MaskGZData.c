#include "C:\Factory\SubTools\libs\MaskGZData.h"

void MaskGZData(autoBlock_t *fileData)
{
	uint size = getSize(fileData);
	uint index;

	for(index = 0; index < size; index++)
	{
		b_(fileData)[index] ^= ((uint64)size << 32) % (index % 100 + 56) + 100;
	}
}
