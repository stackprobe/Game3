#include "C:\Factory\SubTools\libs\MaskGZData.h"

static uint X;
static uint Y;
static uint Z;
static uint A;

static uint Xorshift128(void)
{
	uint t;

	t = X;
	t ^= X << 11;
	t ^= t >> 8;
	t ^= A;
	t ^= A >> 19;
	X = Y;
	Y = Z;
	Z = A;
	A = t;

	return t;
}
void MaskGZData(autoBlock_t *fileData)
{
	uint size = getSize(fileData);
	uint index;

	X = size % 3001;
	Y = size % 3011;
	Z = size % 3019;
	A = size % 3023;

	for(index = 0; index < getSize(fileData); index++)
	{
		b_(fileData)[index] ^= Xorshift128() % 239 + 16;
	}
}
