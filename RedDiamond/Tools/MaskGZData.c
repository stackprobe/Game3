#include "C:\Factory\SubTools\libs\MaskGZData.h"

void MaskGZData(autoBlock_t *fileData)
{
	uint size = getSize(fileData) / 13;
	uint index;

	for(index = 0; index < size; index++)
	{
		swapByte(fileData, index, size + size * (index % 4) * 3 + index * 3);
	}
	for(index = 0; index < getSize(fileData); index++)
	{
		b_(fileData)[index] ^= 'r';
	}
}
