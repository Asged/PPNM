out.txt: main.exe
	mono main.exe > out.txt

library.dll: minimization.cs vector.cs matrix.cs QRGS.cs
	mcs -target:library -out:library.dll minimization.cs vector.cs matrix.cs QRGS.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

clean:
	rm -f *.dll *.exe Errorfunc.txt *.svg out.txt