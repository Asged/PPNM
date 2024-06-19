out.txt: main.exe
	mono main.exe > out.txt

library.dll: matrix.cs vector.cs QRGS.cs IIAE.cs
	mcs -target:library -out:library.dll matrix.cs vector.cs QRGS.cs IIAE.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

clean:
	rm -f *.dll *.exe out.txt 